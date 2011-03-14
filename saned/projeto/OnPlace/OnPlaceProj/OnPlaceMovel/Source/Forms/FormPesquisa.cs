using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.Forms {
	public partial class FormPesquisa : Form {
        #region Atributos e Propriedades
        private OnpMatricula _matricula;
		public OnpMatricula Matricula {
			get { return _matricula; }
        }
        #endregion // Atributos e Propriedades

        public FormPesquisa() {
			InitializeComponent();
        }

        #region Eventos Aba de Busca
        private void btnBuscarMatricula_Click(object sender, EventArgs e) {
			lblMatNaoEcontrada.Visible = false;

			int seqMatricula;
			try {
				seqMatricula = int.Parse(txtMatricula.Text);
			} catch (FormatException) {
				MessageBox.Show("Entre com uma matrícula válida.");
				return;
			}

			_matricula = OnpMatricula.Materialize(seqMatricula);
			lblMatNaoEcontrada.Visible = _matricula == null;

			if (!lblMatNaoEcontrada.Visible) {
				PreencherCampos(_matricula);
				tabControl.SelectedIndex = 1;
			} else
				LimparCampos();
		}

		private void btnBuscaHidrometro_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtHidrometro.Text)) {
				MessageBox.Show("Entre com um código de hidrômetro válido.");
				return;
			}

			lblHidNaoEncontrado.Visible = false;

			OnpMovimento movimento = new OnpMovimento();
			movimento.CodHidrometro = txtHidrometro.Text;
			lblHidNaoEncontrado.Visible = !movimento.Select();

            if (!lblHidNaoEncontrado.Visible) {
                _matricula = movimento.Matricula;
                PreencherCampos(_matricula);
                tabControl.SelectedIndex = 1;
            } else {
                LimparCampos();
            }
        }

        private void btnBuscaLeitura_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtLeitura.Text)) {
                MessageBox.Show("Entre com um código de leitura válido.");
                return;
            }

            lblLeiNaoEncontrado.Visible = false;

            OnpMatricula matricula = new OnpMatricula();
            matricula.SeqLeitura = int.Parse(txtLeitura.Text);
            lblLeiNaoEncontrado.Visible = !matricula.Select();

            if (!lblLeiNaoEncontrado.Visible) {
                _matricula = matricula;
                PreencherCampos(_matricula);
                tabControl.SelectedIndex = 1;
            } else
                LimparCampos();
        }

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

        private void txtMatricula_TextChanged(object sender, EventArgs e) {
            if (lblMatNaoEcontrada.Visible) {
                (sender as TextBox).Text = string.Empty;
                lblMatNaoEcontrada.Visible = false;
            }
        }

        private void txtHidrometro_TextChanged(object sender, EventArgs e) {
            if (lblHidNaoEncontrado.Visible) {
                (sender as TextBox).Text = string.Empty;
                lblHidNaoEncontrado.Visible = false;
            }
        }
        #endregion // Eventos Aba de Busca

        #region Eventos do Form
        private void Pesquisa_Closing(object sender, CancelEventArgs e) {
			if (this.DialogResult == DialogResult.Cancel)
				_matricula = null;
			else if (this.DialogResult == DialogResult.OK && _matricula == null) {
				MessageBox.Show("Procure por uma matrícula válida antes!");
				e.Cancel = true;
			}
		}

		private void Pesquisa_Activated(object sender, EventArgs e) {
			Controlador.ActiveForm = this;
		}

		private void timerEsconder_Tick(object sender, EventArgs e) {
			if (!lblHidNaoEncontrado.Visible)
				lblHidNaoEncontrado.Visible = false;

			if (!lblMatNaoEcontrada.Visible)
				lblMatNaoEcontrada.Visible = false;
        }
        #endregion // Eventos do Form

        #region Metodos privados
        /// <summary>
		/// Preenche os campos da tela com informações de uma matricula
		/// </summary>
		/// <param name="matricula"></param>
		private void PreencherCampos(OnpMatricula matricula) {
			lblNome.Text = matricula.NomCliente;
			lblMatricula.Text = matricula.SeqMatricula.ToString();
			lblLogradouro.Text = matricula.Logradouro.DesLogradouro;

			if (matricula.Movimento.DatLeitura.HasValue)
				lblDtHrColeta.Text = matricula.Movimento.DatLeitura.Value.ToString("dd/MM/yy hh:mm");
			else
				lblDtHrColeta.Text = string.Empty;

			chkProcessado.Checked = matricula.IndProcessado.ToUpper().Equals("S");
		}

		/// <summary>
		/// Limpa os campos de resultado
		/// </summary>
		private void LimparCampos() {
			lblNome.Text = string.Empty;
			lblMatricula.Text = string.Empty;
			lblLogradouro.Text = string.Empty;
			lblDtHrColeta.Text = string.Empty;

			chkProcessado.Checked = false;
        }
        #endregion // Metodos privados

        private void lblBuscaLeitura_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}