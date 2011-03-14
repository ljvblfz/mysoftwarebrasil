using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.CalculoTaxas {
	/// <summary>
	/// Esquema de analise de conta comun por consumo medido
	/// </summary>
	public class AnaliseConta : IAnaliseConta {
		#region Metodos publicos
		/// <summary>
		/// Calcula variação do consumo em porcentagem
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama o metodo TipoVariacaoConsumo, para:</description></item>
		/// <item><description>Tipo "A" (acrescimo): valConsumoMedido - valConsumoMedio</description></item>
		/// <item><description>Tipo "D" (decrescimo): valConsumoMedio - valConsumoMedido</description></item>
		/// <item><description>Retorna o valor percentual da diferença calculado sobre o consumo medio</description></item>
		/// </list>
		/// </remarks>
		/// <param name="movimento">Movimento com o consumo a ser testado</param>
		/// <returns>O percentual de variação.</returns>
		public virtual int VariacaoConsumo(OnpMovimento movimento) {
			double variacaoPercentual = 0.0;

			if (movimento.ValConsumoMedido.HasValue) {
				// Verifica se é acrescimo ou decrescimo
				string tipoVariacao = TipoVariacaoConsumo(movimento);
				int variacaoConsumo = (int)(tipoVariacao.Equals("A") ? (movimento.ValConsumoMedido.Value - movimento.ValConsumoMedio.Value) : (movimento.ValConsumoMedio.Value - movimento.ValConsumoMedido.Value));

				if (!movimento.ValConsumoMedio.HasValue || movimento.ValConsumoMedio.Value == 0)
					variacaoPercentual = variacaoConsumo;
				else
					variacaoPercentual = ((double)variacaoConsumo / movimento.ValConsumoMedio.Value) * 100.0;
			}
			
			return (int)variacaoPercentual;
		}

		/// <summary>
		/// Verifica se deve ou não reter a conta para análise
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso <param name="movimento"/> tenha ValConsumoMedido e o indSituacaoMovimento nao seja "R" (Retido)</description></item>
		/// <item><description>Chama o metodo RetemParaAnaliseinterno() passando <paramref name="movimento"/> como parametro</description></item>
		/// <item><description>Caso este metodo retorne true, altera o IndSituacaoMovimento para "R" e persist o movimento</description></item>
		/// <item><description>Faz o mesmo caso o GetPrimeiraOcorrencia() do movimento tenha TipoCalculoConsumo seja SeMediaZeroCobraMinimoSenaoRetem e ValConsumoMedio seja maior que zero</description></item>
		/// <item><description>Retorna true se IndSituacaoMovimento do movimento for igual a "R"</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna true caso o movimento tenha sido retido para análise, caso contrário retorna false.</returns>
		public virtual bool RetemParaAnalise(OnpMovimento movimento) {
			bool result = false;

			if (movimento.ValConsumoMedido.HasValue && !movimento.IndSituacaoMovimento.Equals("R"))
				result = RetemParaAnaliseinterno(movimento);

			if (movimento.GetPrimeiraOcorrencia() != null && movimento.GetPrimeiraOcorrencia().Ocorrencia.TipoCalculoConsumo == OnpOcorrencia.CalculoConsumo.SeMediaZeroCobraMinimoSenaoRetem && movimento.ValConsumoMedio.Value > 0)
				result = true;

			// Atualiza a situação da fatura
			if (result) {
				movimento.IndSituacaoMovimento = "R";
				movimento.Persist();
			}

			return movimento.IndSituacaoMovimento.Equals("R");
		}

		/// <summary>
		/// Verifica se deve ou nao emmitir aviso de variação
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso a matricula esteja processada (IndProcessado = "S") retorna o resultado da chamada de EmiteAvisoVariacao() passando matricula.Movimento como parametro</description></item>
		/// <item><description>Caso contrario retorna false</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna true se deve emitir aviso de retenção, caso contrário retorna false.</returns>
		public virtual bool EmiteAvisoVariacao(OnpMatricula matricula) {
			bool result = false;

			if (matricula != null && matricula.IndProcessado.Equals("S"))
				result = EmiteAvisoVariacao(matricula.Movimento);
			
			return result;
		}

		/// <summary>
		/// Verifica se movimento em questao teve acréscimo ou decréscimo de consumo.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Retorna true caso a chamada do metodo TipoVariacaoConsumo() passando movimento como parametro seja igual "A"</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna true caso o movimento tenha tido acréscimo de consumo, caso ele tenha decréscimo retorna false.</returns>
		public bool AcrescimoConsumo(OnpMovimento movimento) {
			return TipoVariacaoConsumo(movimento).Equals("A");
		}
		#endregion

		#region Metodos privados
		/// <summary>
		/// Verifica se um movimento precisa ser retido para análise.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Se não tiver ValConsumoMedido ou não tiver ValConsumoMedio retorna false.</description></item>
		/// <item><description>Verifica se tem uma ocorrencia que força reter para análise, se tiver retorna true</description></item>
		/// <item><description>Caso contrário, se o IndSituacaoMovimento for igual a "C" e ValConsumoMedido for diferente de ValConsumoMedio e TipoCalculoConsumo for pela LeituraInformada:</description></item>
		/// <item><description>- Calcula o consumo por economia (valConsumoEconomia)</description></item>
		/// <item><description>- Chama ParametroRetencao() passando <paramref name="movimento"/> como parametro, guarda o resultado em parametro</description></item>
		/// <item><description>- Caso IndUnidadeVariacao de parametro seja "C"</description></item>
		/// <item><description>-- Retorna true se valConsumoEconomia for maior ou igual a ValVariacaoRetencao de parametro</description></item>
		/// <item><description>- Caso IndUnidadeVariacao de parametro seja "P"</description></item>
		/// <item><description>-- Retorna true caso a valor retornado por VariacaoConsumo() que recebe como parametro movimento seja maior ou igual a ValVariacaoRetencao de parametro</description></item>
		/// </list>
		/// </remarks>
		/// <param name="movimento">Movimento a ser analisado.</param>
		/// <returns>Retorna true caso o movimento deva ser retido para análise, caso contrário retorna.</returns>
		protected virtual bool RetemParaAnaliseinterno(OnpMovimento movimento) {
			// Consumo medido
			bool result = false;

			if (!movimento.ValConsumoMedido.HasValue || !movimento.ValConsumoMedio.HasValue)
				return false;

			// Caso tenha ocorrencia que retem para analise
			result = (movimento.ocorrenciaRetemAnalise() != null);

			// Calcula o consumo por economia
			int valConsumoEconomia = (int)(movimento.ValConsumoMedido.Value / TotalEconomias(movimento));

			// Calcula retencao apenas se já não reteve por ocorrencia e 
			// para quem tem media e quando o calculo é pela leitura informada
			if ((!result) &&
				!string.IsNullOrEmpty(movimento.IndSituacaoMovimento) && movimento.IndSituacaoMovimento.Equals("C") &&
				(movimento.ValConsumoMedio != null) &&
				(movimento.ValConsumoMedio.Value != movimento.ValConsumoMedido.Value) &&
				(
					movimento.TipoCalculoConsumo() == OnpOcorrencia.CalculoConsumo.LeituraInformada ||
					(
						(
							movimento.TipoCalculoConsumo() == OnpOcorrencia.CalculoConsumo.NaoTemLeituraCobraMedia ||
							movimento.TipoCalculoConsumo() == OnpOcorrencia.CalculoConsumo.NaoTemLeituraCobraMinimo
						)
						&& movimento.ValConsumoMedido.HasValue
					)
				)) {

				// Busca o parametro de retencao para a media do consumo
				OnpParametroRetencao parametro = ParametroRetencao(movimento);

				// Caso tenha um parametro de retenção
				if (parametro != null && parametro.ValVariacaoRetencao.HasValue) {
					// Caso o parametro seja por consumo
					if (parametro.IndUnidadeVariacao.Equals("C")) {
						// Compara o consumo por economia ao consumo de retencao
                        result = (parametro.ValVariacaoRetencao.HasValue) &&
                                 (parametro.ValVariacaoRetencao.Value >= 0) &&
                                 (valConsumoEconomia >= parametro.ValVariacaoRetencao.Value);
						// Caso o parametro seja por percentual
					} else {
						// Compara o percentual ao limite
						result = (parametro.ValVariacaoRetencao.HasValue) &&
                                 (parametro.ValVariacaoRetencao.Value >= 0) &&
                                 (VariacaoConsumo(movimento) >= parametro.ValVariacaoRetencao.Value);
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Verifica se precisa ser emitido o aviso de variação para um OnpMovimento.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Se não tiver ValConsumoMedido ou não tiver ValConsumoMedio retorna false.</description></item>
		/// <item><description>Verifica se tem uma ocorrencia que força reter para análise, se tiver retorna true</description></item>
		/// <item><description>Caso contrário, se o IndSituacaoMovimento for igual a "C" e ValConsumoMedido for diferente de ValConsumoMedio e TipoCalculoConsumo for pela LeituraInformada:</description></item>
		/// <item><description>- Calcula o consumo por economia (valConsumoEconomia)</description></item>
		/// <item><description>- Chama ParametroRetencao() passando <paramref name="movimento"/> como parametro, guarda o resultado em parametro</description></item>
		/// <item><description>- Caso IndUnidadeVariacao de parametro seja "C"</description></item>
		/// <item><description>-- Retorna true se valConsumoEconomia for maior ou igual a ValVariacaoAviso de parametro</description></item>
		/// <item><description>- Caso IndUnidadeVariacao de parametro seja "P"</description></item>
		/// <item><description>-- Retorna true caso a valor retornado por VariacaoConsumo() que recebe como parametro movimento seja maior ou igual a ValVariacaoAviso de parametro</description></item>
		/// </list>
		/// </remarks>
		/// <param name="movimento">Movimento a ser analisado.</param>
		/// <returns>Retorna true caso deva emitir aviso de variação, caso contrário retorna false.</returns>
		protected virtual bool EmiteAvisoVariacao(OnpMovimento movimento) {
			// Consumo medido
			bool result = false;

			if (!movimento.ValConsumoMedido.HasValue)
				return result;

			// Calcula o consumo por economia
			int valConsumoEconomia = (int)(movimento.ValConsumoMedido.Value / movimento.TotalEconomias());

			// Calcula retencao apenas se já não reteve por ocorrencia e 
			// para quem tem media e quando o calculo é pela leitura informada
			if ((!result) &&
				(movimento.ValConsumoMedio.HasValue) &&
				(movimento.ValConsumoMedio.Value != movimento.ValConsumoMedido.Value) &&
				(movimento.TipoCalculoConsumo() == OnpOcorrencia.CalculoConsumo.LeituraInformada)) {

				// Busca o parametro de retencao para a media do consumo
				OnpParametroRetencao parametro = ParametroRetencao(movimento);

				// Caso tenha um parametro de retenção
				if (parametro != null && parametro.ValVariacaoAviso.HasValue) {
					// Caso o parametro seja por consumo
					if (parametro.IndUnidadeVariacao.Equals("C")) {
						// Compara o consumo por economia ao consumo de retencao
                        result = (parametro.ValVariacaoAviso.HasValue) &&
                                 (parametro.ValVariacaoAviso.Value >= 0) &&
                                 (valConsumoEconomia >= parametro.ValVariacaoAviso.Value);
						// Caso o parametro seja por percentual
					} else {
						// Compara o percentual ao limite
                        result = (parametro.ValVariacaoAviso.HasValue) &&
                                 (parametro.ValVariacaoAviso.Value >= 0) &&
                                 (VariacaoConsumo(movimento) >= parametro.ValVariacaoAviso.Value);
					} 
				}	 
			}

			return result;
		}

		/// <summary>
		/// Verifica qual o tipo de variação do movimento, caso este tenha uma variação.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Caso ValConsumoMedido seja maior que ValConsumoMedio retorna "A"</description></item>
		/// <item><description>Caso contrario retorna "D"</description></item>
		/// <item><description>Retorna uma string vazia caso ValConsumoMedido nao tenha valor</description></item>
		/// </list>
		/// </remarks>
		/// <param name="movimento">Movimento a ser analisado.</param>
		/// <returns>Retorna "A" para variação de acréscimo e "D" para variação de déscrimo ou uma string vazia caso nao tenha sido constatada variação.</returns>
		protected virtual string TipoVariacaoConsumo(OnpMovimento movimento) {
			if (movimento.ValConsumoMedido.HasValue)
				return (movimento.ValConsumoMedido > movimento.ValConsumoMedio ? "A" : "D");
			else
				return string.Empty;
		}

		/// <sumary>
		/// Calcula o numero total de economias das categorias
		/// </sumary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Retorna o somatorio ValNumeroEconomia de cada categoria do movimento recebido</description></item>
		/// </list>
		/// </remarks>
		/// <returns>Retorna o numero de economias calculado ou zero caso nao tenha nenhuma economias para o movimento em questão.</returns>
		protected virtual int TotalEconomias(OnpMovimento movimento) {
			int result = 0;

			foreach (OnpMovimentoCategoria categoria in movimento.MovimentosCategoria)
				result += categoria.ValNumeroEconomia.Value;

			return result;
		}

		/// <summary>
		/// Procura qual o parametro de retencao que se encaixa no movimento recebido como parâmetro.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Lista todos os OnpParametroRetencao que tem IndRetencao igual ao retorno de TipoVariacaoConsumo() passando <paramref name="movimento"/> como parametro</description></item>
		/// <item><description>Calcula o consumo medio por economia dividindo ValConsumoMedio de <paramref name="movimento"/> pelo valor retornado TotalEconomias() de movimento, guarda o resultado em <c>ValConsumoMedioEconomia</c></description></item>
		/// <item><description>Para cada OnpParametroRetencao encontrado:</description></item>
		/// <item><description>- Procura um OnpParametroRetencao que tem <c>ValConsumoMedioEconomia</c> maior que ValMediaInicial e <c>ValConsumoMedioEconomia</c> menor ou igual a ValMediaFinal</description></item>
		/// <item><description>- Retorna o OnpParametroRetencao encontrado ou null caso nao encontre.</description></item>
		/// </list>
		/// </remarks>
		/// <param name="movimento"></param>
		/// <returns>Retorna o parametro de retenção que melhor se encaixa no consumo medido do movimento recebido como parâmetro. Retorna nulo caso não encontre um parâmetro de retenção adequado.</returns>
		protected virtual OnpParametroRetencao ParametroRetencao(OnpMovimento movimento) {
			OnpParametroRetencao result = null;

			// Parametros de retencao para a categoria em questao para o consumo calculado			
			OnpParametroRetencao filtro = new OnpParametroRetencao();
			filtro.IndRetencao = TipoVariacaoConsumo(movimento);

			Collection<OnpParametroRetencao> parametros = filtro.SelectCollection();

			// Calcula a media por economia
			int valConsumoMedioEconomia = (int)(movimento.ValConsumoMedio.Value / movimento.TotalEconomias());

			foreach (OnpParametroRetencao parametro in parametros) {
				if (parametro.ValMediaInicial.HasValue && parametro.ValMediaFinal.HasValue) {
					// Caso o consumo esteja no intervalo do parametro
					if ((valConsumoMedioEconomia > parametro.ValMediaInicial.Value) &&
					   (valConsumoMedioEconomia <= parametro.ValMediaFinal.Value)) {
						result = parametro;
						break;
					}
				}
			}

			return result;
		}
		#endregion
	}
}
