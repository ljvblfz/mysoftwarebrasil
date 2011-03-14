using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.CalculoTaxas {
	public class CalculoConsumo : OnPlaceMovel.Source.CalculoTaxas.ICalculoConsumo {
		#region Metodos publicos
		/// <summary>
		/// Calcula o consumo, fazendo virada e troca de hidrometro conforme necessário.
		/// </summary>
		/// <param name="movimento">Movimento com informacoes adicionais para fazer o calculo</param>
		/// <param name="leitura">Leitura para fazer o calculo do consumo</param>
		/// <returns>Retorna o calculo do consumo.</returns>
		public virtual int CalculaConsumo(OnpMovimento movimento, int leitura) {
			return CalculaConsumo(movimento, leitura, false);
		}

		/// <summary>
		/// Calcula o consumo, fazendo virada e troca de hidrometro conforme necessário.
		/// </summary>
		/// <param name="movimento">Movimento com informacoes adicionais para fazer o calculo</param>
		/// <param name="leitura">Leitura para fazer o calculo do consumo</param>
		/// <param name="ajusta">Ignorado para classe padrão</param>
		/// <returns>Retorna o calculo do consumo.</returns>
		public virtual int CalculaConsumo(OnpMovimento movimento, int leitura, bool ajusta) {
			// Consumo
			int consumo = 0;

			// Caso nao tenha tido troca
			if (!string.IsNullOrEmpty(movimento.IndMotivoRetirada))
				consumo += movimento.ValConsumoTroca.Value;

			// Caso a leitura atual seja menor que a anterior
			if (leitura < movimento.ValLeituraAnterior.Value)
				consumo += ConsumoVirada(movimento, leitura);
			else
				consumo += (leitura - movimento.ValLeituraAnterior.Value);

			return consumo;
		}

		public virtual bool PodeCalcular(OnpMovimento movimento) {
			return true;
		}
		#endregion // Metodos publicos

		#region Metodos Privados
		/// <summary>
		/// Calcula o consumo de virada
		/// </summary>
		/// <returns>Retorna o valor do consumo para virada de hidrometro</returns>
		protected virtual int ConsumoVirada(OnpMovimento movimento, int leitura) {
			return movimento.LeituraMaxima() - movimento.ValLeituraAnterior.Value + leitura;
		}
		#endregion // Metodos Privados
	}
}
