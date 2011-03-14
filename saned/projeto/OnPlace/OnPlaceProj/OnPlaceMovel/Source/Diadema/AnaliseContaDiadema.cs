using System;
using System.Text;
using System.Collections.Generic;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.CalculoTaxas;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Diadema {
	public class AnaliseContaDiadema: AnaliseConta {
		#region Atributos e Propriedades
		private OnpMatriculaDiadema _matriculaDiadema;
		#endregion

		public AnaliseContaDiadema() {
		}

		#region Metodos protegidos
		/// <summary>
		/// Trata os casos especificosde retencao ou não de conta para diadema
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado</param>
		/// <returns>Retorna true caso deve reter, caso contrario retorna.</returns>
		protected override bool RetemParaAnaliseinterno(OnpMovimento movimento) {
			bool chamarReteminterno = true;
			bool result = false;

			// Caso 1
			if (movimento.Hidrometro != null && movimento.Hidrometro.ValNumeroDigitos == 4 &&
				movimento.ValLeituraReal < movimento.ValLeituraAnterior && //EmiteAvisoVariacao(movimento) &&
				movimento.ValConsumoMedido < movimento.LeituraMaxima() &&
				movimento.ValConsumoMedido > movimento.LeituraMaxima() - 50) {
				VerificaOcorrencias(movimento, true);
				chamarReteminterno = false;
			}

			// Caso 2
			else if (movimento.ValLeituraAnterior == movimento.ValLeituraReal) {
				VerificaOcorrencias(movimento, false);
				chamarReteminterno = false;
			}

			// Caso 3
            // Solicitado para retirar a regra em 10/11/2008
            // if (movimento.ValConsumoMedio.Value == 0)
            //     return false;

            // Caso 4
            if (movimento.ValLeituraAnterior.Value == 0)
				return false;

			if (chamarReteminterno) {
                CalculaTaxasDiadema.AjustarConsumoLeitura(CalculaTaxasDiadema.DiasDeConsumo, CalculaTaxasDiadema.DiasDeConsumoMax, _matriculaDiadema, movimento, movimento.Fatura);
				result = RetemParaAnaliseinterno2(movimento);
			}

			return result;
		}

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
		private bool RetemParaAnaliseinterno2(OnpMovimento movimento) {
			// Consumo medido
			bool result = false;

			if (!movimento.ValConsumoMedido.HasValue || !movimento.ValConsumoMedio.HasValue)
				return false;

			// Caso tenha ocorrencia que retem para analise
			result = (movimento.ocorrenciaRetemAnalise() != null);

			// Calcula o consumo por economia
			int valConsumoEconomia;

			if (movimento.ValConsumoMedido.HasValue && movimento.ValConsumoAtribuido.HasValue)
				valConsumoEconomia = (int)(movimento.ValConsumoAtribuido.Value / TotalEconomias(movimento));
			else
				valConsumoEconomia = (int)(movimento.ValConsumoMedido.Value / TotalEconomias(movimento));

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
		public override int VariacaoConsumo(OnpMovimento movimento) {
			double variacaoPercentual = 0.0;

			// Verifica se é acrescimo ou decrescimo
			string tipoVariacao = TipoVariacaoConsumo(movimento);

			int consumo;
			if (movimento.ValConsumoMedido.HasValue && movimento.ValConsumoAtribuido.HasValue)
				consumo = movimento.ValConsumoAtribuido.Value;
			else
				consumo = movimento.ValConsumoMedido.Value;

			int variacaoConsumo = (int)(tipoVariacao.Equals("A") ? (consumo - movimento.ValConsumoMedio.Value) : (movimento.ValConsumoMedio.Value - consumo));
			if (!movimento.ValConsumoMedio.HasValue || movimento.ValConsumoMedio.Value == 0)
				variacaoPercentual = (variacaoConsumo * 100.0);
			else
				variacaoPercentual = ((double)variacaoConsumo / movimento.ValConsumoMedio.Value) * 100.0;

			return (int)variacaoPercentual;
		}

		/// <summary>
		/// Verifica qual o tipo de variação do movimento, caso este tenha uma variação.
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado.</param>
		/// <returns>Retorna "A" para variação de acréscimo e "D" para variação de déscrimo ou uma string vazia caso nao tenha sido constatada variação.</returns>
		protected override string TipoVariacaoConsumo(OnpMovimento movimento) {
			if (!movimento.ValConsumoMedido.HasValue)
				return string.Empty;

			int consumo;
			if (movimento.ValConsumoMedido.HasValue && movimento.ValConsumoAtribuido.HasValue)
				consumo = movimento.ValConsumoAtribuido.Value;
			else
				consumo = movimento.ValConsumoMedido.Value;

			return (consumo > movimento.ValConsumoMedio ? "A" : "D");
		}

		/// <summary>
		/// Verifica se deve ou nao emitir aviso de variação
		/// </summary>
		/// <returns>Retorna true se deve emitir aviso de retenção, caso contrário retorna false.</returns>
		public override bool EmiteAvisoVariacao(OnpMatricula matricula) {
			return EmiteAvisoVariacao(matricula.Movimento);
		}
		#endregion

		#region Metodos Privados
		protected override OnpParametroRetencao ParametroRetencao(OnpMovimento movimento) {
			OnpParametroRetencao result = null;

			// Parametros de retencao para a categoria em questao para o consumo calculado			
			OnpParametroRetencao filtro = new OnpParametroRetencao();
			filtro.IndRetencao = TipoVariacaoConsumo(movimento);

			Collection<OnpParametroRetencao> parametros = filtro.SelectCollection();

			int valConsumo;// = movimento.ValConsumoMedido.Value;
			if (movimento.ValConsumoMedido.HasValue && movimento.ValConsumoAtribuido.HasValue)
				valConsumo = movimento.ValConsumoAtribuido.Value;
			else
				valConsumo = movimento.ValConsumoMedido.Value;

			foreach (OnpParametroRetencao parametro in parametros) {
				if (parametro.ValMediaInicial.HasValue && parametro.ValMediaFinal.HasValue) {
					// Caso o consumo esteja no intervalo do parametro
					if (valConsumo > parametro.ValMediaInicial.Value && valConsumo <= parametro.ValMediaFinal.Value) {
						result = parametro;
						break;
					}
				}
			}

			return result;
		}
		#endregion

		#region Metodos estaticos
		/// <summary>
		/// Verifica se o movimento tem ocorrencias 12, 13 ou 17, caso tenha o consumo medio da ligacao sera usado para calcular as taxas
		/// Caso contrario sera o consumo Minimo e neste caso também é gerado ocorrencia 77 no movimento.
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado.</param>
		/// <param name="cobraMinimo">Caso seja true, valLeituraAtribuida = valLeituraAnterior e valConsumoAtribuido = 0.</param>
		private static void VerificaOcorrencias(OnpMovimento movimento, bool cobraMinimo) {
			if (TemOcorrencias(movimento)) {
				// a) emitir fatura pelo consumo medio
				if (cobraMinimo)
					movimento.ValConsumoAtribuido = 0; // minimo
				else
					movimento.ValConsumoAtribuido = movimento.ValConsumoMedio; // media
				
				movimento.ValLeituraAtribuida = movimento.ValLeituraAnterior;
				movimento.Persist();
			} else {
				// b) emitir fatura pelo consumo minimo
				GerarOcorrencia(movimento);
				movimento.LancaMinimoNasTaxas = true;
			}
		}

		/// <summary>
		/// Gera ocorrencia 77 para o movimento passado, caso ela nao exista ainda
		/// </summary>
		/// <param name="movimento">Movimento no qual se deve acrescentar a ocorrência.</param>
		private static void GerarOcorrencia(OnpMovimento movimento) {
			OnpMovimentoOcorrencia ocorrencia;
			int codOcorrencia = 77; // Regra passada

			// Verifica se ja tem ocorrencia, se tiver remove
			for (int i = 0; i < movimento.MovimentosOcorrencia.Count; i++)
				if (movimento.MovimentosOcorrencia[i].CodOcorrencia.Equals(codOcorrencia)) {
					movimento.MovimentosOcorrencia[i].Remove();
					movimento.MovimentosOcorrencia.RemoveAt(i);
					break;
				}

			// Deslocando ocorrencias existentes para a 77 ser a primeira
			int seqSequencial = 2;
			foreach (OnpMovimentoOcorrencia mo in movimento.MovimentosOcorrencia) {
				mo.Remove();
				mo.SeqSequencial = seqSequencial++;
				mo.Persist();
			}

			// Cria e adiciona ocorrencia
			ocorrencia = new OnpMovimentoOcorrencia();
			ocorrencia.CodOcorrencia = codOcorrencia;
			ocorrencia.CodReferencia = movimento.CodReferencia;
			ocorrencia.SeqMatricula = movimento.SeqMatricula;
			ocorrencia.SeqRoteiro = movimento.SeqRoteiro;
			ocorrencia.SeqSequencial = 1;
			ocorrencia.Persist();

			movimento.MovimentosOcorrencia.Add(ocorrencia);

			movimento.LancaMinimoNasTaxas = true;
			movimento.ValConsumoAtribuido = 0;
			movimento.ValLeituraAtribuida = movimento.ValLeituraAnterior;
			movimento.Persist();
		}

		/// <summary>
		/// Verifica se o movimento em questao tem as ocorrencias 12, 13 ou 17
		/// </summary>
		/// <param name="movimento">Movimento a ser analisado</param>
		/// <returns>Retorna true caso o movimento recebido como parâmetro tenhas as ocorrências, caso contrário retorna false.</returns>
		private static bool TemOcorrencias(OnpMovimento movimento) {
			bool achouOcorrencia = false;

			foreach (OnpMovimentoOcorrencia mo in movimento.MovimentosOcorrencia) {
				if (mo.CodOcorrencia == 12 || mo.CodOcorrencia == 13 || mo.CodOcorrencia == 17) {
					achouOcorrencia = true;
					break;
				}
			}

			return achouOcorrencia;
		}
		#endregion

		#region Metodos Publicos
		public override bool RetemParaAnalise(OnpMovimento movimento) {
			bool result = false;
			string situacaoMovimento = movimento.IndSituacaoMovimento;

			_matriculaDiadema = new OnpMatriculaDiadema(movimento.SeqMatricula.Value);
			if (!movimento.DatLeitura.HasValue)
				movimento.DatLeitura = DateTime.Now;

			if (!movimento.IndSituacaoMovimento.Equals("R"))
				result = RetemParaAnaliseinterno(movimento);

			if (movimento.GetPrimeiraOcorrencia() != null && movimento.GetPrimeiraOcorrencia().Ocorrencia.TipoCalculoConsumo == OnpOcorrencia.CalculoConsumo.SeMediaZeroCobraMinimoSenaoRetem && movimento.ValConsumoMedio.Value > 0)
				result = true;

			// Atualiza a situação
			if (result) {
				movimento.IndSituacaoMovimento = "R";
				movimento.Persist();
			}

			// Nunca retem comunitarios
			if (result && (_matriculaDiadema.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.HDComunitario)) {
				movimento.IndSituacaoMovimento = situacaoMovimento;
				movimento.Persist();
			}

			return movimento.IndSituacaoMovimento.Equals("R");
		}
		#endregion // Metodos Publicos
	}
}
