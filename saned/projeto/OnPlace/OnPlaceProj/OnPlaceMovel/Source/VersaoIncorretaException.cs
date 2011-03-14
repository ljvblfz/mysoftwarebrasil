using System;
using System.Collections.Generic;
using System.Text;

namespace OnPlaceMovel.Source {
	public class VersaoIncorretaException: Exception {
		private string _message;
		public new string Message {
			get { return _message; }
			set { _message = value; }
		}

		public VersaoIncorretaException(string message) {
			_message = message;
		}
	}
}
