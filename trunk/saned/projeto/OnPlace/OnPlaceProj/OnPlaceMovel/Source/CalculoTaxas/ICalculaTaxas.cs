using OnPlaceMovel.Source.Banco;
using System.Collections.ObjectModel;

namespace OnPlaceMovel.Source.CalculoTaxas {
	/// <summary>
	/// interface que deve ser implementada para fazer calculo de faturas
	/// </summary>
	public interface ICalculaTaxas {
		/// <summary>
		/// Metodo inicia todo o calculo de fatura
		/// </summary>
		/// <param name="movimento">Movimento</param>
		/// <param name="fatura">Fatura</param>
		/// <param name="distribuiConsumo">Indica se o consumo deve ser distribuido ou não</param>
		void Calcular(OnpMovimento movimento, bool distribuiConsumo);

		/// <summary>
		/// Indica se o consumo minimo deve ser colocado nas taxas
		/// </summary>
		bool LancaMinimoNasTaxas { get;	set; }
	}
}
