using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnPlaceMovel.Source.Forms {
	public partial class FormConfirmaSenha: Form {
		#region Atributos e propriedades
		private string _senha;

		private bool _confirmado;
		/// <summary>
		/// Indica se a senha do administrador foi confirmada ou não
		/// </summary>
		public bool Confirmado {
			get { return _confirmado; }
		}
		#endregion

		public FormConfirmaSenha(string senha) {
			InitializeComponent();
			_confirmado = false;
			_senha = senha;
		}

		#region Eventos do form
		private void FormSenhaAdm_Activated(object sender, EventArgs e) {
			Controlador.ActiveForm = this;
		}

		private void FormSenhaAdm_Closing(object sender, CancelEventArgs e) {
			_confirmado = _senha.Equals(txtSenha.Text);
			if (!_confirmado && DialogResult == DialogResult.OK) {
				MessageBox.Show("Senha incorreta!");
				e.Cancel = true;
				txtSenha.Text = string.Empty;
				txtSenha.Focus();
			}
		}
		#endregion
	}
}