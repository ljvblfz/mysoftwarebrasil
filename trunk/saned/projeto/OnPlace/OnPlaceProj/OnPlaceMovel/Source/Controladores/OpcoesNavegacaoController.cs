using System;
using System.Text;
using System.Collections.Generic;
using OnPlaceMovel.Source.Forms;
using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.Controladores {
	#region Enumeration para opcoes de navegacao
	public enum TipoNavegacao {
		Roteiro,
		Logradouro
	}

	public enum OrdemNavegacao {
		Crescente,
		Decrescente
	}

	public enum InclusaoNavegacao {
		Todas = 0,
		NaoLidas,
		Lidas
	}
	#endregion // Enumeration para opcoes de navegacao

	public class OpcoesNavegacaoController: IDisposable {
		#region Atributos e Propriedades
		private FormOpcoesNavegacao _formOpcoes;

		// Opcoes de Navegação
		private OrdemNavegacao _ordemNavegacao;
		public OrdemNavegacao OrdemNavegacao {
			get { return _ordemNavegacao; }
			set { _ordemNavegacao = value; }
		}

		private InclusaoNavegacao _inclusaoNavegacao;
		public InclusaoNavegacao InclusaoNavegacao {
			get { return _inclusaoNavegacao; }
			set { _inclusaoNavegacao = value; }
		}

		private TipoNavegacao _tipoNavegacao;
		public TipoNavegacao TipoNavegacao {
			get { return _tipoNavegacao; }
			set { _tipoNavegacao = value; }
		}

		private OnpLogradouro _logradouro;
		public OnpLogradouro Logradouro {
			get { return _logradouro; }
			set { _logradouro = value; }
		}
		#endregion

		public OpcoesNavegacaoController() {
			_formOpcoes = new FormOpcoesNavegacao(this);
		}

		#region Metodos Publicos
		public OnpMatricula MostrarForm() {
			// Tipo
			_formOpcoes.PorRoteiro = _tipoNavegacao == TipoNavegacao.Roteiro;
			_formOpcoes.OrdemCrescente = _ordemNavegacao == OrdemNavegacao.Crescente;
			_formOpcoes.IncluirLidas = _inclusaoNavegacao == InclusaoNavegacao.Lidas || _inclusaoNavegacao == InclusaoNavegacao.Todas;
			_formOpcoes.IncluirNaoLidas = _inclusaoNavegacao == InclusaoNavegacao.NaoLidas || _inclusaoNavegacao == InclusaoNavegacao.Todas;
			_formOpcoes.Logradouro = _logradouro;

			_formOpcoes.ShowDialog();

			// Tipo
			_tipoNavegacao = _formOpcoes.PorRoteiro ? TipoNavegacao.Roteiro : TipoNavegacao.Logradouro;

			// Ordem
			_ordemNavegacao = _formOpcoes.OrdemCrescente ? OrdemNavegacao.Crescente : OrdemNavegacao.Decrescente;

			// Logradouro
			_logradouro = _formOpcoes.Logradouro;

			// Lidas / Não lidas
			if (_formOpcoes.IncluirLidas && _formOpcoes.IncluirNaoLidas)
				_inclusaoNavegacao = InclusaoNavegacao.Todas;
			else if (_formOpcoes.IncluirLidas && !_formOpcoes.IncluirNaoLidas)
				_inclusaoNavegacao = InclusaoNavegacao.Lidas;
			else if (!_formOpcoes.IncluirLidas && _formOpcoes.IncluirNaoLidas)
				_inclusaoNavegacao = InclusaoNavegacao.NaoLidas;

			return _formOpcoes.Matricula;
		}

		/// <summary>
		/// Retorna uma lista de logradouros disponiveis
		/// </summary>
		/// <returns>Uma collection com os logradouros ou uma collection vazia caso não encontre nenhum</returns>
		public Collection<OnpLogradouro> listLogradouros() {
			return new OnpLogradouro().SelectCollection();
		}

		public void Dispose() {
			if (_formOpcoes != null)
				_formOpcoes.Dispose();
		}
		#endregion //Metodos Publicos
	}
}
