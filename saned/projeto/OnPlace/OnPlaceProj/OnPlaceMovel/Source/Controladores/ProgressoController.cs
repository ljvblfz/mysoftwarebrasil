using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class ProgressoController: IDisposable {
		#region Atributos e Propriedades
		private FormProgresso _formProgresso;
		private Thread _thread;

		private int _vMin;
		public int valorMin {
			get { return _vMin; }
			set {
				_vMin = value;
				_formProgresso.SetValorMinimo(_vMin);
			}
		}

		private int _vMax;
		public int valorMax {
			get { return _vMax; }
			set {
				_vMax = value;
				_formProgresso.SetValorMaximo(_vMax);
			}
		}


		private int _vPos;
		public int Posicao {
			get { return _vPos; }
			set {
				_vPos = value;
				_formProgresso.SetPosicao(_vPos);
			}
		}

		private bool _vIndef;
		public bool valorIndefinido {
			get { return _vIndef; }
			set { _vIndef = value; }
		}

		private string _sMsg;
		public string Mensagem {
			get { return _sMsg; }
			set {
				_sMsg = value;
				_formProgresso.SetMensagem(_sMsg);
			}
		}
		#endregion // Atributos e Propriedades

		public ProgressoController(bool thread) {
			_formProgresso = new FormProgresso(this);

			if (thread)
				_thread = new Thread(new ThreadStart(ThreadProc));
		}

		#region Metodos publicos
		public void Show() {
			_formProgresso.Mostrar();
		}

		public void Hide() {
			_formProgresso.Esconder();
		}

		public void Close() {
			if (_formProgresso != null)
				_formProgresso.Fechar();
		}

		public void Refresh() {
			_formProgresso.Refresh();
		}

		public void Dispose() {
			if (_formProgresso != null)
				_formProgresso.Dispose();
		}
		#endregion // Metodos publicos

		#region Metodos privados
		private void ThreadProc() {
			const string relogio = "|/-\\";

			int pos = 0;

			while (true) {
				pos = pos > 3 ? 1 : pos + 1;
				_formProgresso.SetPercent(relogio[pos].ToString());
				_formProgresso.Refresh();
				Thread.Sleep(0);
			}
		}
		#endregion // Metodos privados
	}
}
