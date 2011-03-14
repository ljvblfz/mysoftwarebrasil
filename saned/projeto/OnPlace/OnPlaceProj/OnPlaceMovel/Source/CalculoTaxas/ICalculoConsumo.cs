using System;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.CalculoTaxas {
	public interface ICalculoConsumo {
		int CalculaConsumo(OnpMovimento movimento, int leitura);
		int CalculaConsumo(OnpMovimento movimento, int leitura, bool ajusta);
		bool PodeCalcular(OnpMovimento movimento);
	}
}
