using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
using OnPlaceMovel.Source.Impressao;
using Strategos.Api.Log4CS;
using OnPlaceMovel.Source.Diadema;

namespace OnPlaceMovel.Source.Controladores {
	public class ImpressaoController: IImpressaoController {
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

		public void MostrarImpressao(OnpMatricula matricula) {
			_matricula = matricula;

			_impressao = ConfigXML.GetClasseImpressao();

			_formImpressao = new FormImpressao(this);
			_formImpressao.ShowDialog();
		}

		#region Metodos publicos
		public void Dispose() {
			if (_formImpressao != null)
				_formImpressao.Dispose();
		}

		public bool MarcaFatura() {
			return (
				!_matricula.Movimento.naoEmitePorOcorrencia() &&
				(
					ConfigXML.GetClasseAnaliseConta().RetemParaAnalise(_matricula.Movimento) ||
					(
						_matricula.Movimento.Fatura != null &&
						(
							_matricula.Movimento.IndEntregaEspecial.Equals("0") ||
							_matricula.Movimento.IndEntregaEspecial.Equals("1")
						)
					)
				)
			);
		}

		public bool MarcaAviso() {
			return _matricula.Aviso != null && _matricula.Aviso.FaturasAviso != null; // && _matricula.Aviso.FaturasAviso.Count > 0;
		}

		public void EmiteDocumento(bool emiteFatura, bool emiteAviso, Collection<OnpFatura> faturas) {
			bool podeSair = false;
			int tentativas = 0;

			do {
				//try {
					tentativas++;

					// EMITE FATURA
					if (emiteFatura) {
						if (_impressao.printFatura(_matricula)) {
							_matricula.IndImpresso = "S";

							_matricula.Movimento.IndFaturaEmitida = "S";
							_matricula.Movimento.Persist();

							if (_matricula.Movimento.Fatura != null) {
								_matricula.Movimento.Fatura.IndFaturaEmitida = "S";
								_matricula.Movimento.Fatura.Persist();
							}

							// Forma de entrega
							FormaEntregaController formaEntregaControler = new FormaEntregaController();
							formaEntregaControler.MostraFormaEntrega(_matricula);
							formaEntregaControler.Dispose();
						}
					} else {
						_matricula.Movimento.IndFaturaEmitida = "N";
						_matricula.Movimento.Persist();

						if (_matricula.Movimento.Fatura != null) {
							_matricula.Movimento.Fatura.IndFaturaEmitida = "N";
							_matricula.Movimento.Fatura.Persist();
						}
					}

					// EMITE AVISO
					if (emiteAviso) {
						if (_matricula.Aviso != null && _impressao.printAvisoDebito(_matricula)) {
							_matricula.Aviso.ValImpressoes = _matricula.Aviso.ValImpressoes.GetValueOrDefault(0) + 1;
							_matricula.Aviso.IndProtocolado = avisoProtocolado() ? "S" : "N";
							_matricula.Aviso.Persist();
						}
					}

					// EMITE A 2a VIA DA REFERENCIA
					foreach (OnpFatura fatura in faturas)
						_impressao.print2aVia(fatura);

					_matricula.IndProcessado = "S";
					_matricula.Persist();
					podeSair = true;
                //} catch (Strategos.Api.Database.Impl.PersistException ex) {
                //    Log4CS.Error(ex.Message);
                //    throw ex;
                //} catch (NullReferenceException ex) {
                //    Log4CS.Error(ex.Message);
                //    throw ex;
                //} catch (InvalidOperationException ex) {
                //    Log4CS.Error(ex.Message);
                //    throw ex;
                //} catch (Exception ex) {
                //    Log4CS.Error(ex.Message);
                //    MessageBox.Show("Erro ao tentar imprimir, verifica se a impressora esta ligada. (tentativa " + tentativas.ToString() + ")");
                //    podeSair = tentativas >= MAX_TENTIVAS;
                //}
			} while (!podeSair);
		}
		#endregion

		#region Metodos privados
		/// <summary>
		/// Verifica se aviso foi protocolado e entregue
		/// </summary>
		/// <returns></returns>
		private bool avisoProtocolado() {
			bool protocolado = false;

			DialogResult entregue = MessageBox.Show("O aviso de débito foi entregue?", "OnPlaceMovel", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (entregue == DialogResult.Yes) {
				DialogResult result = MessageBox.Show("E foi protocolado?", "OnPlaceMovel",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

				protocolado = (result == DialogResult.Yes);
			}

			return protocolado;
		}
		#endregion
	}
}
