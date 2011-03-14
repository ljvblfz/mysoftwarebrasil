using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormError : Form {
        ErrorControler controler;

        public FormError(ErrorControler controler) {
            this.controler = controler;
            InitializeComponent();
        }

        private void btnDetalhes_Click(object sender, EventArgs e) {
            txtError.Visible = !txtError.Visible;
            if (txtError.Visible)
                btnDetalhes.Text = "<< Ocultar";
            else
                btnDetalhes.Text = "Detalhes >>";
        }

        public void Show(string mensagem, Exception erro) {
            lblMensagem.Text = mensagem;
            txtError.Text =
                erro.ToString() +
                "============================\n" +
                erro.StackTrace.ToString();
            this.ShowDialog();
        }

        private void Error_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
        }

    }
}