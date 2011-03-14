using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class AlteracaoCadastralController: IDisposable {
		#region Atributos e Propriedades
		private OnpMatricula _matricula;
		public OnpMatricula Matricula {
			get { return _matricula; }
			set { _matricula = value; }
		}

		private FormAlteracaoCadastral _alteracao;
		private Collection<OnpCategoria> _listaCategorias;
		private Collection<OnpTaxa> _listaTaxas;
		private Collection<OnpMovimentoCategoria> _listaMovCatAtual;
		#endregion // Atributos e Propriedades

		public AlteracaoCadastralController(OnpMatricula matricula) {
			this._matricula = matricula;

			_alteracao = new FormAlteracaoCadastral(this, matricula);
			PreencheCamposTela();

			try {
				_alteracao.ShowDialog();
			} catch (Exception) { }
		}

		#region Metodos

		private void PreencheCamposTela() {
			_alteracao.SetNHD(_matricula.Movimento.Hidrometro.CodHidrometro);
			_alteracao.SetNImovel(_matricula.ValNumeroImovel.Value);
			_alteracao.SetNome(_matricula.NomCliente);
			_alteracao.SetComplemento(_matricula.DesComplemento);
			_alteracao.SetDigitos(_matricula.Movimento.Hidrometro.ValNumeroDigitos.ToString());

			OnpCategoria categorias = new OnpCategoria();
			_listaCategorias = new Collection<OnpCategoria>();
			_listaCategorias = categorias.SelectCollection();
			_alteracao.SetListaCategorias(_listaCategorias);

			OnpTaxa taxas = new OnpTaxa();
			_listaTaxas = taxas.SelectCollection();
			_alteracao.SetListaTaxas(_listaTaxas);

			OnpMovimentoCategoria movCategorias = new OnpMovimentoCategoria();
			movCategorias.SeqMatricula = _matricula.SeqMatricula;
			_listaMovCatAtual = movCategorias.SelectCollection();
			_alteracao.SetMovimentoCategoria(_listaMovCatAtual);

			OnpLocalizacaoHidrometro locais = new OnpLocalizacaoHidrometro();
			Collection<OnpLocalizacaoHidrometro> listaLocais = locais.SelectCollection();
			_alteracao.SetListaLocalizacao(listaLocais);

			OnpLogradouro logradouros = new OnpLogradouro();
			Collection<OnpLogradouro> listaLogradouro = logradouros.SelectCollection();
			_alteracao.SetListaLogradouro(listaLogradouro);

			sTabela tab = _alteracao.Registro;
			tab.categoria = _listaCategorias[0].DesCategoria;
			tab.taxa = _listaTaxas[0].DesTaxa;
			tab.indice = -1;
			_alteracao.Registro = tab;
		}

		public void GravarDadosAlteracao(Collection<OnpMatriculaAlteracao> listaAlteracoes) {
			foreach (OnpMatriculaAlteracao oma in listaAlteracoes) {
				oma.Persist();
			}
		}

		public void Dispose() {
			if (_alteracao != null)
				_alteracao.Dispose();
		}

		#endregion
	}
}