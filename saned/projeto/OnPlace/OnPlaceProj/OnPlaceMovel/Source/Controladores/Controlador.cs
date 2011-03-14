using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OnPlaceMovel.Source.Forms;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;
using Strategos.Api.Log4CS;

namespace OnPlaceMovel.Source {
	public class Controlador {
		#region Atributos e Propriedades
		private MenuController _mControl;

		private delegate void UpdateTituloCallback(bool mostrar);
		private static bool _enviando;

		private static Form _activeForm;
		public static Form ActiveForm {
			get { return _activeForm; }
			set {
				// Remove o Sinal do form atual
				if ( _enviando ) {
					SinalizarEnvio( false );
					// Neste caso _enviando não deve ser alterado para false
					// entao forçamos ele a voltar para true depois de chama SinalizarEnvio()
					_enviando = true; 
				}
				
				_activeForm = value;
				
				// Coloca o sinal no form novo
				if ( _enviando )
					SinalizarEnvio( true );
			}
		}

		private static OnpAgente _agente;
		public static OnpAgente Agente {
			get { return _agente; }
			set { _agente = value; }
		}

		private static bool _adminstrador = false;
		public static bool Adminstrador {
			get { return _adminstrador; }
			set { _adminstrador = value; }
		}

		private static bool _logado;
		public static bool Logado {
			set { _logado = value; }
			get { return _logado; }
		}
		#endregion // Atributos e Propriedades

		/// <summary>
		/// Construtor da classe
		/// </summary>
		public Controlador() {
			VerificaVersao();

			_mControl = new MenuController( this );
			
			MostraLogin();
			
			if ( !_logado )
				Application.Exit();
		}

		#region Metodos Publicos
		/// <summary>
		/// Retorna o identificador do Formulário do menuPrincipal
		/// </summary>
		/// <returns>Retorna o identificador do Formulário do menuPrincipal</returns>
		public Form GetMenuPrincipal() {
			return _mControl.GetMenuForm();
		}

		/// <summary>
		/// Atualiza o titulo do form ativo
		/// </summary>
		/// <param name="mostrar">Indica se deve (true) ou não (false) mostrar o sinal de envio.</param>
		public static void SinalizarEnvio(bool mostrar) {
			try {
				_enviando = mostrar;
				if (_activeForm != null)
					_activeForm.Invoke(new UpdateTituloCallback(UpdateTitulo), new object[] { mostrar });
			} catch (ObjectDisposedException) {

			}
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
		/// Verifica se a versao do onplace é a minima recomendada, caso nao seja joga VersaoIncorretaException
		/// </summary>
		private void VerificaVersao() {
			OnpParametro parametro;

			parametro = new OnpParametro("versao_minima");
			if (!string.IsNullOrEmpty(parametro.DesNome)) {
				string[] versaoMinima = parametro.DesValor.Split(new char[] { '.' });
				string[] versaoAtual = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Split(new char[] { '.' });

				if (int.Parse(versaoAtual[0]) < int.Parse(versaoMinima[0]) ||
					int.Parse(versaoAtual[1]) < int.Parse(versaoMinima[1]) ||
					int.Parse(versaoAtual[2]) < int.Parse(versaoMinima[2]) ||
                    ((int.Parse(versaoAtual[2]) == int.Parse(versaoMinima[2])) && (int.Parse(versaoAtual[3]) < int.Parse(versaoMinima[3])))
                   )
					ThrowVersaoIncorreta();
			}
		}

		/// <summary>
		/// Joga uma exception dizendo que é necessário atualizar o onplace
		/// </summary>
		private void ThrowVersaoIncorreta() {
			throw new VersaoIncorretaException("Versão incorreta do OnPlace, atualize para uma versão mais recente!");
		}

		/// <summary>
		/// Coloca no titulo do form atualmente uma indicacao que transmissão de matricula esta sendo feita
		/// </summary>
		private static void UpdateTitulo(bool mostrar) {
			string titulo = _activeForm.Text;
			const string sinal = "[T] ";

			if (mostrar) {
				if (!titulo.Substring(0, sinal.Length).Equals(sinal))
					_activeForm.Text = sinal + _activeForm.Text;
			} else {
				if (titulo.Substring(0, sinal.Length).Equals(sinal))
					_activeForm.Text = _activeForm.Text.Substring(4);
			}
		}
		
		/// <summary>
		/// Mostra na tela a janela de login do sistema
		/// </summary>
		private void MostraLogin() {
			LoginController logControl = new LoginController( this );
			
			logControl.Show();
			Controlador.Agente = logControl.Agente;
			
			logControl.Dispose();
			logControl = null;
		}
		#endregion // Metodos Privados
	}
}