using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class OcorrenciaController: IDisposable {
		#region Atributos e Propriedades
		private FormOcorrenciaNovo _formOcorrencia;

		private OnpMatricula _matricula;
		public OnpMatricula Matricula {
			get {
				return _matricula;
			}
		}

		private bool _cancelar;
		public bool Cancelar {
			get {
				return _cancelar;
			}
			set {
				_cancelar = value;
			}
		}
		#endregion // Atributos e Propriedades

		public OcorrenciaController(OnpMatricula matricula) {
			_matricula = matricula;
			_formOcorrencia = new FormOcorrenciaNovo(this);

			CarregaOcorrencias();
		}

		#region Metodos Publicos
		public void ShowOcorrencia() {
			_formOcorrencia.SetHidrometro(_matricula.Movimento.CodHidrometro);
			_formOcorrencia.CarregaOcorrencias(_matricula.Movimento.MovimentosOcorrencia);
			_formOcorrencia.ShowDialog();
		}

		public void CarregaOcorrencias() {
			_formOcorrencia.AddListBoxItens(new OnpOcorrencia().SelectCollection());
		}

		/// <summary>
		/// Cria OnpMovimentoOcorrencia para cada ocorrencia da lista recebida
		/// </summary>
		/// <param name="lista">Lista de ocorrencias</param>
		public void GravaOcorrencias(Collection<OnpOcorrencia> lista) {
			OnpMovimentoOcorrencia item;
			int seqOcorrencia = 0;

			foreach (OnpOcorrencia ocorrencia in lista) {
				item = new OnpMovimentoOcorrencia();
				item.CodOcorrencia = ocorrencia.CodOcorrencia;
				item.SeqMatricula = _matricula.SeqMatricula;
				item.SeqRoteiro = _matricula.Movimento.SeqRoteiro;
				item.CodReferencia = _matricula.Movimento.CodReferencia;
				item.SeqSequencial = ++seqOcorrencia;
				item.Persist();

				_matricula.Movimento.MovimentosOcorrencia.Add(item);
			}
		}

		public void RemoverOcorrencia(OnpOcorrencia ocorrencia) {
			for (int i = 0; i < _matricula.Movimento.MovimentosOcorrencia.Count; i++) {
				if (_matricula.Movimento.MovimentosOcorrencia[i].Ocorrencia.Equals(ocorrencia)) {
					_matricula.Movimento.MovimentosOcorrencia[i].Remove();
					_matricula.Movimento.MovimentosOcorrencia.Remove(_matricula.Movimento.MovimentosOcorrencia[i]);
					i--;
				}
			}
		}
		#endregion // Metodos Publicos

		#region IDisposable Members

		public void Dispose() {
			if (_formOcorrencia != null)
				_formOcorrencia.Dispose();
		}

		#endregion
	}
}
