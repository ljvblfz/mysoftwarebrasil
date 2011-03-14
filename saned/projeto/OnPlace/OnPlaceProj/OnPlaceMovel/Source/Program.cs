using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Teste;
using OnPlaceMovel.Source.CalculoTaxas;

namespace OnPlaceMovel.Source {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main() {
			try {
				Strategos.Api.Log4CS.Log4CS.Instancia.Level = ConfigXML.GetLogLevel();
				OnPlaceMovel.Source.Controladores.UpdateControler.VerifyUpdates();

				if (File.Exists(ConfigXML.ArquivoBaseTeste))
					File.Copy(ConfigXML.ArquivoBaseTeste, ConfigXML.ArquivoBase, true);

				Strategos.Api.Database.Impl.ConnectionCE.Instancia.ConnectionString = ConfigXML.ArquivoBase;				
				
				Strategos.Api.Database.Impl.ConnectionCE.Instancia.Conectar();
				Application.Run(new Controlador().GetMenuPrincipal());				
				Strategos.Api.Database.Impl.ConnectionCE.Instancia.Desconectar();
			} catch (VersaoIncorretaException ex) {
				Strategos.Api.Log4CS.Log4CS.Error(ex.Message);
				Strategos.Api.Log4CS.Log4CS.Error(ex.StackTrace);
				MessageBox.Show(ex.Message, "OnPlaceMovel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			} catch (Exception ex) {
				Strategos.Api.Log4CS.Log4CS.Error(ex.Message);
				Strategos.Api.Log4CS.Log4CS.Error(ex.StackTrace);
                MessageBox.Show(ex.Message, "OnPlaceMovel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}											    
		}
	}
}