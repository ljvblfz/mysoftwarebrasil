using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.Impressao {
	public interface ICodigoBarras {
		string gerarCodigoBarras(OnpFatura fatura);
		string gerarLinhaDigitavel(OnpFatura fatura);
	}
}
