using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
    public partial class FormProgresso : Form {
        private delegate void DelegateSetPercent(string percent);
        private delegate void DelegateSetMensagem(string msg);
        private delegate void DelegateSetValorMinimo(int valor);
        private delegate void DelegateSetValorMaximo(int valor);
        private delegate void DelegateSetPosicao(int valor);
        private delegate void DelegateMostrar();
		private delegate void DelegateEsconder();		
        private delegate void DelegateFechar();
        private delegate void DelegateSetRefresh();

        private DelegateSetPercent _DelegateSetPercent;
        private DelegateSetMensagem _DelegateSetMensagem;
        private DelegateSetRefresh _DelegateSetRefresh;
        private DelegateSetValorMinimo _DelegateSetValorMinimo;
        private DelegateSetValorMaximo _DelegateSetValorMaximo;
        private DelegateSetPosicao _DelegateSetPosicao;
		private DelegateMostrar _DelegateMostrar;
		private DelegateEsconder _DelegateEsconder;
		private DelegateFechar _DelegateFechar;
        private ProgressoController _progresso;

        public FormProgresso(ProgressoController progresso) {
            InitializeComponent();

            _progresso = progresso;

            _DelegateSetPercent = new DelegateSetPercent(SetPercent);
            _DelegateSetMensagem = new DelegateSetMensagem(SetMensagemCallback);
            _DelegateSetRefresh = new DelegateSetRefresh(RefreshScreenCallback);
            _DelegateSetValorMinimo = new DelegateSetValorMinimo(SetValorMinimoCallback);
            _DelegateSetValorMaximo = new DelegateSetValorMaximo(SetValorMaximoCallback);
            _DelegateSetPosicao = new DelegateSetPosicao(SetPosicaoCallback);
			_DelegateMostrar = new DelegateMostrar(MostrarCallback);
			_DelegateEsconder = new DelegateEsconder(EsconderCallback);
			_DelegateFechar = new DelegateFechar(FecharCallback);
		}

		#region Metodos Publicos
		public void SetValorMaximo(int valor) {
            if (InvokeRequired) {
                object[] parametros = new object[] { valor };
                BeginInvoke(_DelegateSetValorMaximo, parametros);
            } else {
                SetValorMaximoCallback(valor);
            }
        }

        public void SetValorMinimo(int valor) {
            if (InvokeRequired) {
                object[] parametros = new object[] { valor };
                BeginInvoke(_DelegateSetValorMinimo, parametros);
            } else {
                SetValorMinimoCallback(valor);
            }
        }

        public void SetPosicao(int valor) {
            if (InvokeRequired) {
                object[] parametros = new object[] { valor };
                BeginInvoke(_DelegateSetPosicao, parametros);
            } else {
                SetPosicaoCallback(valor);
            }
        }

        public void SetMensagem(string msg) {
            if (InvokeRequired) {
                object[] parametros = new object[] { msg };
                BeginInvoke(_DelegateSetMensagem, parametros);
            } else {
                SetMensagemCallback(msg);
            }
        }

		public void Mostrar() {
			if (InvokeRequired) {
				BeginInvoke(_DelegateMostrar);
			} else {
				MostrarCallback();
			}
		}

		public void Esconder() {
			if (InvokeRequired) {
				BeginInvoke(_DelegateMostrar);
			} else {
				EsconderCallback();
			}
		}

		public void SetPercent(string percent) {
            if (InvokeRequired) {
                object[] parametros = new object[] { percent };
                BeginInvoke(_DelegateSetPercent, parametros);
            } else {
                SetPercentCallback(percent);
            }
        }

        public override void Refresh() {
            if (InvokeRequired) {
                BeginInvoke(_DelegateSetRefresh);
            } else {
                RefreshScreenCallback();
            }
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		private void SetValorMaximoCallback(int valor) {
			pbProgresso.Maximum = valor;
		}

		private void SetValorMinimoCallback(int valor) {
			pbProgresso.Minimum = valor;
		}

		private void SetPosicaoCallback(int valor) {
			double a = 0.0f;
			pbProgresso.Value = valor;

			if (pbProgresso.Maximum > 0)
				a = ((pbProgresso.Value * 100) / pbProgresso.Maximum);

			lblPercent.Text = a.ToString() + " %";
		}

		private void SetMensagemCallback(string msg) {
			lblMsg.Text = msg;
		}

		private void MostrarCallback() {
			Show();
		}

		public void Fechar() {
			if (InvokeRequired) {
				BeginInvoke(_DelegateFechar);
			} else {
				FecharCallback();
			}
		}

		private void FecharCallback() {
			Close();
		}

		private void EsconderCallback() {
			Hide();
		}

		private void SetPercentCallback(string percent) {
			lblPercent.Text = percent;
		}

		private void RefreshScreenCallback() {
            base.Refresh();
        }
		#endregion // Metodos Privados

		#region Eventos do Form
		private void Progresso_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
		}
		#endregion // Eventos do Form
	}
}