using System;
using System.Text;
using System.Collections.Generic;
using OnPlaceMovel.Source.CalculoTaxas;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.Diadema {
	public sealed class CalculoConsumoDiadema : CalculoConsumo {
		#region Metodos Publicos
		/// <summary>
		/// Faz o calculo do consumo com ajuste
		/// </summary>
		/// <param name="movimento">Movimento com informacoes adicionais para calculo</param>
		/// <param name="leitura">Leitura entrada pelo usuario</param>
		/// <returns>Retorna o consumo calculo COM AJUSTE caso necessario.</returns>
		public override int CalculaConsumo(OnpMovimento movimento, int leitura) {
			return CalculaConsumo(movimento, leitura, true);
		}

		/// <summary>
		/// Calcula o consumo, fazendo virada e troca de hidrometro conforme necessário.
		/// </summary>
		/// <param name="movimento">Movimento com informacoes adicionais para fazer o calculo</param>
		/// <param name="leitura">Leitura para fazer o calculo do consumo</param>
		/// <param name="ajusta">Só vai ajustar se <paramref name="diasAjuste"/> for igual a true. Caso ajusta for false e seja necessario ajustar, o ajuste NAO sera feito.</param>
		/// <returns>Retorna o calculo do consumo.</returns>
		public override int CalculaConsumo(OnpMovimento movimento, int leitura, bool ajusta) {
			// Consumo
			int consumo = 0;

			// Caso nao tenha tido troca
			if (movimento.DatTroca.HasValue) {
				consumo = leitura - movimento.ValLeituraAnterior.Value;

				if (ajusta) {
					int diasMedidorNovo = (DateTime.Now - movimento.DatTroca.Value).Days;
					int diasParaCalculo = (DateTime.Now - movimento.DatLeituraAnterior.Value).Days;

					if (diasParaCalculo > 31)
						diasParaCalculo = 31;

					consumo = (int)CalculaTaxasPadrao.Arrendonda(consumo * diasParaCalculo / (double)diasMedidorNovo, 0);
				}
			} else {				
				// Caso a leitura atual seja menor que a anterior
				if (leitura < movimento.ValLeituraAnterior.Value)
					consumo += ConsumoVirada(movimento, leitura);
				else
					consumo += (leitura - movimento.ValLeituraAnterior.Value);

                consumo = CalculaConsumoAjustado(movimento, consumo, CalculaTaxasDiadema.DiasDeConsumo, CalculaTaxasDiadema.DiasDeConsumoMax, ajusta);
			}

			return consumo;
		}

		public override bool PodeCalcular(OnpMovimento movimento) {
			OnpMatriculaDiadema matd = new OnpMatriculaDiadema(movimento.SeqMatricula.Value);

			if (OnpMatriculaDiadema.TipoConsumidor.HDComunitario.Equals(matd.IndTipoConsumidor) && matd.isFilho)
				return false;

			return base.PodeCalcular(movimento);
		}
		#endregion // Metodos Publicos

		#region Metodos Privados
		/// <summary>
		/// Calcula o consumo ajustado com base na leitura recebido e na leitura anterior do movimento recebido
		/// </summary>
		/// <param name="movimento">Movimento com informacoes adicionais para fazer o calculo</param>
		/// <param name="consumo">Consumo a ser ajustado</param>
		/// <param name="diasAjuste">Dias limite para fazer o ajuste</param>
		/// <param name="ajusta">Só vai ajustar se <paramref name="diasAjuste"/> for igual a true, mesmo que dias de consumo seja maior que <paramref name="diasAjuste"/></param>
		/// <returns>Retorna o consumo ajustado.</returns>
        private int CalculaConsumoAjustado(OnpMovimento movimento, int consumo, int diasAjuste, int diasAjusteMax, bool ajusta) {
			TimeSpan tsLeitura = DateTime.Now.Date - movimento.DatLeituraAnterior.Value.Date;
			int diasLeitura = tsLeitura.Days;

			// Verifica se ajusta
            if (diasLeitura > diasAjuste && diasLeitura <= diasAjusteMax && ajusta) {
				double consumoAjustado = CalculaTaxasPadrao.Arrendonda(consumo * diasAjuste / (double)diasLeitura, 0);
				consumo = (int)consumoAjustado;
			}

			return consumo;
		}
		#endregion // Metodos Privados
	}
}
