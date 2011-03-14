using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class MenuController: IDisposable {
		#region Atributos e Propriedades
		private Emissao _emissao;
		private Coleta _coleta;
		private FormMenu _formMenu;
		private Controlador _controller;
		#endregion // Atributos e Propriedades

		public MenuController(Controlador control) {
			_controller = control;
			_formMenu = new FormMenu(this, control);
		}

		#region Metodos Publicos
		public void MostraBD() {
			BDController bdControl = new BDController(Controlador.Agente);
			bdControl.Show();
			bdControl.Dispose();
		}

		public void Servicos() {
			new ServicosController().Dispose();
		}

		public void Emissao() {
			_emissao = new Emissao();
		}

		public void Coleta() {
			_coleta = new Coleta();
		}

		public Form GetMenuForm() {
			return _formMenu;
		}

		public void Dispose() {
			_formMenu.Dispose();
		}
		#endregion // Metodos Publicos
	}
}
