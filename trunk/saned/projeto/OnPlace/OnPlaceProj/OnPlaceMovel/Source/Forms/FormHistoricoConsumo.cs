using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.Forms {

    public partial class FormHistoricoConsumo : Form {
		#region Atributos e Propriedades
		private HistoricoConsumoController _hcControl;
		#endregion // Atributos e Propriedades

		public FormHistoricoConsumo(HistoricoConsumoController pHcControl) {
            InitializeComponent();
            _hcControl = pHcControl;
		}

		#region Metodos Publicos
		public void PreencheCamposTela() {
            lblMatricula.Text = "Sem Matricula";
            if (_hcControl.Matricula.SeqMatricula.HasValue)
                lblMatricula.Text = _hcControl.Matricula.SeqMatricula.ToString();

            lbListaHistorico.Items.Clear();
            foreach (OnpHistorico historico in _hcControl.Historico) {
                lbListaHistorico.Items.Add(historico);
            }
		}
		#endregion // Metodos Publicos

		#region Eventos do Form
		private void FormHistoricoConsumo_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
        }

        private void FormHistoricoConsumo_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
                Close();
            }
		}
		#endregion // Eventos do Form
	}
}