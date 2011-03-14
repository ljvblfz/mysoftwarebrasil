#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OnPlaceLoader.Controladores;
using System.Threading;
#endregion // Usings

namespace OnPlaceLoader.Forms {
	public partial class FormLog : Form {
		#region Atributos e Propriedades
		private OnPlaceLoader.Interfaces.IControlador _controlador;

		private FormLogListener _logListener;

		private Thread _thread;
		#endregion // Atributos e Propriedades

		public FormLog() {
			InitializeComponent();

			_controlador = ControladorFactory.GetLoader();

			_logListener = new FormLogListener(this);
			_thread = new Thread(new ParameterizedThreadStart(IniciarLoader));
			_thread.Start(_controlador);

			this.DoubleBuffered = true;
		}

		#region Metodos privados
		/// <summary>
		/// Inicia o processo de carga em uma thread
		/// </summary>
		/// <param name="ctrl"></param>
		private static void IniciarLoader(object ctrl) {
			(ctrl as OnPlaceLoader.Interfaces.IControlador).Executar();
		}
		#endregion // Metodos privados

		#region Metodos publicos
		/// <summary>
		/// Adiciona uma linha no log com um NewLine no final
		/// </summary>
		/// <param name="message"></param>
		internal void AddLogLine(string message) {
			AddLog(message + System.Environment.NewLine);
		}

		/// <summary>
		/// Adiciona uma linha no log
		/// </summary>
		/// <param name="message"></param>
		internal void AddLog(string message) {
			txtLog.Text += message;

			if (this.Focused || txtLog.Focused)
				SendKeys.Send("^{END}");
		}
		#endregion // Metodos publicos

		#region Eventos do form
		/// <summary>
		/// Esconde a janela principal quando usuario nao quiser mostrar ela
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormLog_Shown(object sender, EventArgs e) {
			if (!CommandLine.CommandLineParser.Instancia.Visivel)
				this.Hide();
		}

		/// <summary>
		/// Termina a thread de carga
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormLog_FormClosing(object sender, FormClosingEventArgs e) {
			try {
				if (_controlador.Estado != OnPlaceLoader.Enumerations.EstadoControlador.Encerrado)
					_thread.Abort();
			} catch (ThreadAbortException) {
			}
		}
		#endregion // Eventos do form

		#region Eventos de controles
		/// <summary>
		/// Verifica se a thread the carga terminou com sucesso, caso sim fecha o form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerControlador_Tick(object sender, EventArgs e) {
			if (_controlador.Estado == OnPlaceLoader.Enumerations.EstadoControlador.Encerrado)
				this.Close();
		}
		#endregion // Eventos de controles
	}
}