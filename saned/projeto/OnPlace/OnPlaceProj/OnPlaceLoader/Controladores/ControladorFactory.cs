#region Usings
using System;
using OnPlaceLoader.Diadema;
#endregion // Usings

namespace OnPlaceLoader.Controladores {
	/// <summary>
	/// Cria controladores de carga conforme o cliente especificado
	/// </summary>
	sealed class ControladorFactory {
		private ControladorFactory() {
		}

		#region Metodos publicos
		/// <summary>
		/// Verifica os valores da linha de comando e cria o cliente de carga apropriado
		/// </summary>
		/// <returns>Retorna o controlador para o cliente especificado na linha de comando</returns>
		internal static OnPlaceLoader.Interfaces.IControlador GetLoader() {
			OnPlaceLoader.Interfaces.IControlador retorno = null;

			switch (CommandLine.CommandLineParser.Instancia.Cliente) {
				case OnPlaceLoader.Enumerations.Cliente.Diadema:
					if (CommandLine.CommandLineParser.Instancia.Descarga)
						retorno = new ControladorUploaderDiadema();
					else
						retorno = new ControladorDownloaderDiadema();
					break;

				default:
					if (CommandLine.CommandLineParser.Instancia.Descarga)
						retorno = new ControladorUploader();
					else
						retorno = new ControladorDownloader();
					break;
			}

			return retorno;
		}
		#endregion // Metodos publicos
	}
}
