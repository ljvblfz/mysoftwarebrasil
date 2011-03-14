using System;
using System.Text;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using Strategos.Api.Database.Impl;
using Strategos.Api.Log4CS;

namespace OnPlaceMovel.Source.CalculoTaxas {
	public class CalculaTaxasPadrao: ICalculaTaxas {
		#region Atributos
		/// <summary>
		/// Movimento com informações de leitura
		/// </summary>
		protected OnpMovimento _movimento;

		/// <summary>
		/// Fatura sendo calculada
		/// </summary>
		protected OnpFatura _fatura;

		protected bool _lancaMinimoNasTaxas;
		/// <summary>
		/// Indica se o consumo minimo deve ser colocado nas taxas
		/// </summary>
		public bool LancaMinimoNasTaxas {
			get { return _lancaMinimoNasTaxas; }
			set { _lancaMinimoNasTaxas = value; }
		}
		#endregion

		/// <summary>
		/// Construtor padrão
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Atribui null para _fatura e _movimento</description></item>
		/// </list>
		/// </remarks>
		public CalculaTaxasPadrao() {
			_fatura = null;
			_movimento = null;
		}

		/// <summary>
		/// Faz o calculo das taxas da categorias. Atualiza tanto o movimento quanto a fatura passados no construtor.
		/// </summary>
		/// <param name="movimento"></param>
		/// <param name="fatura"></param>
		/// <param name="distribuiConsumo"></param>
		public virtual void Calcular(OnpMovimento movimento, bool distribuiConsumo) {
			_movimento = movimento;
			CriarFatura(_movimento);

			// Distribui o consumo deste movimento entre as taxas da categoria da fatura
			if (distribuiConsumo) {
				DistribuirConsumo(_fatura);
				_movimento.IndSituacaoMovimento = "C";
			} else if (_fatura != null)
				SetTipoConsumo(_fatura);

			// Faz o calculo das taxas das categorias da fatura
			double valorTotal = CalcularCategorias() + geraFaturaServicos();

			if (_movimento.ValArredondaAnterior.HasValue)
				valorTotal -= _movimento.ValArredondaAnterior.Value;

			_fatura.ValValorFaturado = Arrendonda(valorTotal);
			_fatura.ValArredondaAtual = _fatura.ValValorFaturado - valorTotal;
			_fatura.ValValorCredito = 0.0;
			_fatura.Persist();

			_movimento.IndSituacaoMovimento = "F";
			_movimento.Persist();
		}

		#region Criação da Fatura
		public void CriarFatura(OnpMovimento movimento) {
			_fatura = new OnpFatura();
			_fatura.SeqFatura = OnpFatura.ProximoSequencial();
			_fatura.CodReferencia = movimento.CodReferencia;
			_fatura.SeqMatricula = movimento.SeqMatricula;
			_fatura.SeqRoteiro = movimento.SeqRoteiro;

			_fatura.Movimento = movimento;
			movimento.Fatura = _fatura;

			if (_fatura.Select())
				return;

			geraFaturaServicos();

			_fatura.ValImpressoes = movimento.ValImpressoes;
			_fatura.ValArredondaAnterior = movimento.ValArredondaAnterior;
			_fatura.ValQuantidadePendente = movimento.ValQuantidadePendente;

			_fatura.SeqRoteiro = movimento.SeqRoteiro;
			_fatura.CodHidrometro = movimento.CodHidrometro;

			_fatura.DatLeitura = movimento.DatLeitura;
			_fatura.DatVencimento = movimento.DatVencimento;
			_fatura.DatProximaLeitura = movimento.DatProximaLeitura;
			_fatura.DatLeituraAnterior = movimento.DatLeituraAnterior;

			_fatura.IndFaturaEmitida = movimento.IndFaturaEmitida;
			_fatura.IndEntregaEspecial = movimento.IndEntregaEspecial;

			_fatura.DesBancoDebito = movimento.DesBancoDebito;
			_fatura.DesBancoAgenciaDebito = movimento.DesBancoAgenciaDebito;

			_fatura.ValLeituraReal = movimento.ValLeituraReal;
			_fatura.ValLeituraAnterior = movimento.ValLeituraAnterior;
			_fatura.ValLeituraAtribuida = movimento.ValLeituraAtribuida;

			_fatura.ValConsumoMedio = movimento.ValConsumoMedio;
			_fatura.ValConsumoMedido = movimento.ValConsumoMedido;
			_fatura.ValConsumoAtribuido = movimento.ValConsumoAtribuido;
			_fatura.ValConsumoRateado = movimento.ValConsumoRateado;
			
			_fatura.ValArredondaAtual = 0.0;
			_fatura.ValDesconto = 0.0;
			_fatura.ValValorCredito = 0.0;
			
			CopiarCategorias(_fatura, movimento);
		}

		/// <summary>
		/// Copia as categorias do _movimento para a _fatura
		/// </summary>
		/// <param name="fatura">Fatura que vai receber as categorias</param>
		private void CopiarCategorias(OnpFatura fatura, OnpMovimento movimento) {
			OnpFaturaCategoria fc = new OnpFaturaCategoria();

			fc.SeqFatura = fatura.SeqFatura;
			fc.CodReferencia = fatura.CodReferencia;
			fc.SeqMatricula = fatura.SeqMatricula;
			fc.SeqRoteiro = fatura.SeqRoteiro;

			foreach (OnpMovimentoCategoria mc in movimento.MovimentosCategoria) {
				fc.SeqCategoria = mc.SeqCategoria;
				fc.ValNumeroEconomia = mc.ValNumeroEconomia;
				fc.Persist();

				CopiarTaxas(fc, mc);
			}
		}

		/// <summary>
		/// Copia as taxas de uma categoria de um movimento para uma categoria de uma fatura
		/// </summary>
		/// <param name="fatura"></param>
		/// <param name="mc"></param>
		private void CopiarTaxas(OnpFaturaCategoria fc, OnpMovimentoCategoria mc) {
			OnpFaturaTaxa ft = new OnpFaturaTaxa();

			ft.SeqFatura = fc.SeqFatura;
			ft.SeqCategoria = fc.SeqCategoria;
			ft.CodReferencia = fc.CodReferencia;
			ft.SeqMatricula = fc.SeqMatricula;
			ft.SeqRoteiro = fc.SeqRoteiro;

			foreach (OnpMovimentoTaxa mt in mc.Taxas) {
				ft.SeqTaxa = mt.SeqTaxa;
				ft.ValNumeroEconomia = mt.ValEconomias;
				ft.IndSituacao = mt.IndSituacao;
				ft.Persist();
			}
		}
		#endregion // Criação da Fatura

		#region Calculo das categorias, taxas e servicos
		/// <summary>
		/// Calculo o valor dos serviços que são de debito
		/// </summary>
		/// <param name="tipo">Tipo de serviço a ser calculado. Valores válidos são "D" (debito) ou "C"(crédito).</param>
		/// <returns>Retorna o valor total de servicos de debito.</returns>
		protected virtual double CalculaServicos(string tipo) {
			double retorno = 0.0;

			if (!tipo.Equals("D") && !tipo.Equals("C"))
				throw new Exception("Tipo de serviço inválido: " + tipo);

			foreach (OnpServicoFatura sf in _movimento.ServicosFatura)
				if (sf.IndCredito.Equals(tipo))
					retorno += sf.ValParcela.Value;

			return retorno;
		}

		/// <summary>
		/// Calcula o valor das taxas das categorias
		/// </summary>
		/// <returns></returns>
		protected virtual double CalcularCategorias() {
			double retorno = 0.0, valorCalculado = 0.0;
			OnpMovimentoCategoria mc;

			foreach (OnpFaturaCategoria fc in _fatura.Categorias) {
				valorCalculado = CalcularCategoria(fc);
				
				mc = new OnpMovimentoCategoria();
				mc.SeqCategoria = fc.SeqCategoria.Value;
				mc.CodReferencia = fc.CodReferencia;
				mc.SeqMatricula = fc.SeqMatricula.Value;
				mc.SeqRoteiro = fc.SeqRoteiro.Value;
				mc.Select();
				
				mc.ValValorFaturado = valorCalculado;
				mc.Persist();
				
				retorno += valorCalculado;
			}

			return retorno;
		}

		/// <summary>
		/// Calcula as taxas da categoria passada
		/// </summary>
		/// <param name="fc"></param>
		/// <returns>Retorna o somatorio do calculo das taxas</returns>
		protected virtual double CalcularCategoria(OnpFaturaCategoria fc) {
			double valorCalculado = 0.0;

			// Calcula as taxas na ordem fixa, calculada e por percentuais
			for (int i = 0; i < OnpTaxaTarifa.TiposTaxa.Length; i++)
				foreach (OnpFaturaTaxa taxa in fc.Taxas)
					if (GetTarifa(taxa, _movimento.Roteiro.DatBase.Value).Tipo == OnpTaxaTarifa.TiposTaxa[i])
						valorCalculado += CalcularTaxa(taxa);

			fc.ValValorFaturado = valorCalculado;
			fc.Persist();

			return valorCalculado;
		}

		/// <summary>
		/// Calculo o valor da taxa segundo as regras da taxa e da tarifa
		/// </summary>
		/// <param name="ft">Ta</param>
		/// <returns>Retorna o valor calculado da taxa</returns>
		protected virtual double CalcularTaxa(OnpFaturaTaxa ft) {
			// Verificando se precisa fazer calculo proporcional
			OnpTaxaTarifa ott = GetTarifa(ft, _movimento.Roteiro.DatBase.Value);

			if (ott.IndProporcional != null && ott.IndProporcional.Equals("S")) {
				Collection<OnpTaxaTarifa> lista = QueriesCE.procuraTarifa(_fatura.Movimento, ft.SeqCategoria.Value, ft.SeqTaxa.Value);

                if (lista.Count > 0) {
                    ft.ValValorCalculado = calculaProporcional(ft);
                } else {
                    ft.ValValorCalculado = calculaNaoProporcional(ft);
                }
			} else {
				ft.ValValorCalculado = calculaNaoProporcional(ft);
			}

			// Lança o valor faturado de acordo com a situação da taxa
			if (ft.Situacao == OnpFaturaTaxa.SituacaoTaxa.Ligado || ft.Situacao == OnpFaturaTaxa.SituacaoTaxa.Construcao || ft.Situacao == OnpFaturaTaxa.SituacaoTaxa.DesligadoCortado)
				ft.ValValorFaturado = ft.ValValorCalculado;
			else
				ft.ValValorFaturado = 0;

			ft.ValValorFaturado = Arrendonda(ft.ValValorFaturado.Value);
			ft.Persist();

			return ft.ValValorFaturado.Value;
		}

		/// <summary>
		/// Faz arredondando para duas casas decimais. Valores negativos sao arredondados para menos infinito e valores positivos para mais infinito.
		/// </summary>
		/// <param name="d">Valor a ser arredondado, pode ser positivo ou negativo.</param>
		/// <returns>Retorna o valor arredondando com duas casas decimais.</returns>
		public static double Arrendonda(double d) {
			return Arrendonda(d, 2);
		}

		/// <summary>
		/// Faz arredondando para o numero de casas decimais passado. Valores negativos sao arredondados para menos infinito e valores positivos para mais infinito.
		/// </summary>
		/// <param name="d">Valor a ser arredondado, pode ser positivo ou negativo.</param>
		/// <param name="casas">Numero de casas decimais</param>
		/// <returns>Retorna o valor arredondando.</returns>
		public static double Arrendonda(double d, int casas) {
			double divisor = Math.Pow(10, casas);
			double resultado = (int)(((Math.Abs(d) + 0.5d / divisor)) * divisor) / divisor;

			if (d < 0)
				return -resultado;

			return resultado;
		}

		/// <summary>
		/// Gera os serviços que estão no movimento para a fatura atual
		/// </summary>
		/// <returns></returns>
		protected virtual double geraFaturaServicos() {
			double result = 0;

			OnpFaturaServico fatServico = new OnpFaturaServico();

			fatServico.SeqFatura = _fatura.SeqFatura;
			fatServico.CodReferencia = _fatura.CodReferencia;
			fatServico.SeqRoteiro = _fatura.SeqRoteiro;
			fatServico.SeqMatricula = _fatura.SeqMatricula;

			foreach (OnpServicoFatura sf in _movimento.ServicosFatura) {
				fatServico.SeqItemServico = sf.SeqItemServico;
				fatServico.DesServico = sf.DesServico;
				fatServico.SeqParcela = sf.SeqParcela;
				fatServico.ValParcela = sf.ValParcela;
				fatServico.IndCredito = sf.IndCredito;
				fatServico.Persist();

				result += fatServico.ValParcela.Value;
			}

			return result;
		}
		#endregion

		#region Metodos de manipulacao de calculo da taxa
		protected virtual double calculaProporcional(OnpFaturaTaxa ft) {
			DateTime data1 = _movimento.DatLeituraAnterior.Value.Date;
			DateTime data2 = _movimento.DatLeitura.Value.Date;

			OnpTaxaTarifa tarifa1 = GetTarifa(ft, data1);
			OnpTaxaTarifa tarifa2 = GetTarifa(ft, data2);

			double valor1 = calcularTarifa(ft, tarifa1);
			double valor2 = calcularTarifa(ft, tarifa2);

			TimeSpan totalDias = data2.Subtract(data1);
			TimeSpan dias1 = data1.Subtract(tarifa1.DatInicio.Value.Date);
			TimeSpan dias2 = data2.Subtract(tarifa2.DatInicio.Value.Date);

			return ((valor1 * dias1.Days) + (valor2 * dias2.Days)) / totalDias.Days;
		}

		protected virtual double calculaNaoProporcional(OnpFaturaTaxa ft) {
			return calcularTarifa(ft, GetTarifa(ft, _movimento.Roteiro.DatBase.Value));
		}

		protected virtual double calcularTarifa(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa) {
			double retorno = 0.0;

			// Calcula o valor de acordo com o tipo
			switch (tarifa.Tipo) {
				case OnpTaxaTarifa.TipoTaxa.Fixo:
					calculaValorTaxaFixo(ft, tarifa);
					break;

				case OnpTaxaTarifa.TipoTaxa.Calculado:
					calculaValorTaxaCalculado(ft, tarifa);
					break;

				case OnpTaxaTarifa.TipoTaxa.Percentual:
					calculaValorTaxaPercentual(ft, tarifa);
					break;
			}

			retorno = ft.ValValorCalculado.Value;

			return retorno;
		}

		/// <summary>
		/// Calcula o valor de taxas com valor calculado com base em consumo
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="tarifa"></param>
		protected virtual void calculaValorTaxaCalculado(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa) {
			// Tabela de faixas
			Collection<OnpTaxaTarifa.FaixaTarifa> faixas = tarifa.CopyFaixas();

			// Ajusta a tabela

			// Minimo
			if (tarifa.IndMinimo.Equals("S"))
				faixas[0].ValValorTarifa *= ft.ValNumeroEconomia.Value;

			// Faixas
			for (int i = 0; i < faixas.Count; i++)
				faixas[i].ValLimiteConsumo *= ft.ValNumeroEconomia.Value;

			// Dias de consumo
			if (tarifa.IndDiasConsumo.Equals("S")) {
				int diasDeConsumo = (int)(_fatura.DatLeitura.Value - _fatura.DatLeituraAnterior.Value).TotalDays;

				// Minimo
				if (tarifa.IndMinimo.Equals("S"))
					faixas[0].ValValorTarifa *= (diasDeConsumo / 30);

				// Faixas
				for (int i = 0; i < faixas.Count; i++)
					faixas[i].ValLimiteConsumo *= (diasDeConsumo / 30);
			}

			// Verifica se deve calcular escalonado ou não
			if (tarifa.IndEscalonada.Equals("S"))
				calculaValorTaxaCalculadoEscalonado(ft, tarifa, faixas);
			else
				calculaValorTaxaCalculadoNaoEscalonado(ft, faixas);
		}

		/// <summary>
		/// Calcula o valor de taxas com o valor calculado com base em percentual de outra taxa
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="tarifa"></param>
		protected virtual void calculaValorTaxaPercentual(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa) {
			// Localiza a taxa base
			OnpFaturaTaxa fatTaxaBase = buscaTaxaBase(ft);
			ft.ValValorCalculado = (fatTaxaBase.ValValorCalculado.Value * tarifa.ValPercentual.Value) / 100.0;
			ft.ValConsumoFaturado = fatTaxaBase.ValConsumoFaturado.Value;
		}

		/// <summary>
		/// Calcula o valor da taxa calculada com base no consumo atraves de tabela escalonada
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="tarifa"></param>
		/// <param name="faixas"></param>
		protected virtual void calculaValorTaxaCalculadoEscalonado(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa, Collection<OnpTaxaTarifa.FaixaTarifa> faixas) {
			int consumoRestante = ft.ValConsumoFaturado.Value;
			int consumoCalculo = 0;
			double valorCalculado = 0;

			// Primeira faixa (Pode ser minimo...)
			// Consumo a utilizar para calculo
			consumoCalculo = (consumoRestante > faixas[0].ValLimiteConsumo ? faixas[0].ValLimiteConsumo : consumoRestante);

			// Consumo restante a ser calculado
			consumoRestante -= consumoCalculo;

			// Tem minimo
			if (tarifa.IndMinimo.Equals("S"))
				valorCalculado += faixas[0].ValValorTarifa;
			else
				valorCalculado += (faixas[0].ValValorTarifa * consumoCalculo);

			// Demais faixas
			int intervaloFaixa;
			for (int i = 1; i < faixas.Count && consumoRestante > 0; i++) {
				// Consumo a utilizar para calculo
				intervaloFaixa = faixas[i].ValLimiteConsumo - faixas[i - 1].ValLimiteConsumo;

				//Consumo para o calculo
				consumoCalculo = (consumoRestante > intervaloFaixa ? intervaloFaixa : consumoRestante);

				// Consumo restante a ser calculado
				consumoRestante -= consumoCalculo;

				// Valor calculado
				valorCalculado += (faixas[i].ValValorTarifa * consumoCalculo);
			}

			// Lanca os valores
			ft.ValValorCalculado = valorCalculado;
		}

		/// <summary>
		/// Calcula o valor da taxa calculada com base no consumo atraves de tabela nao escalonada
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="faixas"></param>
		protected virtual void calculaValorTaxaCalculadoNaoEscalonado(OnpFaturaTaxa ft, Collection<OnpTaxaTarifa.FaixaTarifa> faixas) {
			// Seleciona a faixa a ser utilizada para o calculo
			OnpTaxaTarifa.FaixaTarifa faixaConsumo = null;

			// Busca a faixa
			for (int i = 0; i < faixas.Count; i++)
				if (faixas[i].ValLimiteConsumo > ft.ValConsumoFaturado.Value) {
					faixaConsumo = faixas[i];
					break;
				}

			// Calcula o total
			ft.ValValorCalculado = (faixaConsumo.ValValorTarifa + ft.ValConsumoFaturado.Value);
		}

		/// <summary>
		/// Localiza a taxa base
		/// </summary>
		/// <param name="ft"></param>
		/// <returns></returns>
		protected virtual OnpFaturaTaxa buscaTaxaBase(OnpFaturaTaxa ft) {
			OnpFaturaTaxa result = null;
			OnpTaxaTarifa tarifa = GetTarifa(ft, _movimento.Roteiro.DatBase.Value);

			result = OnpFaturaTaxa.Materialize(tarifa.SeqTaxaBase.Value, ft.SeqCategoria.Value, ft.SeqFatura.Value, ft.SeqRoteiro.Value, ft.SeqMatricula.Value, ft.CodReferencia);

			return result;
		}

		/// <summary>
		/// Calcula o valor de taxas com valor fixo
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="tarifa"></param>
		protected virtual void calculaValorTaxaFixo(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa) {
			ft.ValValorCalculado = tarifa.ValValorTarifa;
			ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Fixo;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ft"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		protected virtual OnpTaxaTarifa GetTarifa(OnpFaturaTaxa ft, DateTime data) {
			return ft.Taxa.GetTarifa(ft.SeqCategoria.Value, data);
		}
		#endregion

		#region	Ajuste do tipo de consumo
		/// <summary>
		/// Passa por todas as taxas para atribuir o tipo de consumo de cada taxa
		/// </summary>
		/// <param name="fatura"></param>
		protected virtual void SetTipoConsumo(OnpFatura fatura) {
			OnpMovimentoTaxa mt;

			foreach (OnpFaturaCategoria fc in fatura.Categorias) {
				foreach (OnpFaturaTaxa ft in fc.Taxas) {
					mt = new OnpMovimentoTaxa();
					mt.SeqRoteiro = fatura.SeqRoteiro;
					mt.SeqMatricula = fatura.SeqMatricula;
					mt.CodReferencia = fatura.CodReferencia;
					mt.SeqTaxa = ft.SeqTaxa;
					mt.SeqCategoria = ft.SeqCategoria;

					if (mt.Select()) {
						// Verifica se a taxa tem um consumo estimado ou fixo, se não tiver vai distribuir o consumo
						if (mt.ValConsumoEstimado.HasValue)
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Estimado;
						else if (mt.ValConsumoFixo.HasValue)
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Fixo;
						else if (_movimento.ValConsumoAtribuido.HasValue)
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Atribuido;
						else
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Lido;

						ft.Persist();
					}
				}
			}
		}
		#endregion

		#region Distribuição de Consumo
		/// <summary>
		/// Faz o somatorio de total de economias de todas as categorias para uma taxa
		/// </summary>
		/// <param name="taxa">Taxa que vai ser procurar para soma numero de economias</param>
		/// <param name="movimento">movimente com as categorias</param>
		/// <returns>Retorna o numero de categorias</returns>
		protected int TotalEconomias(OnpTaxa taxa, OnpMovimento movimento) {
			int totalEconomias = 0;

			foreach (OnpMovimentoCategoria mc in movimento.MovimentosCategoria)
				foreach (OnpMovimentoTaxa mt in mc.Taxas)
					if (mt.SeqTaxa.Equals(taxa.SeqTaxa))
						totalEconomias += mt.ValEconomias.Value;

			return totalEconomias;
		}

		/// <summary>
		/// Distribui o consumo passado entre as taxas de cada categoria desta fatura
		/// </summary>
		/// <param name="fatura"></param>
		protected virtual void DistribuirConsumo(OnpFatura fatura) {
			OnpMovimentoTaxa mt;
			OnpRoteiro roteiro = new OnpRoteiro(_movimento.SeqRoteiro);
			int nrEconomias = _movimento.GetTotalEconomias();

			foreach (OnpFaturaCategoria fc in fatura.Categorias) {
				foreach (OnpFaturaTaxa ft in fc.Taxas) {
					mt = new OnpMovimentoTaxa();
					mt.SeqRoteiro = fatura.SeqRoteiro;
					mt.SeqMatricula = fatura.SeqMatricula;
					mt.CodReferencia = fatura.CodReferencia;
					mt.SeqTaxa = ft.SeqTaxa;
					mt.SeqCategoria = ft.SeqCategoria;

					if (mt.Select()) {
						// Verifica se a taxa tem um consumo estimado ou fixo, se não tiver vai distribuir o consumo
						if (_lancaMinimoNasTaxas) {
							ft.ValConsumoFaturado = ft.GetTarifa(roteiro.DatBase.Value).ConsumoMinimo() * nrEconomias;
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Atribuido;
						} else if (mt.ValConsumoEstimado.HasValue) {
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Estimado;
							ft.ValConsumoFaturado = mt.ValConsumoEstimado;
						} else if (mt.ValConsumoFixo.HasValue) {
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Fixo;
							ft.ValConsumoFaturado = mt.ValConsumoFixo;
						} else if (_movimento.ValConsumoAtribuido.HasValue) {
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Atribuido;
							DistribuirConsumo(ft, ft.TipoDoConsumo, _movimento.ValConsumoAtribuido.Value + _movimento.ValConsumoRateado.GetValueOrDefault(0));
						} else { // if (_movimento.ValConsumoMedido.HasValue) {
							ft.TipoDoConsumo = OnpFaturaTaxa.TipoConsumo.Lido;
							DistribuirConsumo(ft, ft.TipoDoConsumo, _movimento.ValConsumoMedido.GetValueOrDefault(0) + _movimento.ValConsumoRateado.GetValueOrDefault(0));
						}

						// Verifica se o consumo não é menor que o minimo
						int consumoMinimo = QueriesCE.ConsumoMinimo(ft.SeqTaxa.Value, ft.SeqCategoria.Value, _movimento.Roteiro.DatBase.Value) * ft.ValNumeroEconomia.Value;
						if (ft.ValConsumoFaturado < consumoMinimo)
							ft.ValConsumoFaturado = consumoMinimo;

						ft.Persist();
					}
				}
			}
		}

		/// <summary>
		/// Distribui o consumo para a taxa especifica
		/// </summary>
		/// <param name="taxa"></param>
		/// <param name="tipoConsumo"></param>
		/// <param name="consumoFaturar"></param>
		protected virtual void DistribuirConsumo(OnpFaturaTaxa taxa, OnpFaturaTaxa.TipoConsumo tipoConsumo, int consumoFaturar) {
			int consumoFaturado = 0, totalEconomias = TotalEconomias(taxa.Taxa, _movimento);

			// Distribui o consumo para as taxas q sao iguais a taxa recebida como parâmetro
			OnpFaturaTaxa taxaComMaisEconomias = null;
			foreach (OnpFaturaCategoria fc in _fatura.Categorias) {
				foreach (OnpFaturaTaxa ft in fc.Taxas) {
					if (ft.SeqTaxa.Equals(taxa.SeqTaxa)) {
						if (taxaComMaisEconomias == null || ft.ValNumeroEconomia > taxaComMaisEconomias.ValNumeroEconomia)
							taxaComMaisEconomias = ft;

						if (!ft.ValConsumoFaturado.HasValue) {
							consumoFaturado += (consumoFaturar * ft.ValNumeroEconomia.Value) / totalEconomias;
							ft.ValConsumoFaturado = consumoFaturado;
						}

						ft.TipoDoConsumo = tipoConsumo;
						break;
					}
				}
			}

			// Verifica se foi distribuido todo o consumo
			if (taxaComMaisEconomias != null && taxaComMaisEconomias.ValConsumoFaturado.HasValue && consumoFaturado < consumoFaturar) {
				// Caso não tenha sido, a taxa com o maior numero de categorias recebe a diferença de consumo
				taxaComMaisEconomias.ValConsumoFaturado += (consumoFaturar - consumoFaturado);
			}
		}
		#endregion
	}
}
