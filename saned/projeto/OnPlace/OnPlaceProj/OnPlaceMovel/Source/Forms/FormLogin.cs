using System;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.Controladores;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using System.Reflection;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormLogin : Form {
        private LoginController _loginController;
        private bool fechando = false;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="lControl"></param>
        public FormLogin(LoginController lControl) {
            InitializeComponent();
            _loginController = lControl;
			lblRoteiroValor.Text = OnpRoteiro.GrupoRoteiroCarregado();

			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;
            lblVersaoValor.Text = version.ToString();
        }
														  
        /// <summary>
        /// Validaçao de usuário e senha no sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e) {
            if (fechando && Controlador.Logado)
                return;

            txtUsuario.Enabled = txtSenha.Enabled = btnSair.Enabled = btnOk.Enabled = false;

            if (!string.IsNullOrEmpty(txtUsuario.Text)) {
                _loginController.Agente.CodAgente = int.Parse(txtUsuario.Text);
                _loginController.Agente.DesSenha = txtSenha.Text;
                
				if (_loginController.Autentica())
                    Close();
                else if (_loginController.SITUACAO_DADOS == SituacaoDados.BaseVazia)
					MessageBox.Show("Base de dados esta vazia ou com carga incompleta.");
            } else {
                MessageBox.Show("Coloque um código de usuário e senha.");
            }

            txtUsuario.Enabled = txtSenha.Enabled = btnSair.Enabled = btnOk.Enabled = true;
        }

        private void Login_Closed(object sender, EventArgs e) {
            if ((_loginController.GetLogado() == false) && (_loginController.SITUACAO_DADOS != SituacaoDados.BaseVazia))
                Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    btnOk_Click(null, null);
                    fechando = true;
                    break;
            }
        }

        private void Login_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
            fechando = false;
        }

        /// <summary>
        /// Limpa os campos da tela
        /// </summary>
        public void ClearScreen() {
            txtSenha.Text = string.Empty;
            txtUsuario.Text = string.Empty;
        }

    }
}