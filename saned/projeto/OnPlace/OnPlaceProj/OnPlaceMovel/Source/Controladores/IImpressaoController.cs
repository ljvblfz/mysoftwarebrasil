using System;
namespace OnPlaceMovel.Source.Controladores {
	public interface IImpressaoController : IDisposable {
		void MostrarImpressao(OnPlaceMovel.Source.Banco.OnpMatricula matricula);
		void EmiteDocumento(bool emiteFatura, bool emiteAviso, System.Collections.ObjectModel.Collection<OnPlaceMovel.Source.Banco.OnpFatura> faturas);
		bool MarcaFatura();
		bool MarcaAviso();
		OnPlaceMovel.Source.Banco.OnpMatricula Matricula { get; set; }
	}
}
