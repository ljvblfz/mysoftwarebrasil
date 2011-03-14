using System;
using System.Collections.Generic;
using System.Text;

namespace OnPlaceLoader.Diadema {
	class ControladorUploaderDiadema : OnPlaceLoader.Controladores.ControladorUploader {
		protected override void OutrasDescarga() {
			DescarregarTabela("ONP_FATURA_IMPOSTO_DIADEMA");
		}
	}
}
