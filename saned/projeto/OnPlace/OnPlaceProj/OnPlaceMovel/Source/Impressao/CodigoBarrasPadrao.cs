using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;

namespace OnPlaceMovel.Source.Impressao {
	public class CodigoBarrasPadrao : ICodigoBarras {
		/// <summary>
		/// Construtor padrão
		/// </summary>
		public CodigoBarrasPadrao() {
		}
		
		#region ICodigoBarras Members
		/// <summary>
		/// Extrai o ano e o mes do código de referência passado
		/// </summary>
		/// <param name="codReferencia">Referencia com ano e mes</param>
		/// <param name="ano">Variavel para receber o ano</param>
		/// <param name="mes">Variavel para receber o mes</param>
		public static void getAnoMes(string codReferencia, out int ano, out int mes) {
			ano = int.Parse(codReferencia.Substring(0, 4));
			mes = int.Parse(codReferencia.Substring(5));
		}

		/// <summary>
		/// Calcula o digito verificador do codigo de barras
		/// </summary>
		/// <param name="codigo">String com o codigo a ter o digito calculado</param>
		/// <returns>Retorna o numero de 0 a 9</returns>
		public static int calculaDigito10(string codigo) {
			int soma = 0;// Peso do digito
			bool impar = ((codigo.Length % 2) != 0);

			// Digito a digito
			foreach (char digito in codigo) {
				// Se for numerico
				if ("0123456789".IndexOf(digito) >= 0) {
					int digitoValor = int.Parse(digito.ToString()) * (impar ? 2 : 1);
					impar = !impar;
					soma += (digitoValor >= 10 ? (1 + (digitoValor - 10)) : digitoValor);
				}
			}

			if ((soma % 10) != 0) {
				soma = 10 - (soma % 10);
			} else {
				soma = 0;
			}

			return soma;
		}
		
		/// <summary>
		/// Gera codigo de barras
		/// </summary>
		/// <returns>Retorna o codigo de barras para ser impresso</returns>
		public virtual string gerarCodigoBarras(OnpFatura fatura) {
			// Resultado
			string result = string.Empty;

			// Codigo de barras
			StringBuilder codigoBarras = new StringBuilder();

			// ***** MONTA BARRA DE CONTROLE *****

			// Fixo
			codigoBarras.Append("826");

			// Valor total
			int valorinteiro = 0;
			int valorint = 0;

			if (fatura.ValValorFaturado.HasValue) {
				double valFatArrendondado = System.Math.Round(fatura.ValValorFaturado.Value, 2);
				valorinteiro = (int)valFatArrendondado;
				int x0 = (int)valFatArrendondado;
				int x1 = (int)(x0 * 100);
				int x2 = (int)(valorinteiro * 100);
				valorint = x1 - x2;
			}

			codigoBarras.Append(valorinteiro.ToString("D9"));
			codigoBarras.Append(valorint.ToString("D2"));

			// Fixo
			codigoBarras.Append("0035");

			// Vencimento DDMMAA
			codigoBarras.Append(fatura.DatVencimento.Value.Day.ToString("D2"));
			codigoBarras.Append(fatura.DatVencimento.Value.Month.ToString("D2"));
			codigoBarras.Append(fatura.DatVencimento.Value.Year.ToString("D4").Substring(2, 2));

			// Matricula
			codigoBarras.Append(fatura.SeqMatricula.Value.ToString("D8"));

			// Referencia
			int anoReferencia, mesReferencia;
			getAnoMes(fatura.CodReferencia, out anoReferencia, out mesReferencia);

			codigoBarras.Append(anoReferencia.ToString("D4"));
			codigoBarras.Append(mesReferencia.ToString("D2"));

			// Zeros à direita para preencher 44
			codigoBarras.Append('0', 43 - codigoBarras.Length);

			// Digito verificador
			string digito = calculaDigito10(codigoBarras.ToString()).ToString();

			// Monta o codigo
			result = codigoBarras.ToString();
			result = result.Substring(0, 3) + digito + result.Substring(3);

			return result;
		}

		/// <summary>
		/// Gera linha digitavel
		/// </summary>
		/// <returns>Retorna uma string com a linha digitavel</returns>
		public virtual string gerarLinhaDigitavel(OnpFatura fatura) {
			StringBuilder sb = new StringBuilder();
            string codigoBarras = string.IsNullOrEmpty(fatura.DesCodigoBarras) ? gerarCodigoBarras(fatura) : fatura.DesCodigoBarras;

			// Partes da linha
			string part1 = codigoBarras.Substring(0, 11);
			string part2 = codigoBarras.Substring(11, 11);
			string part3 = codigoBarras.Substring(22, 11);
			string part4 = codigoBarras.Substring(33, 11);

			sb.Append(part1);
			sb.Append(calculaDigito10(part1));

			sb.Append(part2);
			sb.Append(calculaDigito10(part2));

			sb.Append(part3);
			sb.Append(calculaDigito10(part3));

			sb.Append(part4);
			sb.Append(calculaDigito10(part4));

			return sb.ToString();
		}
		#endregion
	}
}
