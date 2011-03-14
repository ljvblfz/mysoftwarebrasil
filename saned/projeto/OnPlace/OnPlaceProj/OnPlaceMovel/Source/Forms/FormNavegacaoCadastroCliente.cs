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

    public partial class FormNavegacaoCadastroCliente : Form {

        private bool fechando = false;

        #region ATRIBUTOS

        private NavegacaoCadastroClienteController navCadCliControl;
        private OnpCadastroCliente cliente;

        #endregion

        #region GET E SET

        public OnpCadastroCliente Cliente {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        #endregion

        #region CONTRUTORES

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public FormNavegacaoCadastroCliente(NavegacaoCadastroClienteController navCadCliControl) {
            InitializeComponent();
            this.navCadCliControl = navCadCliControl;
            if (navCadCliControl.ClientesCadastrados.Count > 0) {
                Cliente = navCadCliControl.ClientesCadastrados[0];
                SetaCamposObjetoTela();
                AtualizarTela();
            }
        }

        #endregion

        #region METODOS PRIVADOS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            navCadCliControl.NovoCadastro();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            navCadCliControl.AlterarCadastro();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnterior_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            string respProxCliente = navCadCliControl.ProximoCliente(-1);
            if (string.IsNullOrEmpty(respProxCliente)) {
                SetaCamposObjetoTela();
            } else {
                MessageBox.Show(respProxCliente);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProximo_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            string respProxCliente = navCadCliControl.ProximoCliente(1);
            if (string.IsNullOrEmpty(respProxCliente)) {
                SetaCamposObjetoTela();
            } else {
                MessageBox.Show(respProxCliente);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetaCamposObjetoTela() {
            lblSeqCliente.Text = Cliente.SeqCadastroCliente.ToString();
            lblNome.Text = Cliente.DesNomeCliente;
            lblNHD.Text = Cliente.CodHidrometro.ToString();
            OnpLogradouro logradouro = new OnpLogradouro(Cliente.SeqLogradouro);
            lblLogradouro.Text = logradouro.DesLogradouro;
        }

        /// <summary>
        /// Atualiza campos da tela
        /// </summary>
        public void AtualizarTela() {
            if (navCadCliControl.ClientesCadastrados.Count > 0)
                btnAlterar.Enabled = true;
            else
                btnAlterar.Enabled = false;
        }

        #endregion

        private void FormNavegacaoCadastroCliente_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
                btnNovo_Click(null, null);
                fechando = true;
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            if (navCadCliControl.ClientesCadastrados.Count > 0) {
                Cliente = navCadCliControl.ClientesCadastrados[0];
                SetaCamposObjetoTela();
            } else {
                MessageBox.Show("Não há clientes cadastrados!");
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e) {
            if (fechando)
                return;

            if (navCadCliControl.ClientesCadastrados.Count > 0) {
                Cliente = navCadCliControl.ClientesCadastrados[navCadCliControl.ClientesCadastrados.Count - 1];
                SetaCamposObjetoTela();
            } else {
                MessageBox.Show("Não há clientes cadastrados!");
            }
        }

    }

}