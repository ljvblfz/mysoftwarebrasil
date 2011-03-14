using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;
using OnPlaceMovel.Source.Teste;

namespace OnPlaceMovel.Source.Forms {

    public partial class FormBD : Form {
        private BDController bdControl;
        
		public FormBD(BDController bdControl) {
			InitializeComponent();
			this.bdControl = bdControl;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void BD_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;

            btnDesfazerCarga.Enabled = Controlador.Adminstrador;
			btnExecutarTeste.Enabled = Controlador.Adminstrador;
        }

        private void btnDesfazerCarga_Click(object sender, EventArgs e) {
			FormConfirmaSenha formSenhaAdm = new FormConfirmaSenha(ConfigXML.GetAdmPassword());

			if (formSenhaAdm.ShowDialog() == DialogResult.OK && formSenhaAdm.Confirmado)
				if (MessageBox.Show("Deseja desfazer a carga atual?", "OnPlace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
	                bdControl.DesfazerCarga();
        }

        private void btnTesteImpressao_Click(object sender, EventArgs e) {
            bdControl.TesteImpressao();
        }

		private void btnCopiarBase_Click(object sender, EventArgs e) {
            if (BDController.GerarArqCSV(true))
                MessageBox.Show("Cópia executada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else 
                MessageBox.Show("Erro na geração do arquivo!");

		}

		private void btnExecutarTeste_Click(object sender, EventArgs e) {
			bool stopOnError = MessageBox.Show("Deseja parar caso aconteça um erro?", "OnPlace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
			bool imprimirContas = MessageBox.Show("Deseja imprimir todas as contas?", "OnPlace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

			ITesteController testeController = ConfigXML.GetTesteController();

			bool resultadoTeste = testeController.ExecutarTeste(stopOnError, imprimirContas);

			if (!resultadoTeste) {
				if (stopOnError)
					MessageBox.Show("Ocorreu um erro durante o teste, verifique o log do OnPlace!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				else
					MessageBox.Show("Ocorreu pelo menos um erro durante o teste, verifique o log do OnPlace!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			} else {
				MessageBox.Show("Teste executado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
			}
		}
    }
}