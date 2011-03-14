using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormAgenteCarga : Form {

        private bool fechando = false;

        public int Agente {
            get {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                    return -1;
                else
                    return int.Parse(txtUsuario.Text);
            }
        }

        public FormAgenteCarga() {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) {
            if (fechando)
                return;

            try {
                int.Parse(txtUsuario.Text);
            } catch (Exception) {
                txtUsuario.Text = string.Empty;
                MessageBox.Show("Digite somente números para o codigo do agente.");
            }
        }

        private void FormAgenteCarga_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
            fechando = false;
        }

        private void FormAgenteCarga_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
                fechando = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}