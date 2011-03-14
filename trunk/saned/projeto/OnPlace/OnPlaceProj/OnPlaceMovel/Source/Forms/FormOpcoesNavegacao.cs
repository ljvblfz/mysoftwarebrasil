using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormOpcoesNavegacao : Form {
        #region Atributos e Propriedades
        private OpcoesNavegacaoController _controller;

        private OnpMatricula _matricula;
        public OnpMatricula Matricula {
            get {
                return _matricula;
            }
        }

        public bool OrdemCrescente {
            get {
                return rbtnCrescente.Checked;
            }
            set {
                rbtnCrescente.Checked = value;
                rbtnDecrescente.Checked = !rbtnCrescente.Checked;
            }
        }

        public bool OrdemDecrescente {
            get {
                return rbtnDecrescente.Checked;
            }
            set {
                rbtnCrescente.Checked = !rbtnDecrescente.Checked;
                rbtnDecrescente.Checked = value;
            }
        }

        public bool IncluirLidas {
            get {
                return chkLidas.Checked;
            }
            set {
                chkLidas.Checked = value;
            }
        }

        public bool IncluirNaoLidas {
            get {
                return chkNaoLidas.Checked;
            }
            set {
                chkNaoLidas.Checked = value;
            }
        }

        public bool PorRoteiro {
            get {
                return rbtnRoteiro.Checked;
            }
            set {
                rbtnRoteiro.Checked = value;
                rbtnLogradouro.Checked = !rbtnRoteiro.Checked;
            }
        }

        public bool PorLogradouro {
            get {
                return rbtnLogradouro.Checked;
            }
            set {
                rbtnRoteiro.Checked = !rbtnLogradouro.Checked;
                rbtnLogradouro.Checked = value;
            }
        }

        public OnpLogradouro Logradouro {
            get {
                return cboxLogradouros.SelectedItem as OnpLogradouro;
            }
            set {
                cboxLogradouros.SelectedItem = value;
            }
        }
        #endregion // Atributos e Propriedades

        public FormOpcoesNavegacao(OpcoesNavegacaoController controller) {
            InitializeComponent();

            _controller = controller;

            foreach (OnpLogradouro lg in _controller.listLogradouros()) {
                cboxLogradouros.Items.Add(lg);
                cboxLogradouroBusca.Items.Add(lg);
            }

			Reset();
        }

        #region Eventos do Form
        /// <summary>
        /// Chama quando o form ganha foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pesquisa_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
            _matricula = null;
			Reset();
        }

        /// <summary>
        /// Executa validações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOpcoesNavegacao_Closing(object sender, CancelEventArgs e) {
            if (this.DialogResult == DialogResult.Cancel)
                _matricula = null;
        }

        #endregion // Eventos do Form

        #region Eventos aba de opções
        /// <summary>
        /// Ativa ou desativa a combo box de logradouros conforme necessario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnLogradouro_CheckedChanged(object sender, EventArgs e) {
            cboxLogradouros.Enabled = rbtnLogradouro.Checked;
        }
        #endregion

        #region Eventos aba de busca
        /// <summary>
        /// Esconde o texto de nao encontrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxLogradouroBusca_SelectedIndexChanged(object sender, EventArgs e) {
            if (lblEndNaoEncontrado.Visible) {
                lblEndNaoEncontrado.Visible = false;
            }
        }

        /// <summary>
        /// Esconde o texto de nao encontrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeroMovel_TextChanged(object sender, EventArgs e) {
            try {
                if (lblEndNaoEncontrado.Visible) {
                    lblEndNaoEncontrado.Visible = false;
                } else {
                    int.Parse((sender as TextBox).Text);
                }
            } catch (FormatException) {
            }
        }

        /// <summary>
        /// Valida e busca por sequencial de matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarMatricula_Click(object sender, EventArgs e) {
            try {
                int seqMatricula = int.Parse(txtMatricula.Text);

                _matricula = OnpMatricula.Materialize(seqMatricula);
                lblMatNaoEcontrada.Visible = _matricula == null;

                if (!lblMatNaoEcontrada.Visible) {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            } catch (FormatException) {
                MessageBox.Show("Entre com uma matrícula válida.");
            }
        }

        /// <summary>
        /// Valida e busca por sequencial de leitura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscaLeitura_Click(object sender, EventArgs e) {
            try {
                int seqLeitura = int.Parse(txtLeitura.Text);

                _matricula = new OnpMatricula();
                _matricula.SeqLeitura = int.Parse(txtLeitura.Text);
                lblLeiNaoEncontrado.Visible = !_matricula.Select();

                if (!lblLeiNaoEncontrado.Visible) {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            } catch (FormatException) {
                MessageBox.Show("Entre com um código de leitura válido.");
            }
        }

        /// <summary>
        /// Valida e busca por codigo de hidrometro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscaHidrometro_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtHidrometro.Text)) {
                MessageBox.Show("Entre com um código de hidrômetro válido.");
            } else {
                lblHidNaoEncontrado.Visible = false;

                OnpMovimento movimento = new OnpMovimento();
                movimento.CodHidrometro = txtHidrometro.Text;
                lblHidNaoEncontrado.Visible = !movimento.Select();

                if (!lblHidNaoEncontrado.Visible) {
                    _matricula = movimento.Matricula;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        /// <summary>
        /// Valida e busca por endereco de numero de imovel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscaEndereco_Click(object sender, EventArgs e) {
            if (cboxLogradouroBusca.SelectedItem == null || string.IsNullOrEmpty(txtNumeroMovel.Text)) {
                MessageBox.Show("Selecione o logradouro e entre com numero do imovel");
            } else {
                OnpMatricula matricula = new OnpMatricula();
                matricula.SeqLogradouro = (cboxLogradouroBusca.SelectedItem as OnpLogradouro).SeqLogradouro;
                matricula.ValNumeroImovel = int.Parse(txtNumeroMovel.Text);
                lblEndNaoEncontrado.Visible = !matricula.Select();

                if (!lblEndNaoEncontrado.Visible) {
                    _matricula = matricula;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        /// <summary>
        /// Esconde texto de "Nao Encontrado" para busca por seq. leitura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLeitura_TextChanged(object sender, EventArgs e) {
            try {
                if (lblLeiNaoEncontrado.Visible) {
                    (sender as TextBox).Text = string.Empty;
                    lblLeiNaoEncontrado.Visible = false;
                } else {
                    int.Parse(txtLeitura.Text);
                }
            } catch {
                txtLeitura.Text = "";
            }
        }

        /// <summary>
        /// Esconde texto de "Nao Encontrado" para busca por seq. matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMatricula_TextChanged(object sender, EventArgs e) {
            if (lblMatNaoEcontrada.Visible) {
                (sender as TextBox).Text = string.Empty;
                lblMatNaoEcontrada.Visible = false;
            }
        }

        /// <summary>
        /// Esconde texto de "Nao Encontrado" para busca por codigo de hidrometro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHidrometro_TextChanged(object sender, EventArgs e) {
            if (lblHidNaoEncontrado.Visible) {
                (sender as TextBox).Text = string.Empty;
                lblHidNaoEncontrado.Visible = false;
            }
        }
        #endregion // Eventos aba de busca

		#region Metodos Auxiliares
		/// <summary>
		/// Limpa os campos da aba de busca
		/// </summary>
		private void Reset() {
			txtMatricula.Focus();

			txtLeitura.Text = string.Empty;
			txtMatricula.Text = string.Empty;
			txtHidrometro.Text = string.Empty;
			txtNumeroMovel.Text = string.Empty;
		}

		#endregion // Metodos Auxiliares

	}
}