using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class ErrorControler {
		public ErrorControler() {			
		}

		#region Metodos Publicos
		public static void ShowError(string mensagem, Exception exception) {
			ErrorControler error = new ErrorControler();
			error.Show(mensagem, exception);
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		private void Show(string mensagem, Exception exception) {
			FormError formError = new FormError(this);
			formError.Show(mensagem, exception);
			formError.Dispose();
		}
		#endregion // Metodos Privados
	}
}
