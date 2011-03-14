using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
	public enum TipoLeitura {
		/// <summary>
		/// Forca entrada de leitura
		/// </summary>
		Precisa,
		/// <summary>
		/// Recusa entrada de leitura
		/// </summary>
		Recusa,
		/// <summary>
		/// Pode ou não entrar com leitura
		/// </summary>
		Pode
	}

    public partial class FormLeituraHD : Form {
        #region Atributos e Propriedades
		private TipoLeitura _tipoLeitura;
        private string _leitura;
        private LeituraHDControllerPadrao _leituraControl;
        private bool _fechando;
        #endregion // Atributos e Propriedades

		public FormLeituraHD(LeituraHDControllerPadrao leituraControl, TipoLeitura tipoLeitura) {
            InitializeComponent();

            _fechando = false;

            _leitura = string.Empty;
            _leituraControl = leituraControl;
			_tipoLeitura = tipoLeitura;

            lblHidrometro.Text = leituraControl.Matricula.Movimento.CodHidrometro;

            btnOK.Focus();
        }

        #region Metodos publicos
        public void resetValues() {
            LimpaCampos();
        }
        #endregion // Metodos publicos

        #region Metodos Privados
        private void atualizaLabelLeitura() {
            lblLeitura.Text = string.Format("{0:#######}", _leitura);
        }

        private void SetFieldValue(string digito) {
            int digitosLidos = _leitura.Length;
            if (_leituraControl.getNumeroDigitosHD() > digitosLidos) {
                _leitura += digito;
                atualizaLabelLeitura();
                lblMensagem.Text = string.Empty;
            }
        }

        private void LimpaCampos() {
            lblMensagem.Text = string.Empty;
            lblLeitura.Text = string.Empty;
            _leitura = string.Empty;
        }
        #endregion // Metodos Privados

        #region Eventos de controles
        private void btnOK_Click(object sender, EventArgs e) {
            bool validacaoCampos = true;

			// Nao tem leitura e nao aceita leitura vazia
			if (string.IsNullOrEmpty(lblLeitura.Text) && _tipoLeitura == TipoLeitura.Precisa) {
				validacaoCampos = false;
				LimpaCampos();
				lblMensagem.Text = "Informe a leitura!";

			}

			// Nao tem leitura e nao aceita leitura vazia
			if (!string.IsNullOrEmpty(lblLeitura.Text) && _tipoLeitura == TipoLeitura.Recusa) {
				validacaoCampos = false;
				LimpaCampos();
				lblMensagem.Text = "Não pode informar leitura!";
			}

			if (validacaoCampos) {
                if (!string.IsNullOrEmpty(_leitura)) {
                    // Tentar definir a leitura
                    if (_leituraControl.setLeitura(int.Parse(_leitura))) {
                        _fechando = true;
                        Close();
                    } else {
                        _fechando = false;
                        string msg = lblMensagem.Text;
                        LimpaCampos();
                        lblMensagem.Text = msg;
                    }
                } else {
                    Close();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            if (_fechando)
                return;

            _leitura = string.Empty;
            atualizaLabelLeitura();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            if (_fechando)
                return;
            
            _leituraControl.Cancelar = true;
            Close();
        }

        private void btnDgN_Click(object sender, EventArgs e) {
            if (_fechando)
                return;

            Button bt = (Button)sender;
            SetFieldValue(bt.Text);
        } 
        #endregion // Eventos de controles

        #region Eventos
        private void LeituraHD_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
        }

        private void LeituraHD_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case System.Windows.Forms.Keys.D0:
                    SetFieldValue("0");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D1:
                    SetFieldValue("1");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D2:
                    SetFieldValue("2");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D3:
                    SetFieldValue("3");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D4:
                    SetFieldValue("4");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D5:
                    SetFieldValue("5");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D6:
                    SetFieldValue("6");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D7:
                    SetFieldValue("7");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D8:
                    SetFieldValue("8");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.D9:
                    SetFieldValue("9");
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Escape:
                    btnCancelar_Click(null, null);
                    e.Handled = true;
                    break;

                case System.Windows.Forms.Keys.Enter:
					btnOK_Click(null, null);
					e.Handled = true;
					break;

				case System.Windows.Forms.Keys.L:
					btnLimpar_Click(null, null);
					e.Handled = true;
					break;
			}
        }
        #endregion // Eventos do form

        public void MostraMensagem(string msg) {
            lblMensagem.Text = msg;
        }
    }	   
}