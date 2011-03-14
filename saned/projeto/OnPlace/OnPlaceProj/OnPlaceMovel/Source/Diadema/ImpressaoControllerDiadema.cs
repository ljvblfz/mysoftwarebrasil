using System;
using System.Text;
using System.Collections.Generic;
using OnPlaceMovel.Source.Controladores;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.Forms;
using Strategos.Api.Log4CS;
using System.Windows.Forms;
using Strategos.Api.Database;
using Strategos.Api.Database.Impl;

namespace OnPlaceMovel.Source.Diadema {
	public class ImpressaoControllerDiadema: IImpressaoController {
		#region Atributos
		private const int MAX_TENTIVAS = 3;
		private IImpressao _impressao;
		private OnpMatricula _matricula;
		private FormImpressao _formImpressao;

		public OnpMatricula Matricula {
			get { return _matricula; }
			set { _matricula = value; }
		}
		#endregion

		public ImpressaoControllerDiadema() {
			_impressao = ConfigXML.GetClasseImpressao();
		}

		public void MostrarImpressao(OnpMatricula matricula) {
			_matricula = matricula;

			_formImpressao = new FormImpressao(this);
			_formImpressao.ShowDialog();
		}

		#region Metodos publicos
		public bool MarcaFatura() {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(_matricula.SeqMatricula.Value);

			if (matd.IndCalculaFatura.Equals("N") || matd.IndEmiteFatura.Equals("N"))
				return false;

			if (_matricula.Movimento.naoEmitePorOcorrencia())
				return false;

			// nao emite para pais do tipo fatura composta e pai de apartamento
			if (matd.SeqMatriculaPai.HasValue && matd.SeqMatriculaPai == matd.SeqMatricula) {
				if (matd.Matricula.Movimento.IndSituacaoMovimento.Equals("R") &&
					!matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.FaturaComposta3) &&
					!matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.FaturaComposta8) &&
					!matd.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDApartamento))
					return false;
			}
																			
			return _matricula.Movimento.IndSituacaoMovimento.Equals("R") || _matricula.Movimento.Fatura != null;
		}

		public bool MarcaAviso() {
			return _matricula.Aviso != null && _matricula.Aviso.FaturasAviso != null;// && _matricula.Aviso.FaturasAviso.Count > 0;
		}

		public void Dispose() {
			if (_formImpressao != null)
				_formImpressao.Dispose();
		}

		public void EmiteDocumento(bool emiteFatura, bool emiteAviso, Collection<OnpFatura> faturas) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(_matricula.SeqMatricula.Value);

			if (matd.MatriculaPai.IndTipoConsumidor.Equals(OnpMatriculaDiadema.TipoConsumidor.HDApartamento) && !matd.MatriculaPai.temFilhosRetido()) {
				DialogResult result = MessageBox.Show("Deseja imprimir todos os filhos da matricula pai? (Não = imprime somente da matricula selecionada)", "OnPlaceMovel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

				if (result == DialogResult.Yes) {
					bool formaEntrega = true;

					ProgressoController ProgressBar = new ProgressoController(false);
					ProgressBar.valorMin = 0;
					ProgressBar.valorMax = matd.MatriculaPai.Filhos.Count;
					ProgressBar.Posicao = 0;
					ProgressBar.Show();
					ProgressBar.Refresh();

					foreach (OnpMatriculaDiadema md in matd.MatriculaPai.Filhos) {
						ProgressBar.Mensagem = "Imprimindo " + (ProgressBar.Posicao + 1).ToString() + " de " + matd.MatriculaPai.Filhos.Count.ToString();
						ProgressBar.Show();
						ProgressBar.Refresh();

						Imprimir(md.Matricula, formaEntrega, true, emiteAviso, null);
						if (formaEntrega)
							matd.MatriculaPai.SetTipoEntregaFilhos(md.Matricula.Movimento.SeqTipoEntrega.Value);

						formaEntrega = false;
						ProgressBar.Posicao += 1;

						md.Matricula = null;
					}

					ProgressBar.Dispose();
				} else if (result == DialogResult.No) {
					if (matd.isFilho)
						Imprimir(_matricula, true, emiteFatura, emiteAviso, faturas);
					else
						MessageBox.Show("Esta é matricula pai e não sera impressa!", "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				}
			} else {
				Imprimir(_matricula, true, emiteFatura, emiteAviso, faturas);
			}

		}

		private void Imprimir(OnpMatricula matricula, bool mostrarFormaEntrega, bool emiteFatura, bool emiteAviso, Collection<OnpFatura> faturas) {
			bool podeSair = false;
			int tentativas = 0;

			do {
				tentativas++;

				try {
					// EMITE FATURA
					if (emiteFatura) {
						if (true) {//_impressao.printFatura(matricula)) {
							matricula.IndImpresso = "S";

							if (mostrarFormaEntrega) {
								FormaEntregaController formaEntregaControler = new FormaEntregaController();
								formaEntregaControler.MostraFormaEntrega(matricula);
							}

							matricula.Movimento.IndFaturaEmitida = "S";
							matricula.Movimento.ValImpressoes = matricula.Movimento.ValImpressoes.GetValueOrDefault(0) + 1;
							matricula.Movimento.Persist();

							if (matricula.Movimento.Fatura != null) {
								matricula.Movimento.Fatura.IndFaturaEmitida = matricula.Movimento.IndFaturaEmitida;
								matricula.Movimento.Fatura.ValImpressoes = matricula.Movimento.Fatura.ValImpressoes.GetValueOrDefault(0) + 1;
								matricula.Movimento.Fatura.DatHoraEmissao = DateTime.Now;
								matricula.Movimento.Fatura.Persist();
							}
						}
					} else {
						matricula.Movimento.IndFaturaEmitida = "N";
						matricula.Movimento.Persist();

						if (matricula.Movimento.Fatura != null) {
							matricula.Movimento.Fatura.IndFaturaEmitida = matricula.Movimento.IndFaturaEmitida;
							matricula.Movimento.Fatura.Persist();
						}
					}

					// EMITE AVISO
					if (emiteAviso) {
						if (matricula.Aviso != null && _impressao.printAvisoDebito(_matricula)) {
							matricula.Aviso.ValImpressoes = matricula.Aviso.ValImpressoes.GetValueOrDefault(0) + 1;
							matricula.Aviso.Persist();
						}
					}

					// EMITE A 2a VIA DA REFERENCIA
					if (faturas != null)
						foreach (OnpFatura fatura in faturas) {
							_impressao.print2aVia(fatura);
							fatura.ValImpressoes = fatura.ValImpressoes.GetValueOrDefault(0) + 1;
							fatura.IndFaturaEmitida = "S";
						}

					matricula.IndProcessado = "S";
					matricula.Persist();

					podeSair = true;
				} catch (PersistException ex) {
					Log4CS.Error(ex.Message);
					throw ex;
				} catch (NullReferenceException ex) {
					Log4CS.Error(ex.Message);
					throw ex;
				} catch (InvalidOperationException ex) {
					Log4CS.Error(ex.Message);
					throw ex;
				} catch (Exception ex) {
					Log4CS.Error(ex.Message);
					MessageBox.Show("Erro ao tentar imprimir, verifica se a impressora esta ligada. (tentativa " + tentativas.ToString() + " de " + MAX_TENTIVAS.ToString() + ")");
					podeSair = tentativas >= MAX_TENTIVAS;
				}
			} while (!podeSair);
		}
		#endregion
	}
}
