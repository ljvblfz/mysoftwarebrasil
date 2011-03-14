using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
using Strategos.Api.Database.Impl;

namespace OnPlaceMovel.Source.Controladores {
	public class ServicosController: IDisposable {
		#region Atributos e Propriedades
		private FormServicos _formServicos;
		private Collection<OnpServico> _listaServicos;
		private OnpMatricula _matricula;
		#endregion // Atributos e Propriedades

		public ServicosController() {
			_formServicos = new FormServicos(this);
			_matricula = null;

			CarregaListaServicos();
			_formServicos.ShowDialog();
		}

		#region Metodos Publicos
		public bool CarregaServicosCliente(int seqMatricula) {
			bool result = false;

			if (seqMatricula == 0)
				return result;

			_matricula = OnpMatricula.Materialize(seqMatricula);
			if (_matricula == null) {
				_formServicos.LimpaCamposMatricula();
				System.Windows.Forms.MessageBox.Show("Matrícula não encontrada!");
			} else {
				foreach (OnpMatriculaServico matServico in _matricula.Servicos)
					foreach (OnpServico servicos in _listaServicos)
						if (matServico.SeqServico == servicos.SeqServico)
							_formServicos.AddClienteListBoxItem(servicos.DesServico);

				_formServicos.setNome(_matricula.NomCliente);
				_formServicos.setEndereco(_matricula.Logradouro.DesLogradouro + ", " + _matricula.ValNumeroImovel.ToString());
				_formServicos.setHidrometro(_matricula.Movimento.CodHidrometro);

				result = true;
			}

			return result;
		}

		public void GravaListaServicos(Collection<string> lista) {
			if (_matricula != null) {
				OnpMatriculaServico matServico = new OnpMatriculaServico();
				matServico.SeqMatricula = _matricula.SeqMatricula;

				Collection<OnpMatriculaServico> listaAnterior = matServico.SelectCollection();
				foreach (OnpMatriculaServico ms in listaAnterior)
					ms.Remove();

				int max = 0;
				foreach (string str in lista)
					foreach (OnpServico servico in _listaServicos)
						if (str.Equals(servico.DesServico)) {
							matServico = new OnpMatriculaServico();
							matServico.SeqMatricula = _matricula.SeqMatricula;
							matServico.SeqServico = servico.SeqServico;
							matServico.IndSolicitante = string.Empty;
							matServico.SeqItem = ++max;
							matServico.Persist();
						}

				System.Windows.Forms.MessageBox.Show("Serviços gravados com sucesso!");
			}
		}

		/// <summary>
		/// Libera recursos usados pelo controlador
		/// </summary>
		public void Dispose() {
			_formServicos.Dispose();
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		private void CarregaListaServicos() {
			_listaServicos = new OnpServico().SelectCollection();

			foreach (OnpServico s in _listaServicos)
				_formServicos.AddListBoxItem(s.DesServico);
		}
		#endregion // Metodos Privados
	}
}
