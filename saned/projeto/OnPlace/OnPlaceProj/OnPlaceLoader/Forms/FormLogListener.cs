#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
#endregion // Usings
        
namespace OnPlaceLoader.Forms {
	/// <summary>
	/// Classe que monitora a saida de informações de trace para colocar no form de log
	/// </summary>
	internal class FormLogListener : TraceListener {
		#region Atributos e Propriedades
		private FormLog _formLog;
		private delegate void AddLog(string s);
		#endregion // Atributos e Propriedades
        
		public FormLogListener(FormLog log) {
			_formLog = log;

			System.Diagnostics.Trace.Listeners.Add(this);
		}

		#region Metodos publicos
		public override void Write(string message) {
			if (_formLog.InvokeRequired)
				_formLog.Invoke(new AddLog(_formLog.AddLog), new object[] { message });
			else
				_formLog.AddLog(message);
		}

		public override void WriteLine(string message) {
			if (_formLog.InvokeRequired)
				_formLog.Invoke(new AddLog(_formLog.AddLogLine), new object[] { message });
			else
				_formLog.AddLogLine(message);
		}
		#endregion // Metodos publicos
	}
}
