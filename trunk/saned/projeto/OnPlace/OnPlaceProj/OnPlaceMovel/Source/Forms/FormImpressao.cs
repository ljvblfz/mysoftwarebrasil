using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormImpressao : Form {
        private IImpressaoController _impressaoControl;

        private bool fechando = false;

        public FormImpressao(IImpressaoController impressaoControl) {
            InitializeComponent();

            _impressaoControl = impressaoControl;

			chkFatura.Checked = chkFatura.Enabled = impressaoControl.MarcaFatura();

            lstSegVias.Focus();

			// Deve sempre imprimir o aviso de debito
			chkAviso.Enabled = false;
			chkAviso.Checked = _impressaoControl.MarcaAviso();
            int count = 0;

            foreach (OnpFatura fatura in _impressaoControl.Matricula.Movimento.SegundasVias) {
                string ano = fatura.CodReferencia.Substring(0, 4);
                string mes = fatura.CodReferencia.Substring(5, fatura.CodReferencia.Length - 5).Trim();
                mes = int.Parse(mes).ToString("D2");
                count += 1;

                ListViewItem item = new ListViewItem(mes + "/" + ano);
                item.Tag = fatura;

                lstSegVias.Items.Add(item);
            }
        }

        private void Impressao_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
            fechando = false;
        }

        private void btnEmitir_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            Collection<OnpFatura> faturas = new Collection<OnpFatura>();

            foreach (ListViewItem item in lstSegVias.Items)
                if (item.Checked)
                    faturas.Add((OnpFatura)item.Tag);

            _impressaoControl.EmiteDocumento(
                chkFatura.Checked && chkFatura.Enabled,
                chkAviso.Checked,
                faturas
            );
            Close();
        }

        private void FormImpressao_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
                btnEmitir_Click(null, null);
                fechando = true;
            }
            else if ((e.KeyCode == Keys.F) && chkFatura.Enabled){
                chkFatura.Checked = !chkFatura.Checked;
            }
            else if ((e.KeyCode == Keys.A) && chkAviso.Enabled)
            {
                chkAviso.Checked = !chkAviso.Checked;
            }
            else if (e.KeyCode == Keys.E) {
                btnEmitir_Click(null, null);
            }
            else if (e.KeyCode == Keys.S)
            {
                Close();
            }

        }
    }
}