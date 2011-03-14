using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	#region Enums
	/// <summary>
	/// Posicao relativa da lista de matriculas
	/// </summary>
	public enum PosicaoNavegacao {
		Primeiro,
        PrimeiroNaoLido,
        Meio,
        UltimoNaoLido,
		Ultimo
	}

	public enum IrParaMatricula {
		Primeira,
		Anterior,
        AnteriorNaoLida,
        ProximaNaoLida,
        Proxima,
		Ultima
	}
	#endregion

	public class NavegacaoController {
		#region Atributos e Propriedades
		private FormNavegacao _formNavegacao;
		private OpcoesNavegacaoController _opcoesController;
		private HistoricoConsumoController _historicoController;
		private bool _removerProcessadas;

		private int _listIndex;
		private int _listIndexAnt;
		private bool _processaVirada;
		/// <summary>
		/// Indice atual da lista de matriculas
		/// </summary>
		public int Listindex {
			get { return _listIndex; }
			set { _listIndex = value; }
		}

		private static Collection<OnpMatricula> _listaMatriculas;
		/// <summary>
		/// Lista de Matriculas
		/// </summary>
		public static Collection<OnpMatricula> ListaMatriculas {
			get {
				if (_listaMatriculas == null) {
					_listaMatriculas = new OnpMatricula().SelectCollection();
					SortedList<int, OnpMatricula> lista = new SortedList<int, OnpMatricula>(_listaMatriculas.Count);
					foreach (OnpMatricula m in _listaMatriculas)
						lista.Add(m.SeqLeitura.Value, m);
					_listaMatriculas = new Collection<OnpMatricula>(lista.Values);
				}
				return _listaMatriculas;
			}
		}

		/// <summary>
		/// Verifica se todas as contas já foram processadas
		/// </summary>
		public bool LeuTodasMatriculas {
			get {
				foreach (OnpMatricula matricula in ListaMatriculas)
					if (!string.IsNullOrEmpty(matricula.IndProcessado) && matricula.IndProcessado.Equals("N"))
						return false;

				return true;
			}
		}

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

		public NavegacaoController(bool removerProcessadas, bool emissao) {
			_formNavegacao = new FormNavegacao(this, emissao);
			_listIndex = 0;
			_listIndexAnt = 0;
			_removerProcessadas = removerProcessadas;

			// Opções padrão de navegação
			_tipoNavegacao = TipoNavegacao.Roteiro;
			_ordemNavegacao = OrdemNavegacao.Crescente;
			_inclusaoNavegacao = InclusaoNavegacao.Todas;

			// Mostra a primeira matricula nao processada
			for (int i = 0; i < ListaMatriculas.Count; i++) {
				if (ListaMatriculas[i].IndProcessado.Equals("N")) {
					_listIndex = i;
					_formNavegacao.AtualizaTela(GetMatriculaAtual());
					break;
				}
			}
		}

		#region Metodos Publicos
		/// <summary>
		/// Mostra tela de opções de navegação
		/// </summary>
		public void Pesquisar() {
			if (_opcoesController == null)
				_opcoesController = new OpcoesNavegacaoController();

			_opcoesController.Logradouro = _logradouro;
			_opcoesController.TipoNavegacao = _tipoNavegacao;
			_opcoesController.OrdemNavegacao = _ordemNavegacao;
			_opcoesController.InclusaoNavegacao = _inclusaoNavegacao;

			OnpMatricula mat = _opcoesController.MostrarForm();

			// Atualizando opcoes de navegação
			_logradouro = _opcoesController.Logradouro;
			_tipoNavegacao = _opcoesController.TipoNavegacao;
			_ordemNavegacao = _opcoesController.OrdemNavegacao;
			_inclusaoNavegacao = _opcoesController.InclusaoNavegacao;

			// Navega para as opcoes selecionada
			int index = _listIndex;
			IrPara(IrParaMatricula.Anterior);
			if (index == _listIndex)
				IrPara(IrParaMatricula.Proxima);

			// Mostra a matricula busca na tela de pesquisa
			if (mat != null) {
				for (int i = 0; i < ListaMatriculas.Count; i++) {
					if (ListaMatriculas[i].SeqMatricula.Value == mat.SeqMatricula.Value) {
						_listIndex = i;
						_formNavegacao.AtualizaTela(GetMatriculaAtual());
						AtualizarMatricula(mat);
						break;
					}
				}
			}
		}

		/// <summary>
		/// Mostra a tela de navegação para selecionar uma matricula para leitura
		/// </summary>
		/// <param name="matricula">Matricula para ser mostrada na lista</param>
		/// <returns>Retorna a matricula selecionada, null caso nenhuma matricula tenha sido selecionada</returns>
		public OnpMatricula Selecionar(OnpMatricula matricula) {
			// Atualiza a tela com a matricula recebida
			if (matricula != null)
				_formNavegacao.AtualizaTela(matricula);

			NavegacaoController _navegar = new NavegacaoController(false, true);
			if (_navegar.LeuTodasMatriculas) {
				// Posiciona na primeira conta
				// Navego para aparecer os dados na tela
				_listIndexAnt = 0;
				IrPara(IrParaMatricula.Proxima);
				IrPara(IrParaMatricula.Anterior);
			} else {
				_listIndexAnt = -1;
				_processaVirada = true;

				while (ListaMatriculas[_listIndex].IndProcessado.Equals("S") && _listIndex < ListaMatriculas.Count - 1 && _listIndexAnt != _listIndex) {
					_listIndexAnt = _listIndex;
					if (_ordemNavegacao == OrdemNavegacao.Crescente)
						IrPara(IrParaMatricula.Proxima);
					else
						IrPara(IrParaMatricula.Anterior);

					if ((_listIndexAnt == _listIndex || _listIndex == ListaMatriculas.Count - 1) && _processaVirada && ListaMatriculas[_listIndex].IndProcessado.Equals("S")) {
						if (_ordemNavegacao == OrdemNavegacao.Crescente)
							IrPara(IrParaMatricula.Primeira);
						else
							IrPara(IrParaMatricula.Ultima);
						_processaVirada = false;
					}
				}
			}
			DialogResult dr = _formNavegacao.ShowDialog();

			// Sempre retorna uma nova matricula para evitar
			// que seja carregado muito dados para a memoria
			if (dr == DialogResult.OK)
				matricula = GetMatriculaAtual();
			else if (dr == DialogResult.Cancel)
				matricula = null;

			return matricula;
		}

		/// <summary>
		/// Atualiza informações da matricula atual (processado)
		/// </summary>
		/// <param name="mat"></param>
		public void AtualizarMatricula(OnpMatricula mat) {
			ListaMatriculas[_listIndex].IndProcessado = mat.IndProcessado;
			ListaMatriculas[_listIndex].Movimento = null;
			ListaMatriculas[_listIndex].Alteracoes = null;
			ListaMatriculas[_listIndex].Aviso = null;
			ListaMatriculas[_listIndex].Logradouro = null;
			ListaMatriculas[_listIndex].Servicos = null;
			ListaMatriculas[_listIndex].UtilizacaoLigacao = null;
		}

		/// <summary>
		/// Mostra o historico de consumo para matricula atual
		/// </summary>
		public void HistoricoConsumo() {
			if (ListaMatriculas.Count > 0) {
				if (_historicoController == null)
					_historicoController = new HistoricoConsumoController();

				_historicoController.MostrarHistorico(GetMatriculaAtual());
			}
		}

		/// <summary>
		/// Calculo estatistico das leituras
		/// </summary>
		/// <returns>Retorna um array de 5 posicoe com informacoes: roteiro carregado, contas processadas, contas emitidas, contas retidas e todas de contas.</returns>
		public static string[] Estatisticas() {
			string[] msgEstatistica = new string[5];

			int contasProcessadas = 0,
                contasEmitidas    = 0,
			    contasRetidas     = 0, 
                totalContas       = 0;

            totalContas = ListaMatriculas.Count;
            foreach (OnpMatricula m in ListaMatriculas) {
                if (m.IndProcessado.Equals("S"))
                    contasProcessadas++;
            }

            Collection<OnpMovimento> mo = new OnpMovimento().SelectCollection();
            foreach (OnpMovimento mov in mo) {
                if (mov.ValImpressoes > 0)
                    contasEmitidas++;

                if (mov.IndSituacaoMovimento.Equals("R"))
                    contasRetidas++;
            }

			msgEstatistica[0] = OnpRoteiro.GrupoRoteiroCarregado().ToString();
			msgEstatistica[1] = contasProcessadas.ToString();
			msgEstatistica[2] = contasEmitidas.ToString();
			msgEstatistica[3] = contasRetidas.ToString();
			msgEstatistica[4] = totalContas.ToString();

			return msgEstatistica;
		}

		/// <summary>
		/// Navega para uma matricula na ordem recebida como parametro
		/// </summary>
		/// <param name="irParaMatricula">Ordem de navegação</param>
		/// <returns>Retorna a posição relativa na lista (comeco, meio, fim)</returns>
		public PosicaoNavegacao IrPara(IrParaMatricula irParaMatricula) {
			int incremento = 0;
			PosicaoNavegacao pn = PosicaoNavegacao.Meio;

			if (_tipoNavegacao == TipoNavegacao.Roteiro) {
				incremento = IrParaPorRoteiro(irParaMatricula);
			} else if (_tipoNavegacao == TipoNavegacao.Logradouro && _logradouro != null) {
				incremento = IrParaPorLogradouro(_logradouro, irParaMatricula);
			}

			if (incremento == 0) {
				if (irParaMatricula == IrParaMatricula.Anterior)
					pn = PosicaoNavegacao.Primeiro;
				else if (irParaMatricula == IrParaMatricula.Proxima)
					pn = PosicaoNavegacao.Ultimo;
                else if (irParaMatricula == IrParaMatricula.AnteriorNaoLida)
					pn = PosicaoNavegacao.PrimeiroNaoLido;
                else if (irParaMatricula == IrParaMatricula.ProximaNaoLida)
					pn = PosicaoNavegacao.UltimoNaoLido;

			} else {
				pn = AtualizaLista(incremento);
			}

			return pn;
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
		/// Retorna uma copia da matricula atual
		/// </summary>
		/// <returns>Um objeto OnpMatricula</returns>
		private OnpMatricula GetMatriculaAtual() {
			return new OnpMatricula(ListaMatriculas[_listIndex].SeqMatricula.Value);
		}

		/// <summary>
		/// Verifica qual o incremento a ser dado conforme direção de navegação
		/// </summary>
		/// <param name="irParaMatricula">Direção de navegação</param>
		/// <returns>Incremento a ser feito com base na posição atual (positivo ou negativo)</returns>
		private int IrParaPorRoteiro(IrParaMatricula irParaMatricula) {
			return IrParaPorLogradouro(null, irParaMatricula);
		}

		/// <summary>
		/// Procura pela proxima matricula na lista usando como base um logradouro
		/// </summary>
		/// <param name="logradouro">Logradouro a ser procurado, se for null vai considerar todo o roteiro</param>
		/// <param name="incremento">incremento, positivo (crescente) ou negativo (decrescente)</param>
		/// <param name="irParaMatricula">Indica direcao de navegação</param>
		/// <returns>Retorna a diferença entre a posição atual e a posição para qual se deve ser</returns>
		private int IrParaPorLogradouro(OnpLogradouro logradouro, IrParaMatricula irParaMatricula) {
			int i = _listIndex, j = _listIndex;

			switch (irParaMatricula) {
				case IrParaMatricula.Primeira:
					while (j > 0 && j < _listaMatriculas.Count) {
						j--;
						if ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j]))
							i = j;
					}
					break;

				case IrParaMatricula.Anterior:
					while (j > 0 && j < _listaMatriculas.Count) {
						j--;
						if ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j])) {
							i = j;
							break;
						}
					}
					break;

                case IrParaMatricula.AnteriorNaoLida:
					while (j > 0 && j < _listaMatriculas.Count) {
						j--;
						if ((_listaMatriculas[j].IndProcessado.Equals("N")) && ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j]))) {
							i = j;
							break;
						}
					}
					break;

				case IrParaMatricula.Proxima:
					while (j >= 0 && j < _listaMatriculas.Count - 1) {
						j++;
						if ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j])) {
							i = j;
							break;
						}
					}
					break;

                case IrParaMatricula.ProximaNaoLida:
                    while (j >= 0 && j < _listaMatriculas.Count - 1) {
                        j++;
                        if ((_listaMatriculas[j].IndProcessado.Equals("N")) && ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j]))) {
                            i = j;
                            break;
                        }
                    }
                    break;

                case IrParaMatricula.Ultima:
					while (j >= 0 && j < _listaMatriculas.Count - 1) {
						j++;
						if ((logradouro == null || _listaMatriculas[j].SeqLogradouro.Value == logradouro.SeqLogradouro.Value) && PoderIrNaMatricula(_listaMatriculas[j]))
							i = j;
					}
					break;
			}

			return i - _listIndex;
		}

		/// <summary>
		/// Valida a matricula sobre a inclusão de matriculas lidas e não lidas na navegação
		/// </summary>
		/// <param name="mat">Matricula a ser validada</param>
		/// <returns>Retorna true se a matricula pode ser navegada, caso contrario retorna false</returns>
		private bool PoderIrNaMatricula(OnpMatricula mat) {
			bool result = true;

			switch (_inclusaoNavegacao) {
				case InclusaoNavegacao.NaoLidas:
					result = mat.IndProcessado.Equals("N");
					break;

				case InclusaoNavegacao.Lidas:
					result = mat.IndProcessado.Equals("S") && !_removerProcessadas;
					break;

				case InclusaoNavegacao.Todas:
					result = mat.IndProcessado.Equals("N") || (mat.IndProcessado.Equals("S") && !_removerProcessadas);
					break;
			}

			return result;
		}

		/// <summary>
		/// Move o cursor de matricula na lista pelo valor passado
		/// </summary>
		/// <param name="inc">Incremento, pode ser negativo</param>
		/// <returns>Retorna a posição relativa na lista (comeco, meio, fim)</returns>
		private PosicaoNavegacao AtualizaLista(int incremento) {
			PosicaoNavegacao retorno = PosicaoNavegacao.Meio;

			_listIndex += incremento;

			if (_listIndex < 0) {
				_listIndex = 0;
				retorno = PosicaoNavegacao.Primeiro;
			} else if (_listIndex >= _listaMatriculas.Count) {
				_listIndex = _listaMatriculas.Count - 1;
				retorno = PosicaoNavegacao.Ultimo;
			}

			if (incremento == 0)
				return retorno;

			// Passa os dados do cliente para a tela
			if (_listaMatriculas.Count > 0)
				_formNavegacao.AtualizaTela(GetMatriculaAtual());

			return retorno;
		}
		#endregion // Metodos Privados
	}
}