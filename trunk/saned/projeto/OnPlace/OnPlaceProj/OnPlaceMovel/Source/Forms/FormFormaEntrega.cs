using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormFormaEntrega : Form {
		#region Atributos e Propriedades
		FormaEntregaController _controler;
		#endregion // Atributos e Propriedades

		public FormFormaEntrega(FormaEntregaController controler) {
            InitializeComponent();
            
			_controler = controler;
            
			loadTiposEntrega();
			
			btnConfirma.Focus();
		}

		#region Metodos Privados
		/// <summary>
		/// Carrega os tipos de entrega
		/// </summary>
		private void loadTiposEntrega() {
			// Limpa a lista
			lstFormaEntrega.Items.Clear();
			foreach (OnpTipoEntrega tipoEntrega in _controler.TiposDeEntrega()) {
				lstFormaEntrega.Items.Add(tipoEntrega);
			}
		}
		#endregion // Metodos Privados

		#region Eventos de Controles
		private void btnConfirma_Click(object sender, EventArgs e) {
            if (lstFormaEntrega.SelectedItem != null) {
				OnpTipoEntrega tipoEntrega = lstFormaEntrega.SelectedItem as OnpTipoEntrega;
				_controler.SetTipoEntrega(tipoEntrega); 
				Close();
			} else {
				MessageBox.Show("Seleciona uma forma de entrega.", "OnPlace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
		}
		#endregion // Eventos de Controles

		#region Eventos do Form
		private void FormaEntrega_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
            lstFormaEntrega.SelectedItem = null;
        }

		/// <summary>
		/// Mapeamento do teclado para funções da tela
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void FormFormaEntrega_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.D0:
					SelecionarEntrega(0);
					break;

				case Keys.D1:
					SelecionarEntrega(1);
					break;

				case Keys.D2:
					SelecionarEntrega(2);
					break;

				case Keys.D3:
					SelecionarEntrega(3);
					break;

				case Keys.D4:
					SelecionarEntrega(4);
					break;

				case Keys.D5:
					SelecionarEntrega(5);
					break;

				case Keys.D6:
					SelecionarEntrega(6);
					break;

				case Keys.D7:
					SelecionarEntrega(7);
					break;

				case Keys.D8:
					SelecionarEntrega(8);
					break;

				case Keys.D9:
					SelecionarEntrega(9);
					break;

				case Keys.Enter:
	                btnConfirma_Click(null, null);
					break;
			}
		}

		/// <summary>
		/// Seleciona o tipo de entrega que tem o codigo passado
		/// </summary>
		/// <param name="seqTipoEntrega"></param>
		private void SelecionarEntrega(int seqTipoEntrega) {
			foreach (object fe in lstFormaEntrega.Items) {
				if (((OnpTipoEntrega)fe).SeqTipoEntrega.Value == seqTipoEntrega) {
					lstFormaEntrega.SelectedItem = fe;
					btnConfirma.Focus();
					break;
				}
			}
		}
		#endregion // Eventos do Form
	}
}