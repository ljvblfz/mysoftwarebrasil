using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormDigitosHD : Form {

        private LeituraHDControllerPadrao _leituraControl;
        private bool fechando = false;

        public FormDigitosHD(LeituraHDControllerPadrao leituraControl) {
            InitializeComponent();
            _leituraControl = leituraControl;
            resetValues();
        }

        private void resetValues() {
            comboBoxNumeroDigitos.Items.Clear();
            comboBoxNumeroDigitos.Items.Add("4");
            comboBoxNumeroDigitos.Items.Add("5");
            comboBoxNumeroDigitos.Items.Add("6");
            comboBoxNumeroDigitos.Items.Add("7");
            comboBoxNumeroDigitos.Text = _leituraControl.getNumeroDigitosHD().ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            if (!string.IsNullOrEmpty(comboBoxNumeroDigitos.Text)) {
                _leituraControl.setNumeroDigitosHD(Int16.Parse(comboBoxNumeroDigitos.Text));
                Close();
            } else {
                MessageBox.Show("Informe o número de dígitos");
            }
        }

        private void FormDigitosHD_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
                buttonOk_Click(null, null);
                fechando = true;
            }
        }

    }
}