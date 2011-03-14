using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {
	public class Coleta {
		#region Atributos e Propriedades
		private OnpMatricula _matricula;
		private NavegacaoController _navControl;
		private ILeitura _leitura;
		private AlteracaoCadastralController _altera;
		#endregion // Atributos e Propriedades

		public Coleta() {
			_matricula = null;
			_navControl = new NavegacaoController(true, false);
			if (_navControl.LeuTodasMatriculas) {
				MessageBox.Show("Fim do roteiro", "Aviso");
			} else {
				FormConfirmaSenha form = new FormConfirmaSenha(ConfigXML.GetSenhaColeta());
				form.ShowDialog();

				if (form.ShowDialog() == DialogResult.OK && form.Confirmado)
					IniciaProcessoColeta();
			}
		}

		#region Metodos Publicos
		private void IniciaProcessoColeta() {
			do {
				_matricula = _navControl.Selecionar(_matricula);
				if (_matricula == null)
					break;

				OnpMatricula matriculaWork = new OnpMatricula(_matricula.SeqMatricula.Value);

				_leitura = ConfigXML.GetClasseLeitura();
				if (!_leitura.IniciaLeitura(matriculaWork))
					continue;

				DialogResult resultado = MessageBox.Show("Deseja fazer alteração cadastral?", "OnPlaceMovel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (resultado == DialogResult.Yes)
					_altera = new AlteracaoCadastralController(matriculaWork);

				matriculaWork.IndProcessado = "S";
				matriculaWork.Persist();

				_matricula.IndProcessado = matriculaWork.IndProcessado;
				_matricula.IndImpresso = matriculaWork.IndImpresso;
				_matricula.Persist();

				matriculaWork = null;
			} while (true);
		}
		#endregion // Metodos Publicos
	}
}
