using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	class PesquisaController {
		private FormPesquisa _pesquisaForm;

		public OnpMatricula Pesquisar() {
			if ( _pesquisaForm  == null)
				_pesquisaForm = new FormPesquisa();

			_pesquisaForm.ShowDialog();

			return _pesquisaForm.Matricula;
		}
	}
}
