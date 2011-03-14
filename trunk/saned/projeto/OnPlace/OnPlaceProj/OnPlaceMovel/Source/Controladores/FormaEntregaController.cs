using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class FormaEntregaController: IDisposable {
		#region Atributos e Propriedades
		private FormFormaEntrega _formulario;
		private OnpMatricula _matricula;
		#endregion // Atributos e Propriedades

		/// <summary>
		/// Construtor
		/// </summary>
		public FormaEntregaController() {
			_formulario = new FormFormaEntrega(this);
		}

		/// <summary>
		/// Mostra a tela de forma de entrega
		/// </summary>
		/// <param name="matricula">Matricula que vai ter forma de entrega escolhida.</param>
		/// <returns>Retorna true se teve sucesso na escolha da forma de entrega.</returns>
		public bool MostraFormaEntrega(OnpMatricula matricula) {
			_matricula = matricula;
			_formulario.ShowDialog();
			return true;
		}

		/// <summary>
		/// Altera o tipo de entrega da matricula atual
		/// </summary>
		/// <param name="tipoEntrega">Tipo de entrega a ser atribuido a matricula</param>
		public void SetTipoEntrega(OnpTipoEntrega tipoEntrega) {
			_matricula.Movimento.SeqTipoEntrega = tipoEntrega.SeqTipoEntrega.Value;
			_matricula.Movimento.Persist();

			if (_matricula.Movimento.Fatura != null) {
				_matricula.Movimento.Fatura.SeqTipoEntrega = _matricula.Movimento.SeqTipoEntrega;
				_matricula.Movimento.Fatura.Persist();
			}
		}

		/// <summary>
		/// Lista dos tipos de entrega
		/// </summary>
		/// <returns>Retorna uma collection com todos os tipos de entregas disponiveis</returns>
		public Collection<OnpTipoEntrega> TiposDeEntrega() {
			return new OnpTipoEntrega().SelectCollection();
		}

		#region IDisposable Members

		public void Dispose() {
			if (_formulario != null)
				_formulario.Dispose();
		}

		#endregion
	}
}
