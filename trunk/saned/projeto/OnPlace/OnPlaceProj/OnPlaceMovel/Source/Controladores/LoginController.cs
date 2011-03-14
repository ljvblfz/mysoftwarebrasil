using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
using Strategos.Api.Database.Impl;

namespace OnPlaceMovel.Source.Controladores {
    public class LoginController : IDisposable {
        #region Atributos/Campos
        private FormLogin _formLogin;
        private Controlador _control;

        private OnpAgente _agente;
        public OnpAgente Agente {
            get { return _agente; }
        }

        private SituacaoDados _situacaoDados;
        public SituacaoDados SITUACAO_DADOS {
            get { return _situacaoDados; }
            set { _situacaoDados = value; }
        }

        private bool _administrativo;
        /// <summary>
        /// Indica se o login feito é administrativo ou não
        /// </summary>
        public bool Administrativo {
            get { return _administrativo; }
        }
        #endregion

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="control">Controlador principal</param>
        public LoginController(Controlador control) {
            _control = control;

            _administrativo = false;

            _formLogin = new FormLogin(this);
            _agente = new OnpAgente();

            _situacaoDados = SituacaoDados.Normal;
		}

		#region Metodos Publicos
		/// <summary>
		/// Faz o dispose de componentes usados pelo controlador
		/// </summary>
		public void Dispose() {
			_formLogin.Dispose();
		}
		
		/// <summary>
		/// Mostra o form de login
		/// </summary>
		public void Show() {
            _formLogin.ShowDialog();
        }

        /// <summary>
        /// Processo de autenticação do usuário
        /// </summary>
        /// <returns>Retorna true se autenticou com sucesso, caso contrario retorna false.</returns>
        public bool Autentica() {
            bool autentica = false;

            if (_agente.CodAgente.ToString().Equals(ConfigXML.GetAdministrador())) {
                if (_agente.DesSenha.Equals(ConfigXML.GetAdmPassword())) {
                    _situacaoDados = SituacaoDados.Normal;
                    Controlador.Logado = autentica = Controlador.Adminstrador = true;
                } else {
                    System.Windows.Forms.MessageBox.Show("Código de usuário e (ou) senha incorretos.");
					_formLogin.ClearScreen();
                }
            } else {
                VerificaDados();
                if (_situacaoDados != SituacaoDados.BaseVazia) {
                    OnpAgente agenteAux = new OnpAgente();
                    agenteAux.CodAgente = _agente.CodAgente;

                    if (agenteAux.Select() && agenteAux.CodAgente == _agente.CodAgente && agenteAux.DesSenha.Equals(_agente.DesSenha)) {
                        Controlador.Logado = true;
                        autentica = true;
                    } else {
                        System.Windows.Forms.MessageBox.Show("Código de usuário e (ou) senha incorretos.");
                        _formLogin.ClearScreen();
                    }
                }
            }

            return autentica;
        }


		/// <summary>
		/// Verifica se o sistema está OK antes de validar login e senha.
		/// </summary>
		public void VerificaDados() {
			if (BaseVazia())
				_situacaoDados = SituacaoDados.BaseVazia;
			else
				_situacaoDados = SituacaoDados.Normal;
		}

		/// <summary>
		/// Indica se tem agente logado no sistema
		/// </summary>
		/// <returns>Retorna true se esta logado, caso contrario retorna false.</returns>
		public bool GetLogado() {
			return Controlador.Logado;
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
        /// Verifica se a base de dados está vazia
        /// </summary>
		/// <remarks>A base de dados pode conter dados mas de forma incompleta, neste caso ela é considerada vazia.</remarks>
        /// <returns>Retorna true se a base de dados esta vazia ou não.</returns>
        private bool BaseVazia() {
			OnpTabelasCarga tabelasCarga = new OnpTabelasCarga("STATUS");
			return !tabelasCarga.IndCarga.Equals("S");
		}
		#endregion // Metodos Privados
	}
}
