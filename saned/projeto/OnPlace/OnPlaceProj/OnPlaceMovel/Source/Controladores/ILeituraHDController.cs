using System;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;
namespace OnPlaceMovel.Source.Controladores {
	public interface ILeituraHDController : IDisposable {
		bool Cancelar { get; set; }
		bool Retida { get; set; }
		OnpMatricula Matricula { get; set; }

		int getNumeroDigitosHD();
		string MsgRetidaParaAnalise();
		
		bool setLeitura(int leitura);
		void setNumeroDigitosHD(int value);
		
		void FazerLeitura(OnpMatricula matricula, TipoLeitura tipoLeitura, bool mostraTelaDigito);
		void FazerLeitura(OnpMatricula matricula, TipoLeitura tipoLeitura);
	}
}
