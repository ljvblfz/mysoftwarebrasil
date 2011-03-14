using System;
using System.Text;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using OnPlaceMovel.Source.CalculoTaxas;

namespace OnPlaceMovel.Source.Diadema {
	public class ImpressaoDiadema : IImpressao {
		#region Atributos e Propriedades
		private const int MAX_HISTORICO = 6;

		private OnpMatricula _matricula;
		public OnpMatricula Matricula {
			get {
				return _matricula;
			}
		}

		private OnpMatriculaDiadema _matriculaDiadema;
		public OnpMatriculaDiadema MatriculaDiadema {
			get {
				return _matriculaDiadema;
			}
		}

		private IPrinter _impressora;
		public IPrinter Impressora {
			get {
				return _impressora;
			}
			set {
				_impressora = value;
			}
		}
		#endregion // Atributos e Propriedades

		#region Metodos publicos
		/// <summary>
		/// Imprimi a fatura da matricula passada no construtor
		/// </summary>
		/// <returns>Retorna true se conseguiu imprimir</returns>
		public bool printFatura(OnpMatricula matricula) {
			if (_matriculaDiadema == null || _matriculaDiadema.SeqMatricula.Value != matricula.SeqMatricula.Value)
				_impressora.LimparComandos();

			_matriculaDiadema = new OnpMatriculaDiadema(matricula.SeqMatricula.Value);
			if (!string.IsNullOrEmpty(_matriculaDiadema.IndEmiteFatura) && _matriculaDiadema.IndEmiteFatura.Equals("N"))
				return true;

			bool retorno = false;
			_matricula = matricula;

			// Verifica se não retem para analise
			if (!_matricula.Movimento.IndSituacaoMovimento.Equals("R")) {
				if (_matricula.Movimento.Fatura != null) {

					if (_impressora.BufferVazio)
						montaFatura(_matricula.Movimento.Fatura);

					if (_impressora.Imprimir())
						retorno = true;
				}
			} else {
				retorno = printAvisoRetencao();
			}

			if (retorno)
				_impressora.LimparComandos();

			return retorno;
		}

		public void RefazerImpressao() {
			_impressora.LimparComandos();
		}

		/// <summary>
		/// Imprimi a fatura passada
		/// </summary>
		/// <param name="segVia"></param>
		/// <returns>Retorna true se conseguiu imprimir</returns>
		public bool print2aVia(OnpFatura segVia) {
			_impressora.LimparComandos();

			_matricula = segVia.Matricula;

			montaFatura(segVia);

			bool retorno = false;
			if (_impressora.Imprimir()) {
				segVia.IndFaturaEmitida = "S";
				segVia.DatHoraEmissao = DateTime.Now;
				segVia.Persist();
				retorno = true;
			}

			return retorno;
		}

		/// <summary>
		/// Imprimi aviso de retenção para a matricula passada no construtor
		/// </summary>
		/// <returns>Retorna true se conseguiu imprimir</returns>
		public bool printAvisoRetencao() {
			_impressora.LimparComandos();
			montaAvisoRetencao();
			return _impressora.Imprimir();
		}

		/// <summary>
		/// Imprimi aviso de débito para a matricula passada no construtor
		/// </summary>
		/// <returns>Retorna true se conseguiu imprimir</returns>
		public bool printAvisoDebito(OnpMatricula matricula) {
			_matricula = matricula;
			_impressora.LimparComandos();
			montaAvisoDebito();
			return _impressora.Imprimir();
		}

		/// <summary>
		/// Imprimi estatisticas de leitura para o roteiro atual, usado para testar se a impressora esta funcionando
		/// </summary>
		/// <param name="agente"></param>
		/// <param name="grupoRoteiro"></param>
		/// <param name="estatisticas"></param>
		/// <returns>Retorna true se imprimiu</returns>
		public bool printTeste(OnpAgente agente, string grupoRoteiro, string[] estatisticas) {
			_impressora.LimparComandos();
			montaTeste(agente, grupoRoteiro, estatisticas);
			return _impressora.Imprimir();
		}
		#endregion // Metodos publicos

		#region Metodos montagem de conta
		/// <summary>
		/// Lista os comandos necessarios para imprimir um aviso de debito
		/// </summary>
		protected void montaAvisoDebito() {
			ImprimiCabecalho(true);

			int y, x;

			#region TEXTO NOTIFICACAO
			// VALOR DE Y PARA NOTIFICACAO DE DEBITO
			y = 74;
			x = 7;

			if (!string.IsNullOrEmpty(_matricula.Aviso.IndDocumento) && _matricula.Aviso.IndDocumento.Equals("A"))
				_impressora.printText("                A V I S O   D E   D E B I T O", x, y);
			else
				_impressora.printText("        N O T I F I C A C A O   D E   D E B I T O", x, y);

			_impressora.printText("Prezado Usuario,", x, y + 4);
			if (_matricula.Aviso.FaturasAviso.Count > 0) {
				_impressora.printText("Permita-nos chamar sua atencao para a(s) fatura(s) abaixo", x, y + 7);
				_impressora.printText("relacionada(s)  que,  de  acordo  com  nossos  registros,", x, y + 10);
				_impressora.printText("permanece(m) pendente(s) ate esta data: " + DateTime.Now.ToString("dd/MM/yyyy") + ".", x, y + 13);
			} else {
				_impressora.printText("Permita-nos chamar sua atencao, de acordo com", x, y + 7);
				_impressora.printText("nossos  registros, existem " + _matricula.Aviso.ValQuantidadeDebito.Value.ToString() + " faturas vencidas", x, y + 10);
				_impressora.printText("ate esta data: " + DateTime.Now.ToString("dd/MM/yyyy") + ".", x, y + 13);
			}
			#endregion

			#region DEBITOS
			// VALOR DE Y PARA DEBITOS
			y = 98;

			if (_matricula.Aviso.FaturasAviso.Count > 0) {
				_impressora.printText("REFERENCIA", x + 10, y);
				_impressora.printTextRight("VALOR", x + 55, y);
			}

			double totalDebitos = _matricula.Aviso.Fatura.ValValorFaturado.GetValueOrDefault(0.0);
			if (_matricula.Aviso != null) {
				if (_matricula.Aviso.FaturasAviso != null) {// && _matricula.Aviso.FaturasAviso.Count > 0)
					foreach (OnpFaturasAviso fa in _matricula.Aviso.FaturasAviso) {
						y += 3;
						_impressora.printText(formatarReferencia(fa.CodReferencia), x + 10, y);
						_impressora.printTextRight(formatarMonetario(fa.ValValorFatura.Value), x + 55, y);
					}
				}

				y += 4;

				if (totalDebitos > 0.0) {
					_impressora.printText("TOTAL R$: ", x + 10, y);
					_impressora.printTextRight(formatarMonetario(totalDebitos), x + 55, y);
				}
			}
			#endregion

			#region AVISO
			y += 4;

			if (!string.IsNullOrEmpty(_matricula.Aviso.IndDocumento) && _matricula.Aviso.IndDocumento.Equals("A")) {
				_impressora.printText("Se houve  algum  problema  que  impossibilitou  o  pagamento,", x, y);
				_impressora.printText("compareca ao balcao de atendimento da  SANED  na Rua  Estados", x, y + 3);
				_impressora.printText("Unidos, n. 78. Caso  contrario, solicitamos a pronta quitacao", x, y + 6);
				_impressora.printText("do referido debito para regularizacao em nossos arquivos.", x, y + 9);
				_impressora.printText("Desconsidere  este  aviso  caso as  faturas  acima  descritas", x, y + 12);
				_impressora.printText("tenham sido quitadas.", x, y + 15);
				_impressora.printText("Atenciosamente,", x, y + 18);
				_impressora.printText("SANED - Cia. de Saneamento de Diadema", x, y + 21);
			} else {
				_impressora.printText("Compareca ao balcao  de  atendimento da  SANED, na Rua Estados", x, y);
				_impressora.printText("Unidos, n. 78, no prazo de 7 (sete) dias uteis, para  negociar", x, y + 3);
				_impressora.printText("os seus debitos. evitando o corte no abastecimento.", x, y + 6);
				_impressora.printText("Caso ja tenham sido quitados, favor apresentar os comprovantes", x, y + 9);
				_impressora.printText("e desculpar-nos pelo transtorno.", x, y + 12);
				_impressora.printText("Atenciosamente,", x, y + 15);
				_impressora.printText("SANED - Cia. de Saneamento de Diadema", x, y + 18);
			}
			#endregion

			#region CODIGO DE BARRAS
			y = 191;

			if (_matricula.Aviso.Fatura != null) {
				_impressora.printBarCode(_matricula.Aviso.Fatura.DesCodigoBarras, x, y);

				string linhaDigitavel = string.Empty;
				for (int i = 1; i < _matricula.Aviso.Fatura.DesLinhaDigitavel.Length + 1; i++) {
					linhaDigitavel += _matricula.Aviso.Fatura.DesLinhaDigitavel[i - 1];
					if ((i % 12) == 0)
						linhaDigitavel += "  ";
				}

				y += 13;

				_impressora.Fonte = 7;
				_impressora.FonteSize = 1;
				_impressora.printText(linhaDigitavel, x, y);
			}
			#endregion

			#region DADOS RODAPE DA FATURA
			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			y = 216;

			_impressora.printText(formatarMatricula(_matricula.SeqMatricula.Value), x, y);
			_impressora.printText("**/****", x + 27, y);
			_impressora.printText("**/**/****", x + 47, y);
			if (totalDebitos > 0.0) {
				_impressora.printTextRight(formatarMonetario(totalDebitos), x + 89, y);
			} else {
				_impressora.printTextRight("***", x + 89, y);
			}
			#endregion
		}

		/// <summary>
		/// Lista os comandos necessarios para imprimir um aviso de retencao
		/// </summary>
		protected void montaAvisoRetencao() {
			ImprimiCabecalho(false);

			int y, x;

			#region DADOS DA MESAGEM DE AVISO
			y = 100;
			x = 7;

			_impressora.printText("Prezado Cliente,", x, y);
			_impressora.printText("O seu consumo neste mes apresentou uma variacao", x, y + 3);
			_impressora.printText("anormal em relacao a sua media nos ultimos 12 meses.", x, y + 6);
			_impressora.printText("Sua fatura ficou retida para analise.", x, y + 9);

			TimeSpan span = _matricula.Movimento.DatLeitura.Value.Date - _matricula.Movimento.DatLeituraAnterior.Value.Date;
			int diasConsumo = (int)span.TotalDays;

			if (diasConsumo > 31)
				diasConsumo = 31;

			if (!string.IsNullOrEmpty(_matriculaDiadema.IndBloqueio) && _matriculaDiadema.IndBloqueio.Equals("S")) {
				diasConsumo = (int)span.TotalDays;

				if (_matriculaDiadema.ValDiasBloqueioAnterior.HasValue)
					diasConsumo -= _matriculaDiadema.ValDiasBloqueioAnterior.Value;

				if (_matriculaDiadema.ValDiasBloqueioAtual.HasValue)
					diasConsumo -= _matriculaDiadema.ValDiasBloqueioAtual.Value;
			}

			y = 115;

			_impressora.printText("LEITURA: " + _matricula.Movimento.ValLeituraReal.ToString(), x, y);
			_impressora.printText("MEDIA  : " + _matricula.Movimento.ValConsumoMedio.ToString(), x, y + 4);
			_impressora.printText("CONSUMO: " + _matricula.Movimento.ValConsumoMedido.ToString(), x, y + 8);
			_impressora.printText("DATA LEITURA: " + _matricula.Movimento.DatLeitura.Value.ToString("dd/MM/yyyy"), x, y + 12);
			_impressora.printText("DIAS CONSUMO: " + diasConsumo.ToString(), x, y + 16);

			if (_matricula.Movimento.MovimentosOcorrencia.Count > 0) {
				bool primeira = true;
				y = 142;

				foreach (OnpMovimentoOcorrencia omc in _matricula.Movimento.MovimentosOcorrencia) {
					if (primeira) {
						_impressora.printText("OCORRENCIA(S): " + omc.Ocorrencia.DesOcorrencia, x, y);
						primeira = false;
					} else {
						_impressora.printText("               " + omc.Ocorrencia.DesOcorrencia, x, y);
					}
					y += 3;
				}
			}
			#endregion
		}

		/// <summary>
		/// Lista os comandos necessarios para imprimir a fatura passando usando o titulo passado
		/// </summary>
		/// <param name="fatura">Fatura para ser impressa</param>
		/// <param name="titulo">Titulo da fatura</param>
		protected void montaFatura(OnpFatura fatura) {
			int y, x;

			#region DADOS DA MATRICULA E HIDROMETRO
			_impressora.FonteSize = 0;

			y = 26;
			x = 7;

			_impressora.printText(formatarMatricula(_matricula.SeqMatricula.Value), x, y);
			_impressora.printText(_matricula.Movimento.CodHidrometro, x + 23, y);
			_impressora.printText(formatarReferencia(fatura.CodReferencia), x + 47, y);
			_impressora.printText(fatura.DatVencimento.Value.ToString("dd/MM/yyyy"), x + 70, y);
			#endregion

			#region DADOS NOME E ENDERECO CLIENTE
			y = 33;

			_impressora.printText(_matricula.NomCliente, x, y);
			y += 3;

			string rua = _matricula.Logradouro.DesLogradouro;
			string numero = _matricula.ValNumeroImovel.ToString();
			_impressora.printText(rua + ", " + numero + ", " + _matricula.DesComplemento, x, y);

			y += 3;

			if (!string.IsNullOrEmpty(_matricula.DesEnderecoAlternativo))
				_impressora.printText("Entrega:" + _matricula.DesEnderecoAlternativo, x, y);
			#endregion

			#region DEBITO AUTOMATICO
			y += 3;
			if (_matricula.Movimento.IndEntregaEspecial.Equals("1"))
				_impressora.printText("DEBITO AUTOMATICO - " + _matricula.Movimento.DesBancoDebito + " - " + _matricula.Movimento.DesBancoAgenciaDebito, x, y);
			#endregion // Debito Automatico

			#region DADOS CATEGORIA/ECONOMIA E INSCRICAO/SEQUENCIA
			y = 51;

			string categoriaEconomia = string.Empty;
			foreach (OnpMovimentoCategoria movCat in _matricula.Movimento.MovimentosCategoria)
				categoriaEconomia = categoriaEconomia + " " + movCat.Categoria.DesCategoria.Substring(0, 3) + "/" + movCat.ValNumeroEconomia.ToString();

			_impressora.printText(categoriaEconomia.Trim(), x, y);

			string seqRoteiro = _matricula.Movimento.SeqRoteiro.ToString().Substring(2);
			string seqSetor = string.Empty;
			string desInscricao = _matricula.DesInscricao;

			_impressora.printText(seqRoteiro + seqSetor + desInscricao + " / " + _matricula.SeqLeitura.Value.ToString(), x + 31, y);
			#endregion

			#region DADOS LEITURAS
			y = 59;
			x = 7;

			// LEITURA ATUAL
			string valorLeituraAtual = string.Empty;

			if (fatura.ValLeituraAtribuida.HasValue)
				valorLeituraAtual = fatura.ValLeituraAtribuida.Value.ToString();
			else if (fatura.ValLeituraReal.HasValue)
				valorLeituraAtual = fatura.ValLeituraReal.Value.ToString();

			_impressora.printText(valorLeituraAtual, x + 22, y);

			// DATA LEITURA ATUAL
			if (fatura.DatLeitura.HasValue)
				_impressora.printText(fatura.DatLeitura.Value.ToString("dd/MM/yyyy"), x + 36, y);

			y += 4;

			// LEITURA ANTERIOR
			if (fatura.ValLeituraAnterior.HasValue)
				_impressora.printText(fatura.ValLeituraAnterior.Value.ToString(), x + 22, y);

			// DATA LEITURA ANTERIOR
			if (fatura.DatLeituraAnterior.HasValue)
				_impressora.printText(fatura.DatLeituraAnterior.Value.ToString("dd/MM/yyyy"), x + 36, y);

			// CONSUMO ATUAL
			int valorConsumo = 0;
			if (fatura.ValConsumoAtribuido.HasValue)
				valorConsumo = fatura.ValConsumoAtribuido.Value;
			else if (fatura.ValConsumoMedido.HasValue)
				valorConsumo = fatura.ValConsumoMedido.Value;

			valorConsumo += fatura.ValConsumoRateado.GetValueOrDefault(0);
			_impressora.printText(valorConsumo.ToString(), x + 55, y);

			// CONSUMO MEDIO
			if (fatura.ValConsumoMedio.HasValue) {
				_impressora.printText(fatura.ValConsumoMedio.Value.ToString(), x + 66, y);
			}

			// DATA PROXIMO LEITURA
			if (fatura.DatLeitura.HasValue) {
				DateTime data = fatura.DatLeitura.Value;
				data = data.AddMonths(1);
				_impressora.printText(data.ToString("dd/MM/yyyy"), x + 76, y);
			}

			// VALOR DE Y PARA CONDICAO DE LEITURA
			y += 4;

			// CONDICAO LEITURA
			if (_matricula.Movimento.GetPrimeiraOcorrencia() != null)
				_impressora.printText(_matricula.Movimento.GetPrimeiraOcorrencia().Ocorrencia.DesMensagem, x + 22, y);
			#endregion

			#region HISTÓRICO DE LEITURAS
			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			// VALOR DE Y PARA HISTORICO DE LEITURAS
			y = 74;

			ICollection<OnpHistorico> historico = fatura.BuscaHistoricoConsumo(MAX_HISTORICO);

			// Imprime os históricos de leitura
			string anoHist, mesHist;
			foreach (OnpHistorico fatHistorico in historico) {
				getMesAno(fatHistorico.CodReferencia, out mesHist, out anoHist);

				_impressora.printText(zerosEsquerda(mesHist, 2) + "/" + anoHist, x, y);

				if (fatHistorico.ValConsumo.HasValue)
					_impressora.printText(fatHistorico.ValConsumo.Value.ToString(), x + 13, y);

				if (!string.IsNullOrEmpty(fatHistorico.CodOcorrencia))
					_impressora.printText(fatHistorico.CodOcorrencia.ToString(), x + 19, y);

				y += 3;
			}
			#endregion

			#region FAIXAS
			// VALOR DE Y PARA FAIXAS
			y = 74;

			if (fatura.SeqFatura == 0) {
				if (fatura.Categorias.Count > 1) {
					foreach (OnpFaturaCategoria fc in fatura.Categorias) {
						_impressora.printText(fc.Categoria.DesCategoria, x + 32, y);
						int seqTaxaAgua = 1; // TAXA DE AGUA

						int valConsumoCat = 0;
						foreach (OnpFaturaTaxa ft in fc.Taxas) {
							valConsumoCat += ft.ValConsumoFaturado.Value;
							if (ft.SeqTaxa.Value == seqTaxaAgua) {
								_impressora.printTextRight(ft.ValConsumoFaturado.Value.ToString(), x + 56, y);
								_impressora.printTextRight(formatarMonetario(ft.ValValorFaturado.Value), x + 88, y);
								break;
							}
						}

						y += 3;
					}
				} else if (fatura.Categorias.Count == 1) {
					int faixa = 1;

					if (CalculaTaxasDiadema.UltimoSeqMatricula != fatura.SeqMatricula.Value)
						Recalcular(fatura);

					for (int i = 0; i < CalculaTaxasDiadema.FCV.Count; i++) {
						if (CalculaTaxasDiadema.FCV[i].minimo) {
							_impressora.printText("Minima", x + 34, y);
							_impressora.printTextRight("0", x + 56, y);
							_impressora.printTextRight(formatarMonetario(CalculaTaxasDiadema.FCV[i].tarifa), x + 69, y);
							_impressora.printTextRight(formatarMonetario(CalculaTaxasDiadema.FCV[i].valor), x + 88, y);
						} else {
							if (i < CalculaTaxasDiadema.FCV.Count - 1) {
								_impressora.printTextRight(faixa + " - " + CalculaTaxasDiadema.FCV[i].faixa.ToString(), x + 44, y);
							} else {
								_impressora.printTextRight("> " + CalculaTaxasDiadema.FCV[i - 1].faixa.ToString(), x + 44, y);
							}

							_impressora.printTextRight(CalculaTaxasDiadema.FCV[i].consumo.ToString(), x + 56, y);
							_impressora.printTextRight(formatarMonetario(CalculaTaxasDiadema.FCV[i].tarifa), x + 69, y);
							_impressora.printTextRight(formatarMonetario(CalculaTaxasDiadema.FCV[i].valor), x + 88, y);
							faixa = CalculaTaxasDiadema.FCV[i].faixa + 1;
						}
						y += 3;
					}
				}
			}
			#endregion

			#region TAXAS / RETENCAO / REDUCAO / SERVICOS / VALOR TOTAL
			y = 94;

			int maxLinhas = 9;
			int linhas = 0;

			//////////////////////////////////////////////////////////////////////
			// TAXAS
			if (fatura.Categorias.Count == 1 && fatura.Categorias[0].Taxas.Count > 0) {
				foreach (OnpFaturaTaxa tafTaxa in fatura.Categorias[0].Taxas) {
					if (tafTaxa.ValValorFaturado.HasValue && tafTaxa.ValValorFaturado.Value > 0) {
						y += 3;
						_impressora.printText(tafTaxa.Taxa.DesTaxa, x, y);
						_impressora.printTextRight(formatarMonetario(tafTaxa.ValValorFaturado.Value), x + 86, y);
						linhas++;
					}
				}
			} else if (fatura.Categorias.Count > 1) {
				double totalCategoria;
				bool temTaxa = false;
				Collection<OnpTaxa> taxas = new OnpTaxa().SelectCollection();

				foreach (OnpTaxa t in taxas) {
					totalCategoria = 0.0;
					temTaxa = false;

					foreach (OnpFaturaCategoria fc in fatura.Categorias) {
						foreach (OnpFaturaTaxa ft in fc.Taxas) {
							if (t.SeqTaxa.Value == ft.SeqTaxa.Value) {
								totalCategoria += ft.ValValorFaturado.GetValueOrDefault(0.0);
								temTaxa = true;
							}
						}
					}

					if (temTaxa) {
						linhas++;
						y += 3;
						_impressora.printText(t.DesTaxa, x, y);
						_impressora.printTextRight(formatarMonetario(totalCategoria), x + 86, y);
					}
				}
			}

			//////////////////////////////////////////////////////////////////////
			// RETENCAO (IMPOSTOS)
			OnpFaturaImpostoDiadema filtro = new OnpFaturaImpostoDiadema();
			filtro.SeqFatura = fatura.SeqFatura;
			filtro.SeqMatricula = fatura.SeqMatricula;
			filtro.SeqRoteiro = fatura.SeqRoteiro;
			filtro.CodReferencia = fatura.CodReferencia;
			Collection<OnpFaturaImpostoDiadema> impostos = filtro.SelectCollection();

			if (impostos.Count > 0) {
				linhas++;

				y += 3;

				double totalImpostos = 0.0;
				foreach (OnpFaturaImpostoDiadema imp in impostos)
					totalImpostos += imp.ValValorCalculado.Value;

				_impressora.printText("RETENCAO", x, y);
				_impressora.printTextRight(formatarMonetario(totalImpostos), x + 86, y);
			}

			//////////////////////////////////////////////////////////////////////
			// REDUCAO
			if (fatura.ValDesconto.HasValue && fatura.ValDesconto.Value > 0) {
				linhas++;

				y += 3;
				_impressora.printText("REDUCAO", x, y);
				_impressora.printTextRight("-" + formatarMonetario(fatura.ValDesconto.Value), x + 86, y);
			}

			//////////////////////////////////////////////////////////////////////
			// SERVICOS
			if (linhas + fatura.Servicos.Count < maxLinhas) {
				// todos os servicos cabem nas linhas que faltam
				// nao precisa ajustar
				foreach (OnpFaturaServico fatServico in fatura.Servicos) {
					linhas++;
					y += 3;
					_impressora.printText(fatServico.DesServico, x, y);
					_impressora.printTextRight(formatarMonetario(fatServico.ValParcela.GetValueOrDefault(0.0)), x + 86, y);
				}
			} else {
				int i;

				// imprimi os serviços que cabem
				for (i = 0; i < maxLinhas - linhas - 1; i++) {
					linhas++;
					y += 3;
					_impressora.printText(fatura.Servicos[i].DesServico, x, y);
					_impressora.printTextRight(formatarMonetario(fatura.Servicos[i].ValParcela.GetValueOrDefault(0.0)), x + 86, y);
				}

				// Soma os serviços restantes em um unico item na conta
				double somaOutrosServicos = 0.0;
				for (; i < fatura.Servicos.Count; i++)
					somaOutrosServicos += fatura.Servicos[i].ValParcela.GetValueOrDefault(0.0);

				y += 3;
				_impressora.printText("SERVICO DIVERSOS", x, y);
				_impressora.printTextRight(formatarMonetario(somaOutrosServicos), x + 86, y);
			}

			//////////////////////////////////////////////////////////////////////
			// VALOR TOTAL
			y += 8;

			_impressora.printText("VALOR A PAGAR", x, y);
			_impressora.printTextRight(formatarMonetario(fatura.ValValorFaturado.Value), x + 86, y);
			#endregion

			#region DADOS VARIACAO DE CONSUMO
			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			// VALOR DE Y PARA CONSTATADA VARIACAO DE CONSUMO
			y = 138;
			if (fatura.Movimento.DatTroca.HasValue)
				_impressora.printText("Troca de medidor em: " + fatura.Movimento.DatTroca.Value.ToString("dd/MM/yyyy"), x, y);
			y += 3;

			if (ConfigXML.GetClasseAnaliseConta().EmiteAvisoVariacao(_matricula))
				_impressora.printText("CONSTATADA VARIACAO DE CONSUMO. VERIFIQUE SUA LIGACAO", x, y);

			string linhaDigitavel = formatarLinhaDigitavel(fatura);
			y += 3;
			_impressora.printText(linhaDigitavel, x, y);
			#endregion

			#region IMPRIME MENSAGEM SOCIAL
			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			// VALOR DE Y PARA MENSAGEM SOCIAL
			y += 4;

			if (fatura.ValLeituraReal.HasValue) {
				TimeSpan ts = fatura.DatLeitura.Value - fatura.DatLeituraAnterior.Value;
				string texto = "";

				if (fatura.ValConsumoRateado.HasValue && fatura.ValConsumoRateado.Value > 0) {
					texto += "Leit Real: " + fatura.ValLeituraReal.Value.ToString();
					texto += " - Dias Consumo: " + ts.Days.ToString();
					texto += " - Cons Rateado: " + fatura.ValConsumoRateado.Value.ToString();

				} else {
					texto += "Leitura Real: " + fatura.ValLeituraReal.Value.ToString();
					texto += " - Dias de Consumo: " + ts.Days.ToString();
				}

				_impressora.printText(texto, x, y);
				y += 3;
			}
			if (fatura.ValQuantidadePendente.GetValueOrDefault(0) > 0) {
				_impressora.printText("Há debitos. Ligacao sujeita a corte. Procure a SANED.", x, y);
				y += 3;
			}

			// Inicializa variáveis de mensagem
			int prioridadeMsg = 9;
			string mensagem1 = string.Empty;
			string mensagem2 = string.Empty;
			string mensagem3 = string.Empty;
			string mensagem4 = string.Empty;

			// Busca mensagens
			OnpMensagemMovimento ommFilter = new OnpMensagemMovimento();
			Collection<OnpMensagemMovimento> mensagens = ommFilter.SelectCollection();

			// Percorre lista mensagens
			foreach (OnpMensagemMovimento omm in mensagens) {
				if (prioridadeMsg > 1 && omm.SeqMatricula == fatura.SeqMatricula) {
					mensagem1 = subStringOk(omm.DesMensagemMovimento, 0, 62);
					mensagem2 = subStringOk(omm.DesMensagemMovimento, 62, 62);
					mensagem3 = subStringOk(omm.DesMensagemMovimento, 124, 62);
					mensagem4 = subStringOk(omm.DesMensagemMovimento, 186, 62);
					prioridadeMsg = 1;
				} else if (prioridadeMsg > 2 && omm.SeqRoteiro == fatura.Movimento.SeqRoteiro && !omm.SeqMatricula.HasValue) {
					mensagem1 = subStringOk(omm.DesMensagemMovimento, 0, 62);
					mensagem2 = subStringOk(omm.DesMensagemMovimento, 62, 62);
					mensagem3 = subStringOk(omm.DesMensagemMovimento, 124, 62);
					mensagem4 = subStringOk(omm.DesMensagemMovimento, 186, 62);
					prioridadeMsg = 2;
				} else if (prioridadeMsg > 3 && omm.SeqGrupoFatura == fatura.Movimento.Roteiro.SeqGrupoFatura && !omm.SeqRoteiro.HasValue && !omm.SeqMatricula.HasValue) {
					mensagem1 = subStringOk(omm.DesMensagemMovimento, 0, 62);
					mensagem2 = subStringOk(omm.DesMensagemMovimento, 62, 62);
					mensagem3 = subStringOk(omm.DesMensagemMovimento, 124, 62);
					mensagem4 = subStringOk(omm.DesMensagemMovimento, 186, 62);
					prioridadeMsg = 3;
				} else if (prioridadeMsg > 4 && omm.SeqMensagemMovimento.Value == 0) {
					mensagem1 = subStringOk(omm.DesMensagemMovimento, 0, 62);
					mensagem2 = subStringOk(omm.DesMensagemMovimento, 62, 62);
					mensagem3 = subStringOk(omm.DesMensagemMovimento, 124, 62);
					mensagem4 = subStringOk(omm.DesMensagemMovimento, 186, 62);
					prioridadeMsg = 4;
				}

			}
			if (prioridadeMsg != 9) {
				_impressora.printText(mensagem1, x, y);
				_impressora.printText(mensagem2, x, y + 3);
				_impressora.printText(mensagem3, x, y + 6);
				_impressora.printText(mensagem4, x, y + 9);
				y += 9;
			}

			#endregion

			#region PARAMETROS DA QUALIDADE DA AGUA
			// Lista os parametros
			OnpQualidadeAgua agua = new OnpQualidadeAgua();
			agua.SeqZonaAbastecimento = _matricula.SeqZonaAbastecimento;
			Collection<OnpQualidadeAgua> listAgua = agua.SelectCollection();

			if (listAgua.Count > 0 && listAgua[0].DatReferencia.HasValue) {
				string dataReferencia = listAgua[0].DatReferencia.Value.ToString("MM/yyyy");
				_impressora.printText(dataReferencia, x + 12, 167);
			}

			for (int i = 0; i < listAgua.Count; i++) {
				int xQa = 0;
				OnpQualidadeAgua oqa = listAgua[i];

				if (oqa.SeqParametro.Value == 2) // cloro residual
					xQa = x + 29;
				else if (listAgua[i].SeqParametro.Value == 4) // turbidez
					xQa = x + 42;
				else if (listAgua[i].SeqParametro.Value == 5) // fluoreto
					xQa = x + 56;
				else if (listAgua[i].SeqParametro.Value == 6) // coliformes
					xQa = x + 70;
				else if (listAgua[i].SeqParametro.Value == 3) // cor aparente
					xQa = x + 83;

				if (xQa != 0) {
					_impressora.printText(oqa.ValRealizadas.GetValueOrDefault(0).ToString(), xQa, 173);
					_impressora.printText(oqa.ValForaLimite.GetValueOrDefault(0).ToString(), xQa, 177);
				}
			}
			#endregion

			#region CODIGO DE BARRAS
			// VALOR DE Y PARA CODIGO DE BARRAS
			if (fatura.ValValorFaturado.Value == 0) {
				y = 191;

				_impressora.Fonte = 7;
				_impressora.FonteSize = 1;

				if (fatura.ValValorCredito.GetValueOrDefault(0) < 0) {
					_impressora.printText("CONTA COM VALOR ZERADO DEVIDO A CREDITO.", x, y);
					_impressora.printText("CREDITO DE " + formatarMonetario(Math.Abs(fatura.ValValorCredito.Value)) + " SERA LANCADO EM CONTA FUTURA", x, y + 5);
				} else if (fatura.ValValorCredito.GetValueOrDefault(0) > 0) {
					_impressora.printText("CONTA COM VALOR ZERADO.", x, y);
					_impressora.printText("DEBITO DE " + formatarMonetario(Math.Abs(fatura.ValValorCredito.Value)) + " SERA LANCADO EM CONTA FUTURA", x, y + 5);
				} else {
					_impressora.printText("CONTA COM VALOR ZERADO.", x, y);
				}
			} else {
				y = 186;

				if (_matricula.Movimento.IndEntregaEspecial.Equals("1"))
					_impressora.printText("DEBITO AUTOMATICO - " + _matricula.Movimento.DesBancoDebito + " - " + _matricula.Movimento.DesBancoAgenciaDebito, x, y);

				y += 3;
				_impressora.printBarCode(fatura.DesCodigoBarras, x, y);

				linhaDigitavel = formatarLinhaDigitavel(fatura);

				y += 13;
				_impressora.Fonte = 7;
				_impressora.FonteSize = 1;
				_impressora.printText(linhaDigitavel, x, y);
			}
			#endregion

			#region DADOS RODAPE DA FATURA
			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			y = 216;

			_impressora.printText(formatarMatricula(_matricula.SeqMatricula.Value), x, y);
			_impressora.printText(formatarReferencia(fatura.CodReferencia), x + 27, y);
			_impressora.printText(fatura.DatVencimento.Value.ToString("dd/MM/yyyy"), x + 47, y);
			_impressora.printTextRight(formatarMonetario(fatura.ValValorFaturado.Value), x + 89, y);
			#endregion
		}

		private CalculaTaxasDiadema Recalcular(OnpFatura fatura) {
			OnpFaturaCategoria fc = fatura.Categorias[0];
			CalculaTaxasDiadema ct = ConfigXML.GetClasseCalculoTaxas() as CalculaTaxasDiadema;

			ct.DistribuiConsumo = false;
			ct.Fatura = fatura;
			ct.Movimento = fatura.Movimento;
			ct.MatriculaDiadema = _matriculaDiadema;
			ct.CalcularCategoria(fc);

			return ct;
		}

		/// <summary>
		/// Monta um teste simples de impressao com estatisticas de leitura do roteiro atual
		/// </summary>
		/// <param name="agente"></param>
		/// <param name="grupoRoteiro"></param>
		/// <param name="estatisticas"></param>
		protected void montaTeste(OnpAgente agente, string grupoRoteiro, string[] estatisticas) {
			_impressora.Fonte = 5;
			_impressora.FonteSize = 2;

			int x = 7, y = 97;

			_impressora.printText("ROTEIRO: " + grupoRoteiro, x, y);
			_impressora.printText("AGENTE: " + agente.CodAgente.ToString(), x + 50, y);

			y += 7;
			_impressora.printText("ESTATISTICAS DE LEITURAS", x, y);

			_impressora.Fonte = 7;
			_impressora.FonteSize = 0;

			y += 7;
			_impressora.printText("Total: " + estatisticas[4], x, y);
			_impressora.printText("Processadas: " + estatisticas[1], x, y + 3);
			_impressora.printText("Emitidas: " + estatisticas[2], x, y + 6);
			_impressora.printText("Retidas: " + estatisticas[3], x, y + 9);
		}

		/// <summary>
		/// Imprimi informacoes comuns a todos os tipos de contas
		/// </summary>
		private void ImprimiCabecalho(bool avisoDebito) {
			int y, x;

			#region DADOS DA MATRICULA E HIDROMETRO
			_impressora.FonteSize = 0;

			y = 26;
			x = 7;

			_impressora.printText(formatarMatricula(_matricula.SeqMatricula.Value), x, y);
			_impressora.printText(_matricula.Movimento.CodHidrometro, x + 23, y);
			if (avisoDebito) {
				_impressora.printText("**/****", x + 47, y);
				_impressora.printText("**/**/****", x + 70, y);
			} else {
				_impressora.printText(formatarReferencia(_matricula.Movimento.CodReferencia), x + 47, y);
				_impressora.printText(_matricula.Movimento.DatVencimento.Value.ToString("dd/MM/yyyy"), x + 70, y);
			}
			#endregion

			#region DADOS NOME E ENDERECO CLIENTE
			y = 33;

			_impressora.printText(_matricula.NomCliente, x, y);

			y += 3;

			string rua = _matricula.Logradouro.DesLogradouro;
			string numero = _matricula.ValNumeroImovel.ToString();
			_impressora.printText(rua + ", " + numero + ", " + _matricula.DesComplemento, x, y);

			y += 3;

			if (!string.IsNullOrEmpty(_matricula.DesEnderecoAlternativo))
				_impressora.printText("Entrega:" + _matricula.DesEnderecoAlternativo, x, y);
			#endregion

			#region DEBITO AUTOMATICO
			y += 3;
			if (_matricula.Movimento.IndEntregaEspecial.Equals("1") && !avisoDebito)
				_impressora.printText("DEBITO AUTOMATICO - " + _matricula.Movimento.DesBancoDebito + " - " + _matricula.Movimento.DesBancoAgenciaDebito, x, y);
			#endregion // Debito Automatico

			#region DADOS CATEGORIA/ECONOMIA E INSCRICAO/SEQUENCIA
			y = 51;

			string categoriaEconomia = string.Empty;
			foreach (OnpMovimentoCategoria movCat in _matricula.Movimento.MovimentosCategoria)
				categoriaEconomia = categoriaEconomia + " " + movCat.Categoria.DesCategoria.Substring(0, 3) + "/" + movCat.ValNumeroEconomia.ToString();

			_impressora.printText(categoriaEconomia.Trim(), x, y);

			string seqRoteiro = _matricula.Movimento.SeqRoteiro.ToString().Substring(2);
			string seqSetor = string.Empty;
			string desInscricao = _matricula.DesInscricao;

			_impressora.printText(seqRoteiro + seqSetor + desInscricao + " / " + _matricula.SeqLeitura.Value.ToString(), x + 31, y);
			#endregion
		}
		#endregion // Metodos montagem de conta

		#region Metodos auxiliares
		/// <summary>
		/// Formata a linha digitavel para ser impressa
		/// </summary>
		/// <param name="fatura"></param>
		/// <returns></returns>
		private string formatarLinhaDigitavel(OnpFatura fatura) {
			string linhaDigitavel = string.Empty;
			for (int i = 1; i < fatura.DesLinhaDigitavel.Length + 1; i++) {
				linhaDigitavel += fatura.DesLinhaDigitavel[i - 1];
				if ((i % 12) == 0)
					linhaDigitavel += "  ";
			}
			return linhaDigitavel;
		}

		/// <summary>
		/// Formata a matricula para ter o formato de 7 digito (com zeros a esquerda) e digito verificador
		/// </summary>
		/// <param name="seqMatricula">Sequencial da matricula a ser formatada</param>
		/// <returns>Retorna a string com o matricula formatada</returns>
		private string formatarMatricula(int seqMatricula) {
			return zerosEsquerda(seqMatricula.ToString(), 7) + "-" + calculaDigitoModulo10(seqMatricula);
		}

		/// <summary>
		/// Extrai o mes e o ano do código de refêrencia passado
		/// </summary>
		/// <param name="codReferencia"></param>
		/// <param name="mes"></param>
		/// <param name="ano"></param>
		protected void getMesAno(string codReferencia, out string mes, out string ano) {
			ano = codReferencia.Substring(0, 4);
			mes = codReferencia.Substring(5).Trim();
		}

		/// <summary>
		/// Preenche a string passada com zeros a esquerda até completar o numero de digitos passado
		/// </summary>
		/// <param name="valor">String com numeros</param>
		/// <param name="tamanhoTotal">Numero de digitos que a string deve ter no total</param>
		/// <returns></returns>
		protected string zerosEsquerda(string valor, int tamanhoTotal) {
			int numZeros = tamanhoTotal - valor.Length;
			string result = new string('0', numZeros);
			return result + valor;
		}

		/// <summary>
		/// Formata o valor passado em uma string que representa o valor
		/// </summary>
		/// <param name="valor">Valor a ser formatado</param>
		/// <returns>Retorna a string formatada usando locale "pt-br"</returns>
		protected virtual string formatarMonetario(double valor) {
			CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("pt-br");
			return valor.ToString("C", ci).Substring(3);
		}

		/// <summary>
		/// Formata a referencia no formato "mes/ano"
		/// </summary>
		/// <param name="codReferencia">Referencia a ser formatada, nao pode ser nulo</param>
		/// <returns>Retorna a string com a referencia formatada</returns>
		protected string formatarReferencia(string codReferencia) {
			string mes, ano;
			getMesAno(codReferencia, out mes, out ano);
			return zerosEsquerda(mes, 2) + "/" + ano;
		}

		/// <summary>
		/// Retorna uma substring de uma string respeitando um tamanho maximo
		/// </summary>
		/// <param name="S">String</param>
		/// <param name="start">Posicao de inicio na string</param>
		/// <param name="lenght">Tamanho da substring</param>
		/// <returns>Retorna uma substring de S com tamanho maximo de length</returns>
		protected string subStringOk(string S, int start, int length) {
			return S.Trim().PadRight(start + length, ' ').Substring(start, length).Trim();
		}

		/// <summary>
		/// Calculo de digito da matricula
		/// </summary>
		/// <param name="matricula">Matricula que deve ter digito calculado</param>
		/// <returns>Retorna a string com o digito calculado da matricula</returns>
		protected string calculaDigitoModulo10(int matricula) {
			string digito = string.Empty;
			string strMatricula = matricula.ToString();
			bool multUm = true;
			int somaTotal = 0;

			// Percorre a matrícula recebida por parâmetro do último valor para o primeiro
			// Ex: matricula = 123456
			// Pega o 6 e multiplica por 1 se multUm = true ou por 2 se multUm = false
			// Depois pega o 5 e multiplica por 1 se multUm = true ou por 2 se multUm = false
			// E assim por diante
			for (int i = strMatricula.Length - 1; i >= 0; i--) {
				// Pega valor da posição i de strMatricula
				int valorI = int.Parse(strMatricula.Substring(i, 1));
				int mult;

				if (multUm) {
					mult = valorI * 1;
				} else {
					mult = valorI * 2;
					// Caso mult seja maior que 9, atribui a mult a soma do primeiro número com o segundo
					// Ex: mult = 14 -> 1 + 4 -> mult = 5
					if (mult > 9) {
						int v1 = int.Parse(mult.ToString().Substring(0, 1));
						int v2 = int.Parse(mult.ToString().Substring(1, 1));
						mult = v1 + v2;
					}
				}

				// Altera multUm para true se false e para false se true
				// Para saber quando multiplicar por 1 ou por 2
				multUm = !multUm;

				// Acrescenta a somaTotal o valor de mult
				somaTotal += mult;
			}

			// Pega o resto da divisão de somaTotal por 10
			int resto = somaTotal % 10;

			// Se resto == 0, dígito verificador do CDC será 0
			if (resto == 0) {
				digito = "0";
			}
				// Se resto > 0, dígito verificador do CDC será o resultado da subtração de 10 e resto
			else if (resto > 0) {
				digito = (10 - resto).ToString();
			}

			// Retona dígito verificador
			return digito;
		}
		#endregion // Metodos auxiliares
	}
}
