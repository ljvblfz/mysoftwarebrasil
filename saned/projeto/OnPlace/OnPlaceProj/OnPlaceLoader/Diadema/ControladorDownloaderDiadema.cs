using System;
using System.Collections.Generic;
using System.Text;

namespace OnPlaceLoader.Diadema {
	class ControladorDownloaderDiadema : OnPlaceLoader.Controladores.ControladorDownloader {
		protected override void OutrasCargas() {
			CarregarTabela("ONP_DESCONTO_DIADEMA");
			CarregarTabela("ONP_IMPOSTO_DIADEMA");
			
			CargaMatriculaDiadema();
        }

		private void CargaMatriculaDiadema() {
			string cmdText = null, tabela = "ONP_MATRICULA_DIADEMA";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT matd.* FROM onp_matricula_diadema matd, onp_movimento mov " +
				"WHERE matd.seq_matricula = mat.seq_matricula AND matd.seq_matricula = mov.seq_matricula and mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
        }    
	}
}
