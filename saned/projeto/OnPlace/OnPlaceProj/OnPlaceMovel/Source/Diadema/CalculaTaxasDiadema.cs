using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Strategos.Api.Log4CS;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.CalculoTaxas;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Diadema {
	#region Lista de Faixa/Consumo/Valor
	public struct FaixaConsumoValor {
		public bool minimo;
		public int faixa;
		public int consumo;
		public double tarifa;
		public double valor;

		public FaixaConsumoValor(bool m, int f, int c, double t, double v) {
			minimo = m;
			faixa = f;
			consumo = c;
			tarifa = t;
			valor = v;
		}
	}

	public class FCVCollection: Collection<FaixaConsumoValor> {
	}
	#endregion Lista de Faixa/Consumo/Valor

	public class CalculaTaxasDiadema: CalculaTaxasPadrao {
		#region Atributos
        public const int DiasDeConsumo = 31;
        public const int DiasDeConsumoMax = 40;
		private bool _redistribuirConsumo;

		private ProgressoController _progresso = new ProgressoController(false);

		private OnpMatriculaDiadema _matricula;
		public OnpMatriculaDiadema MatriculaDiadema {
			get {
				return _matricula;
			}
			set {
				_matricula = value;
			}
		}

		public OnpMovimento Movimento {
			get {
				return _movimento;
			}
			set {
				_movimento = value;
			}
		}

		public OnpFatura Fatura {
			get {
				return _fatura;
			}
			set {
				_fatura = value;
			}
		}

		private bool _distribuiConsumo;
		public bool DistribuiConsumo {
			get {
				return _distribuiConsumo;
			}
			set {
				_distribuiConsumo = value;
			}
		}

		private static int _ultimoSeqMatricula = -1;
		public static int UltimoSeqMatricula {
			get {
				return _ultimoSeqMatricula;
			}
		}

		private static FCVCollection _fcvs = new FCVCollection();
		public static FCVCollection FCV {
			get {
				return _fcvs;
			}
		}
		#endregion

		#region Calculo Normal de Fatura
		public void CalculaNormal(OnpMatriculaDiadema matricula, string submensagem) {
			if (matricula.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaNF)) {
				matricula.MatriculaPai.Matricula.Movimento.IndSituacaoMovimento = "P";
				matricula.MatriculaPai.Matricula.Movimento.Fatura = null;
				matricula.MatriculaPai.Matricula.Movimento.Persist();
				_movimento.Fatura = null;
				return;
			}

			// Verificando se precisa fazer calculo da fatura
			if (!string.IsNullOrEmpty(matricula.IndCalculaFatura) && matricula.IndCalculaFatura.Equals("N"))
				return;

			if (string.IsNullOrEmpty(submensagem))
				submensagem = string.Empty;

			_progresso.valorMin = 0;
			_progresso.valorMax = 7;
			_progresso.Posicao = 0;
			_progresso.Mensagem = "Inicio do calculo" + submensagem;
			_progresso.Show();
			_progresso.Refresh();

			// Salva os atributos atuais
			OnpMatriculaDiadema matAtual = _matricula;
			OnpMovimento movAtual = _movimento;
			OnpFatura fatAtual = _fatura;
			bool restaurar = false;

			// Muda os atributos da classe para os da matricula passada
			if (_matricula == null || _matricula.SeqMatricula.Value != matricula.SeqMatricula.Value) {
				_matricula = matricula;
				_movimento = matricula.Matricula.Movimento;
				_fatura = matricula.Matricula.Movimento.Fatura;
				restaurar = true;
			}

			_progresso.Mensagem = "Ajustando Leitura (caso necessario)" + submensagem;
			_progresso.Posicao++;
			_progresso.Refresh();

            AjustarConsumoLeitura(CalculaTaxasDiadema.DiasDeConsumo, CalculaTaxasDiadema.DiasDeConsumoMax, matricula, _movimento, _fatura);

			if (!((matricula.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3 ||
				matricula.MatriculaPai.IndTipoConsumidor == OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8) &&
				matricula.isFilho)) {

				_fcvs.Clear();

				_progresso.Mensagem = "Criando fatura" + submensagem;
				_progresso.Posicao++;
				_progresso.Refresh();

				CriarFatura(_movimento);

				_progresso.Mensagem = "Distribuindo consumo" + submensagem;
				_progresso.Posicao++;
				_progresso.Refresh();

				// Distribui o consumo deste movimento entre as taxas da categoria da fatura
				if (_distribuiConsumo)
					DistribuirConsumo();
				else if (_fatura != null)
					SetTipoConsumo(_fatura);

				_progresso.Mensagem = "Calculando categorias" + submensagem;
				_progresso.Posicao++;
				_progresso.Refresh();

				// Faz o calculo das taxas das categorias da fatura
				geraFaturaServicos();
				double valorCreditos = CalculaServicos("C");
				double valorDebitos = CalcularDesconto(matricula, CalcularCategorias()) + CalculaServicos("D");
				double valorTotal = 0.0;
				double valorTotalSemImposto = 0.0;

				_progresso.Mensagem = "Verificando creditos/debitos/impostos" + submensagem;
				_progresso.Posicao++;
				_progresso.Refresh();

				// Verificando créditos e debitos
				// Valores de credito sao negativos
				if (Math.Abs(valorCreditos) > valorDebitos) {
					valorTotal = 0.0;
					_fatura.ValValorCredito = Arrendonda(valorDebitos + valorCreditos);
				} else {
					valorTotal = valorDebitos + valorCreditos;
					_fatura.ValValorCredito = 0.0;

					if (!string.IsNullOrEmpty(_matricula.IndRetencaoImpostos) && _matricula.IndRetencaoImpostos.Equals("S"))
						valorTotalSemImposto = CalculaImpostos(valorTotal);

					valorTotal -= valorTotalSemImposto;
				}

				_fatura.ValValorFaturado = Arrendonda(valorTotal);

				if (_fatura.ValValorFaturado < AchaValorParaMinimo() && _fatura.ValValorFaturado.Value > 0.0) {
					_fatura.ValValorCredito = _fatura.ValValorFaturado;
					_fatura.ValValorFaturado = 0.0;
				}

				_progresso.Mensagem = "Gerando codigo de barras" + submensagem;
				_progresso.Posicao++;
				_progresso.Refresh();

				_fatura.geraCodigoBarrasELinhaDigitavel();
				_fatura.Persist();

				_movimento.IndSituacaoMovimento = "F";
				_movimento.Persist();

				_matricula.Matricula.IndProcessado = "S";
				_matricula.Matricula.Persist();
			}

			_progresso.Mensagem = "Fim do calculo" + submensagem;
			_progresso.Posicao++;
			_progresso.Refresh();

			// Restaura os atributos da classe, caso necessario
			if (restaurar) {
				_matricula = matAtual;
				_movimento = movAtual;
				_fatura = fatAtual;
			}

			_progresso.Hide();
		}

		/// <summary>
		/// Acha o valor minimo para a conta (soma do minimo das categorias)
		/// </summary>
		/// <returns>Retorna o valor double com o minimo que deve ser cobrado.</returns>
		private double AchaValorParaMinimo() {
			double result = 0, minimo = 0;



			foreach (OnpMovimentoCategoria mc in _movimento.MovimentosCategoria) {
				foreach (OnpMovimentoTaxa mt in mc.Taxas) {
                    if (mt.IndSituacao.Equals("1") || mt.IndSituacao.Equals("2")) { // Considera taxas com estado de ligada, alterado 25/09/08
                        minimo = mt.GetTarifa(_movimento.DatLeituraAnterior.Value).ValorMinimo(); // Busca a tarifa mínima com base da data de leitura anterior e não mais pela data base do roteiro, alterando 15/12/08
                        if (minimo > 0) {
                            result += minimo;
                            // Comentado para considerar todas as taxas qd da categoria
                            //break;
                        }
                    }
				}
			}

			return Arrendonda( result );
		}

		private void DistribuirConsumo() {
			DistribuirConsumo(_fatura);
			_matricula.Matricula.Movimento.IndSituacaoMovimento = "C";
		}
		#endregion

		#region Calculo de Descontos e Impostos
		/// <summary>
		/// Verifica se precisa calcular o desconto para a matricula recebida sobre o valor recebido
		/// </summary>
		/// <param name="matricula"></param>
		/// <param name="valorTotal"></param>
		/// <returns>Retorna o valor com o desconto aplicado.</returns>
		private double CalcularDesconto(OnpMatriculaDiadema matricula, double valorTotal) {
			int consumo = 0;

			if (matricula.Matricula.Movimento.ValConsumoAtribuido.HasValue)
				consumo = matricula.Matricula.Movimento.ValConsumoAtribuido.Value;
			else if (matricula.Matricula.Movimento.ValConsumoMedido.HasValue)
				consumo = matricula.Matricula.Movimento.ValConsumoMedido.Value;

			consumo += matricula.Matricula.Movimento.ValConsumoRateado.GetValueOrDefault(0);

			if (matricula.DescontoDiadema == null || consumo < matricula.DescontoDiadema.ValLimiteInicial)
				return valorTotal;

			double valorDoDesconto = 0.0;

			if (matricula.DescontoDiadema.IndTipoDesconto.Equals("1"))
				valorDoDesconto = Arrendonda(CalcularDescontoExcente(matricula, valorTotal));
			else if (matricula.DescontoDiadema.IndTipoDesconto.Equals("2"))
				valorDoDesconto = Arrendonda(CalcularDescontoTotal(matricula, valorTotal));
			else if (matricula.DescontoDiadema.IndTipoDesconto.Equals("0"))
				valorDoDesconto = 0.0; // nao tem desconto

			_fatura.ValDesconto = valorDoDesconto;

			return valorTotal - _fatura.ValDesconto.Value;
		}

		/// <summary>
		/// Faz o calculo de desconto para a matricula em questao
		/// </summary>
		/// <param name="matricula"></param>
		/// <param name="valorTotal"></param>
		/// <returns>Retorna o valor do desconto</returns>
		private double CalcularDescontoTotal(OnpMatriculaDiadema matricula, double valorTotal) {
			return valorTotal * (matricula.DescontoDiadema.ValValorDesconto.Value / 100.0d);
		}

		/// <summary>
		/// Faz o calculo de desconto para a matricula em questao
		/// </summary>
		/// <param name="matricula"></param>
		/// <param name="valorTotal"></param>
		/// <returns>Retorna o valor do desconto</returns>
		private double CalcularDescontoExcente(OnpMatriculaDiadema matricula, double valorTotal) {
			int? consumoMedido = _movimento.ValConsumoMedido;
			int? consumoAtribuido = _movimento.ValConsumoAtribuido;
			int? consumoRateado = _movimento.ValConsumoRateado;

			// Vai calcular o valor para o limite de consumo do desconto
			_movimento.ValConsumoMedido = matricula.DescontoDiadema.ValLimiteInicial - 1;
			_movimento.ValConsumoAtribuido = null;
			_movimento.ValConsumoRateado = null;

			// Redistribuir o consumo

			_redistribuirConsumo = true;
			DistribuirConsumo();

			// Calcula as taxas
			double valorLimiteConsumo = CalcularCategorias();
			double diferenca = valorTotal - valorLimiteConsumo;

			// Recalcula os valores com o consumo que foi salvo no comeco
			_movimento.ValConsumoRateado = consumoRateado;
			if (matricula.isFilho && matricula.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDComunitario)) {
				_movimento.ValConsumoMedido = null;
				_movimento.ValConsumoAtribuido = null;
			} else {
				_movimento.ValConsumoMedido = consumoMedido;
				_movimento.ValConsumoAtribuido = consumoAtribuido;
			}

			// Volta aos valores originais
			DistribuirConsumo();
			_redistribuirConsumo = false;
			CalcularCategorias();

			// Atribui novamente para que os comunitarios tenham informação atualizada
			// É feito depois do calculo para evitar que estas informacoes entrem no calculo
			_movimento.ValConsumoMedido = consumoMedido;
			_movimento.ValConsumoAtribuido = consumoAtribuido;

			return diferenca * (matricula.DescontoDiadema.ValValorDesconto.Value / 100.0d);
		}

		/// <summary>
		/// Calcula impostos sobre o valor passado.
		/// </summary>
		/// <param name="valorTotal">Valor ao qual deve ser retirado o imposto.</param>
		/// <returns>Retorna o somatorio dos valores dos impostos.</returns>
		private double CalculaImpostos(double valorTotal) {
			Collection<OnpImpostoDiadema> impostos = new OnpImpostoDiadema().SelectCollection();
			OnpFaturaImpostoDiadema fatimp = new OnpFaturaImpostoDiadema();

			double calculado = 0.0, total = 0.0;

			fatimp.SeqFatura = _fatura.SeqFatura;
			fatimp.SeqMatricula = _fatura.SeqMatricula;
			fatimp.SeqRoteiro = _fatura.SeqRoteiro;
			fatimp.CodReferencia = _fatura.CodReferencia;

			foreach (OnpImpostoDiadema imp in impostos) {
				calculado = Arrendonda(valorTotal * (imp.ValPorcentagem.Value / 100));

				total += calculado;

				fatimp.CodImposto = imp.CodImposto;
				fatimp.ValValorCalculado = calculado;
				fatimp.Persist();
			}

			return Arrendonda(total);
		}
		#endregion // Calculo de Descontos

		#region Calcula HD comunitario
		private void CalculaHDComunitario() {
			// Faz o calculo quando estiver posicionando no filho
			if (_matricula.isFilho) {
				_distribuiConsumo = false;
				CalculaNormal(_matricula, string.Empty);
				return;
			}

			// Só vai fazer o processamento se for pai
			// Se o pai ficar retido ou tiver filhos retidos nao calcula
			if (!_matricula.Matricula.Movimento.DatLeitura.HasValue ||
				_matricula.MatriculaPai.temFilhosRetido() ||
				_movimento.IndSituacaoMovimento.Equals("R"))
				return;

			if (TemFilhoDoTipo(OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaNF, _matricula))
				return;

			_matricula.Matricula.Movimento = null;

			int consumoAtual = 0;
			if (_matricula.Matricula.Movimento.ValConsumoAtribuido.HasValue)
				consumoAtual = _matricula.Matricula.Movimento.ValConsumoAtribuido.Value;
			else
				consumoAtual = _matricula.Matricula.Movimento.ValConsumoMedido.Value;

			// Atualizando informações dos filhos
			Collection<OnpTaxa> taxas = new OnpTaxa().SelectCollection();
			int economiasPai = 0, somatorioConsumo;
			foreach (OnpTaxa tax in taxas) {
				economiasPai = TotalEconomias(tax, _matricula.Matricula.Movimento);
				if (economiasPai > 0) {
					somatorioConsumo = 0;

					_progresso.valorMin = 0;
					_progresso.valorMax = _matricula.Filhos.Count;
					_progresso.Posicao = 0;
					_progresso.Mensagem = string.Empty;
					_progresso.Show();
					_progresso.Refresh();

					foreach (OnpMatriculaDiadema matd in _matricula.Filhos) {
						_progresso.Posicao++;
						_progresso.Mensagem = "Rateio de consumo para " + tax.DesTaxa + " (" + _progresso.Posicao.ToString() + " de " + _progresso.valorMax.ToString() + ")";
						_progresso.Refresh();

						if (matd.IndCalculaFatura.Equals("S")) {
							CriarFatura(matd.Matricula.Movimento);
							somatorioConsumo = RateriaConsumoHDPai(matd, tax, economiasPai, consumoAtual);

							matd.Matricula.Movimento.DatLeitura = _matricula.Matricula.Movimento.DatLeitura;
							matd.Matricula.Movimento.ValLeituraReal = _matricula.Matricula.Movimento.ValLeituraReal;
							matd.Matricula.Movimento.ValLeituraAtribuida = _matricula.Matricula.Movimento.ValLeituraAtribuida;
							matd.Matricula.Movimento.ValConsumoRateado = somatorioConsumo;
							matd.Matricula.Movimento.IndSituacaoMovimento = "C";
							foreach (OnpMovimentoOcorrencia mo in _matricula.Matricula.Movimento.MovimentosOcorrencia) {
								mo.SeqMatricula = matd.SeqMatricula;
								mo.Persist();
								mo.SeqMatricula = _matricula.SeqMatricula;
							}
							matd.Matricula.Movimento.Persist();

							matd.Matricula.Movimento.Fatura.DatLeitura = matd.Matricula.Movimento.DatLeitura;
							matd.Matricula.Movimento.Fatura.ValLeituraReal = matd.Matricula.Movimento.ValLeituraReal;
							matd.Matricula.Movimento.Fatura.ValLeituraAtribuida = matd.Matricula.Movimento.ValLeituraAtribuida;
							matd.Matricula.Movimento.Fatura.ValConsumoRateado = matd.Matricula.Movimento.ValConsumoRateado;
							matd.Matricula.Movimento.Fatura.Persist();
						}

						matd.Matricula = null;
					}
				}
			}
		}

		private int RateriaConsumoHDPai(OnpMatriculaDiadema matricula, OnpTaxa taxa, int economiasPai, int consumoAtual) {
			int economiasFilho = TotalEconomias(taxa, matricula.Matricula.Movimento);

			// Passa por todas as taxas de todas as categorias atualizando o consumo rateado
			int somatorioConsumo = 0;
			bool buscaConsumoTaxa = false;
			foreach (OnpFaturaCategoria fc in matricula.Matricula.Movimento.Fatura.Categorias) {
				buscaConsumoTaxa = false;
				foreach (OnpFaturaTaxa ft in fc.Taxas) {
					if (ft.SeqTaxa.Equals(taxa.SeqTaxa) && !ft.ValConsumoFaturado.HasValue) {
                        ft.ValConsumoFaturado = ((int)Arrendonda(consumoAtual / (double)economiasPai, 0)) * ft.ValNumeroEconomia; // Multiplica pelo número de economias da taxa e não pelo total de economiasFilho;
						ft.Persist();
					}
					if (!buscaConsumoTaxa) {
						buscaConsumoTaxa = true;
						somatorioConsumo += ft.ValConsumoFaturado.GetValueOrDefault(0);
					}
				}
			}

			return somatorioConsumo;
		}
		#endregion

		#region Calcula fatura composta
		private void CalculaFaturaComposta() {
			// Se o pai ficar retido ou tiver filhos retidos nao calcula
			if (_matricula.MatriculaPai.getFilhosNaoProcessados() > 1)
				return;

			_distribuiConsumo = true;

			// Se ja leu todos faz a soma todos consumos e atribui a soma para o pai
			int consumoTotal = 0;
			foreach (OnpMatriculaDiadema matd in _matricula.MatriculaPai.Filhos) {
				if (matd.Matricula.Movimento.ValConsumoAtribuido.HasValue)
					consumoTotal += matd.Matricula.Movimento.ValConsumoAtribuido.Value;

				else if (matd.Matricula.Movimento.ValConsumoMedido.HasValue)
					consumoTotal += matd.Matricula.Movimento.ValConsumoMedido.Value;

				consumoTotal += matd.Matricula.Movimento.ValConsumoRateado.GetValueOrDefault(0);
				matd.Matricula = null;
			}

			_matricula.MatriculaPai.Matricula.Movimento.DatLeitura = DateTime.Now;
			_matricula.MatriculaPai.Matricula.Movimento.ValConsumoAtribuido = consumoTotal;
			_matricula.MatriculaPai.Matricula.Movimento.ValLeituraAtribuida = _matricula.MatriculaPai.Matricula.Movimento.ValLeituraAnterior + consumoTotal;
			_matricula.MatriculaPai.Matricula.Movimento.IndSituacaoMovimento = "C";
			_matricula.MatriculaPai.Matricula.Movimento.Persist();

			if (TemFilhoDoTipo("6", _matricula)){
				_matricula.MatriculaPai.Matricula.Movimento.IndSituacaoMovimento = "P";
				_matricula.MatriculaPai.Matricula.Movimento.Persist();
				return;
			}

			if (_matricula.MatriculaPai.temFilhosRetido() || _movimento.IndSituacaoMovimento.Equals("R"))
				return;

			//_matricula.MatriculaPai.Matricula.MarcarProcessado();
			_lancaMinimoNasTaxas = false;
			CalculaNormal(_matricula.MatriculaPai, string.Empty);
		}
		#endregion

		#region Calcula HD apartamento
		private void CalculaHDApartamento() {
			if (!_matricula.MatriculaPai.LeuPai() ||
				_matricula.MatriculaPai.getFilhosNaoProcessados() > 1)
				return;

			if (_matricula.MatriculaPai.temFilhosRetido() || _movimento.IndSituacaoMovimento.Equals("R"))
				return;

			if (TemFilhoDoTipo("6", _matricula)) {
				_matricula.MatriculaPai.Matricula.Movimento.IndSituacaoMovimento = "P";
				_matricula.MatriculaPai.Matricula.Movimento.Persist();
				return;
			}

			OnpMatriculaDiadema matriculaPai = _matricula.MatriculaPai;

			// Faz a soma dos consumos dos filhos
			int consumoTotalFilhos = 0;
			foreach (OnpMatriculaDiadema mat in matriculaPai.Filhos) {
				if (mat.Matricula.Movimento.ValConsumoAtribuido.HasValue)
					consumoTotalFilhos += mat.Matricula.Movimento.ValConsumoAtribuido.Value;

				else if (mat.Matricula.Movimento.ValConsumoMedido.HasValue)
					consumoTotalFilhos += mat.Matricula.Movimento.ValConsumoMedido.Value;
			}

			// Rateia diferenca de consumo 
			int diferencaConsumo = matriculaPai.Matricula.Movimento.ValConsumoMedido.Value - consumoTotalFilhos;
			if (diferencaConsumo > 0) {
				// Verificando a diferença entre medidor do pai e do somatorio dos filhos
				// Se tiver diferenca vai distribuir o consumo, seja ele negativo ou positivo
				int consumoRateado = (int)Arrendonda(diferencaConsumo / (double)matriculaPai.Filhos.Count, 0);

				// Atualiza a leitura e o consumo nos filhos;
				int consumoFilho = 0;
				foreach (OnpMatriculaDiadema mat in matriculaPai.Filhos) {
					if (mat.Matricula.Movimento.ValConsumoAtribuido.HasValue)
						consumoFilho = mat.Matricula.Movimento.ValConsumoAtribuido.Value;

					else if (mat.Matricula.Movimento.ValConsumoMedido.HasValue)
						consumoFilho = mat.Matricula.Movimento.ValConsumoMedido.Value;

					mat.Matricula.Movimento.ValConsumoMedido = mat.Matricula.Movimento.calculaConsumoLeitura(mat.Matricula.Movimento.ValLeituraReal.Value);
					mat.Matricula.Movimento.ValConsumoRateado = consumoRateado;
					mat.Matricula.Movimento.Persist();

					if (_matricula.SeqMatricula.Value == mat.SeqMatricula.Value) {
						_movimento.ValConsumoMedido = mat.Matricula.Movimento.ValConsumoMedido;
						_movimento.ValConsumoRateado = mat.Matricula.Movimento.ValConsumoRateado;

						if (_fatura != null) {
							_fatura.ValConsumoMedido = mat.Matricula.Movimento.ValConsumoMedido;
							_fatura.ValConsumoRateado = mat.Matricula.Movimento.ValConsumoRateado;
						}
					}
				}

				// Calcula os filhos
				string submensagem;
				for (int i = 0; i < _matricula.MatriculaPai.Filhos.Count; i++) {
					submensagem = string.Format(" ({0} de {1})", i + 1, _matricula.MatriculaPai.Filhos.Count);
					CalculaNormal(_matricula.MatriculaPai.Filhos[i], submensagem);
					_matricula.MatriculaPai.Filhos[i].Matricula = null;
				}

				if (_matricula.isFilho) {
					_movimento.IndSituacaoMovimento = "F";
					_movimento.Persist();
				}
			}
		}
		#endregion

		#region Metodos c/ override
		public override void Calcular(OnpMovimento movimento, bool distribuiConsumo) {
			_matricula = new OnpMatriculaDiadema(movimento.SeqMatricula.Value);
			_movimento = movimento;
			_distribuiConsumo = distribuiConsumo;
			_redistribuirConsumo = false;

			// Se tiver caminhao pipa fica pendente

			switch (_matricula.MatriculaPai.IndTipoConsumidor) {
				case OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaNF:
					_movimento.IndSituacaoMovimento = "P";
					_movimento.Fatura = null;
					_movimento.Persist();

					_matricula.MatriculaPai.Matricula.Movimento.IndSituacaoMovimento = "P";
					_matricula.MatriculaPai.Matricula.Movimento.Fatura = null;
					_matricula.MatriculaPai.Matricula.Movimento.Persist();
					break;

				case OnpMatriculaDiadema.TipoConsumidor.CaminhaoPipaHD:
				case OnpMatriculaDiadema.TipoConsumidor.HDPoco:
				case OnpMatriculaDiadema.TipoConsumidor.Normal:
				case OnpMatriculaDiadema.TipoConsumidor.MedidorEsgoto:
				case OnpMatriculaDiadema.TipoConsumidor.NormalEsgotamentoEspecial:
					CalculaNormal(_matricula, string.Empty);
					break;

				case OnpMatriculaDiadema.TipoConsumidor.HDComunitario:
					CalculaHDComunitario();
					break;

				case OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3:
				case OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8:
					CalculaFaturaComposta();
					break;

				case OnpMatriculaDiadema.TipoConsumidor.HDApartamento:
					CalculaHDApartamento();
					break;
			}

			_progresso.Dispose();
		}

		protected override void calculaValorTaxaCalculadoEscalonado(OnpFaturaTaxa ft, OnpTaxaTarifa tarifa, Collection<OnpTaxaTarifa.FaixaTarifa> faixas) {
			int consumoRestante = ft.ValConsumoFaturado.Value;
			int consumoCalculo = 0;
			double valorCalculado = 0;

			_ultimoSeqMatricula = ft.SeqMatricula.Value;
			_fcvs.Clear();

			// Arredonda o consumo
			consumoRestante = ((int)Arrendonda(consumoRestante / (double)ft.ValNumeroEconomia.Value, 0)) * ft.ValNumeroEconomia.Value;
			ft.ValConsumoFaturado = consumoRestante;

			// Primeira faixa (Pode ser minimo...)
			// Consumo a utilizar para calculo
			consumoCalculo = (consumoRestante > faixas[0].ValLimiteConsumo ? faixas[0].ValLimiteConsumo : consumoRestante);

			// Consumo restante a ser calculado
			consumoRestante -= consumoCalculo;

			// Tem minimo
			if (tarifa.IndMinimo.Equals("S")) {
				valorCalculado += faixas[0].ValValorTarifa;
				_fcvs.Add(new FaixaConsumoValor(true, faixas[0].ValLimiteConsumo, 0, faixas[0].ValValorTarifa, faixas[0].ValValorTarifa));
			} else {
				valorCalculado += (faixas[0].ValValorTarifa * consumoCalculo);
				_fcvs.Add(new FaixaConsumoValor(false, faixas[0].ValLimiteConsumo, 0, faixas[0].ValValorTarifa, faixas[0].ValValorTarifa));
			}

			// Demais faixas
			int intervaloFaixa, i;
			for (i = 1; i < faixas.Count && consumoRestante > 0; i++) {
				// Consumo a utilizar para calculo
				intervaloFaixa = faixas[i].ValLimiteConsumo - faixas[i - 1].ValLimiteConsumo;

				//Consumo para o calculo
				consumoCalculo = (consumoRestante > intervaloFaixa ? intervaloFaixa : consumoRestante);

				// Consumo restante a ser calculado
				consumoRestante -= consumoCalculo;

				// Valor calculado
				valorCalculado += (faixas[i].ValValorTarifa * consumoCalculo);

				_fcvs.Add(new FaixaConsumoValor(false, faixas[i].ValLimiteConsumo, consumoCalculo, faixas[i].ValValorTarifa, faixas[i].ValValorTarifa * consumoCalculo));
			}

			// Adiciona faixas que não foram usada no calculo
			for (; i < faixas.Count; i++)
				_fcvs.Add(new FaixaConsumoValor(false, faixas[i].ValLimiteConsumo, 0, faixas[i].ValValorTarifa, 0.0));

			// Lança o valor
			ft.ValValorCalculado = valorCalculado;
		}

		protected override double calculaProporcional(OnpFaturaTaxa ft) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(_matricula.SeqMatricula.Value);

			DateTime data1 = _movimento.DatLeituraAnterior.Value.Date;
			DateTime data2 = _movimento.DatLeitura.Value.Date;

			OnpTaxaTarifa tarifa1 = GetTarifa(ft, data1);
			OnpTaxaTarifa tarifa2 = GetTarifa(ft, data2);

			double valor1 = calcularTarifa(ft, tarifa1);
			double valor2 = calcularTarifa(ft, tarifa2);

            TimeSpan totalDias = data2.Subtract(data1);
            TimeSpan ts2 = data2.Subtract(tarifa2.DatInicio.Value);

            int diasConsumo = totalDias.Days;
            if ((diasConsumo > 31) && VerificaAjustarConsumoLeitura(CalculaTaxasDiadema.DiasDeConsumo, CalculaTaxasDiadema.DiasDeConsumoMax, matd, _movimento)) {
                if (diasConsumo > 31) {
                    diasConsumo = 31;
                }
            }
            int dias2 = (ts2.Days + 1);
            int dias1 = (diasConsumo - dias2);

			if (!string.IsNullOrEmpty(matd.IndBloqueio) && matd.IndBloqueio.Equals("S")) {
				if (matd.ValDiasBloqueioAnterior.HasValue)
					dias1 -= matd.ValDiasBloqueioAnterior.Value;

				if (matd.ValDiasBloqueioAtual.HasValue)
					dias2 -= matd.ValDiasBloqueioAtual.Value;
			}

            if (dias1 < 0) {
                dias1 = 0;
            }

            if (dias2 < 0) {
                dias2 = 0;
            }

            // Ajusta os dias de consumo para realizar a proporcionalidade correta
            if ((dias2 + dias1) != diasConsumo) {
                diasConsumo = (dias2 + dias1);
            }

            // Caso não tenha dias numa determinada tarifa náo calcular.
            if ((dias1 > 0) && (dias2 > 0)) {
                return ((valor1 * dias1) + (valor2 * dias2)) / diasConsumo;
            } else if (dias1 > 0) {
                return valor1;
            } else {
                return valor2;
            } 
		}

		protected override void DistribuirConsumo(OnpFaturaTaxa taxa, OnpFaturaTaxa.TipoConsumo tipoConsumo, int consumoFaturar) {
			int totalEconomias = TotalEconomias(taxa.Taxa, _movimento);

			// Distribui o consumo para as taxas q sao iguais a taxa recebida como parâmetro
			foreach (OnpFaturaCategoria fc in _fatura.Categorias) {
				foreach (OnpFaturaTaxa ft in fc.Taxas) {
					if (ft.SeqTaxa.Equals(taxa.SeqTaxa)) {
						if (!ft.ValConsumoFaturado.HasValue || _redistribuirConsumo)
							ft.ValConsumoFaturado = ((int)Arrendonda(consumoFaturar / (double)totalEconomias, 0)) * ft.ValNumeroEconomia.Value;

						ft.TipoDoConsumo = tipoConsumo;
						break;
					}
				}
			}
		}
		#endregion // Metodos c/ override

		#region Outros metodos
		/// <summary>
		/// Verifica se uma matricula que tem filhos tem um certo tipo de filho
		/// </summary>
		/// <param name="mat">Matricula ser testada</param>
		/// <param name="tipo">Tipo a ser testado vindo da classe TipoConsumidor</param>
		/// <returns>Retorna true se um dos filhos da matricula recebida tiver o tipo recebido, caso
		/// contrario retorna false.</returns>
		private bool TemFilhoDoTipo(string tipo, OnpMatriculaDiadema mat) {
			foreach (OnpMatriculaDiadema md in mat.MatriculaPai.Filhos)
				if (md.IndTipoConsumidor.Equals(tipo))
					return true;

			return false;
		}

		/// <summary>
		/// Metodo para calcular uma categoria chamado da classe de impressao
		/// </summary>
		/// <param name="fc"></param>
		/// <returns></returns>
		public new double CalcularCategoria(OnpFaturaCategoria fc) {
			return base.CalcularCategoria(fc);
		}

        /// <summary>
        /// Verifica se faz ajuste
        /// </summary>
        public static bool VerificaAjustarConsumoLeitura(int dias, int diasMax, OnpMatriculaDiadema matd, OnpMovimento mov) {
            TimeSpan tsLeitura = mov.DatLeitura.Value.Date - mov.DatLeituraAnterior.Value.Date;
            int diasLeitura = tsLeitura.Days;
            bool ajustar = true;

            if (matd.isFilho && matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDComunitario))
                ajustar = false;

            // Só ajusta contas que tem leituras e que são calculadas pela leitura real
            if ((diasLeitura <= dias) && ajustar)
                ajustar = false;

            // Só ajusta contas que tem leituras e que são calculadas pela leitura real
            if ((diasLeitura > diasMax) && ajustar)
                ajustar = false;

            if (ajustar && (!string.IsNullOrEmpty(matd.IndBloqueio) && matd.IndBloqueio.Equals("S")))
                ajustar = false;

            if (ajustar && (matd.IndTipoConsumidor.Equals("6") || matd.IndTipoConsumidor.Equals("10")))
                ajustar = false;

            if (ajustar && (!mov.ValConsumoMedido.HasValue))
                ajustar = false;

            if (ajustar && (mov.MovimentosOcorrencia.Count > 0)) {
                if (!mov.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("0") &&
                    !mov.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("9") &&
                    !mov.GetPrimeiraOcorrencia().Ocorrencia.IndConsumo.Equals("10"))
                    ajustar = false;
            }

            return ajustar;
        }

		/// <summary>
		/// Faz o juste do consumo e da leitura para o intervalor de dias passados.
		/// </summary>
		/// <param name="matricula">matriucla que deve ter o consumo e leitura ajustados.</param>
		/// <param name="dias">Dias de consumo para o consumo e a leitura devem ser ajustados.</param>
        public static void AjustarConsumoLeitura(int dias, int diasMax, OnpMatriculaDiadema matd, OnpMovimento mov, OnpFatura fat) {

            if (VerificaAjustarConsumoLeitura(dias, diasMax, matd, mov)) {

                if (mov.ValLeituraAtribuida.HasValue || mov.ValConsumoAtribuido.HasValue)
                    return;

				DateTime dt = mov.DatLeituraAnterior.Value.Date;
				if (mov.DatTroca.HasValue) 
					dt = mov.DatTroca.Value.Date;

                TimeSpan tsLeitura = mov.DatLeitura.Value.Date - dt;
                int diasLeitura = tsLeitura.Days;

                // Ajusta o consumo
                if (mov.ValConsumoMedido.HasValue) {
                    int consumoAtual = mov.ValConsumoMedido.Value;
                    int consumoAjustado = (int)Arrendonda(consumoAtual * dias / (double)diasLeitura, 0);

                    mov.ValConsumoAtribuido = consumoAjustado;
                    mov.ValLeituraAtribuida = mov.ValLeituraAnterior + consumoAjustado;
                    mov.Persist();

                    if (fat != null) {
                        fat.ValConsumoAtribuido = mov.ValConsumoAtribuido;
                        fat.ValLeituraAtribuida = mov.ValLeituraAtribuida;
                        fat.Persist();
                    }
                }
            }
		}
		#endregion // Outros metodos
	}
}

