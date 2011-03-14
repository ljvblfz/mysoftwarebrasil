using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Impressao;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.CalculoTaxas;

namespace OnPlaceMovel.Source.Diadema {
    public class CodigoBarrasDiadema : CodigoBarrasPadrao {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public CodigoBarrasDiadema() {
        }

        /// <summary>
        /// Gera codigo de barras
        /// </summary>
        /// <returns>Retorna o codigo de barras para ser impresso</returns>
        public override string gerarCodigoBarras(OnpFatura fatura) {
            // Codigo de barras
            StringBuilder codigoBarras = new StringBuilder();

            // Fixo
            codigoBarras.Append("826");

            // Valor total
            int valorinteiro = 0;
            int valorint = 0;

            if (fatura.ValValorFaturado.HasValue) {
				double valFatArrendondado = CalculaTaxasPadrao.Arrendonda(fatura.ValValorFaturado.Value, 2);
				valorinteiro = (int)valFatArrendondado;
				valorint = (int)CalculaTaxasPadrao.Arrendonda((valFatArrendondado - (double)valorinteiro) * 100);
            }

            codigoBarras.Append(valorinteiro.ToString("D9"));
            codigoBarras.Append(valorint.ToString("D2"));

            // Codigo da empresa
            codigoBarras.Append("0122");

            // calculo de digitos verificadores

            string calculoDigito = string.Empty;
            calculoDigito = "018"; // fixo para saned

            // Matricula
            calculoDigito += fatura.SeqMatricula.Value.ToString("D6");

            // Referencia
            int anoReferencia, mesReferencia;
            getAnoMes(fatura.CodReferencia, out anoReferencia, out mesReferencia);

            calculoDigito += mesReferencia.ToString("D2");
            calculoDigito += anoReferencia.ToString("D4");

            codigoBarras.Append(calculoDigito);
            
            // Vencimento DDMMAA
            codigoBarras.Append(fatura.DatVencimento.Value.Day.ToString("D2"));
            codigoBarras.Append(fatura.DatVencimento.Value.Month.ToString("D2"));
            codigoBarras.Append(fatura.DatVencimento.Value.Year.ToString("D4"));

            // Digito verificador 1
            string digito1 = calculaDigitoSaned(calculoDigito, 1);
            codigoBarras.Append(digito1);
            
            // Digito verificador 2
            string digito2 = calculaDigitoSaned(calculoDigito + digito1, 2);
            codigoBarras.Append(digito2);


            // Digito verificador da barra
            string result = codigoBarras.ToString();
            string digitoBarra = calculaDigito10(result).ToString();

            // Adiciona digito verificador da barra
            result = result.Substring(0, 3) + digitoBarra + result.Substring(3);

            return result;
        }

        /// <summary>
        /// Calculo de digito verificador para SANED
        /// </summary>
        /// <param name="calculoDigito">String com codigo a ter digito calculado</param>
        /// <param name="tipo">Tipo a ser calculado (1 ou 2)</param>
        /// <returns>Retorna o digito calculado</returns>
        public string calculaDigitoSaned(string calculoDigito, int tipo) {
            if (tipo == 1)
                return calculaDigitoSaned1(calculoDigito);
            else if (tipo == 2)
                return calculaDigitoSaned2(calculoDigito);

            return string.Empty;
        }

        /// <summary>
        /// Calculo de digito verificador tipo 1 para SANED
        /// </summary>
        /// <param name="calculoDigito">String com codigo a ter digito calculado</param>
        /// <returns>Retorna o digito calculado</returns>
        private string calculaDigitoSaned1(string calculoDigito) {
            int multiplicador = 16, valor = 0, digito;

            foreach (char c in calculoDigito) {
                valor += int.Parse(c.ToString()) * multiplicador;
                multiplicador--;
            }

            valor = valor % 11;

            if (valor <= 1)
                digito = 0;
            else
                digito = 11 - valor;

            return digito.ToString();
        }

        /// <summary>
        /// Calculo de digito verificador tipo 2 para SANED
        /// </summary>
        /// <param name="calculoDigito">String com codigo a ter digito calculado</param>
        /// <returns>Retorna o digito calculado</returns>
        private string calculaDigitoSaned2(string calculoDigito) {
            int multiplicador = 2, valor = 0, digito, aux;

            foreach (char c in calculoDigito) {
                aux = int.Parse(c.ToString()) * multiplicador;

                if (aux >= 10)
                    aux -= 9;

                valor += aux;
                multiplicador = (multiplicador == 2) ? 1 : 2;
            }

            valor = valor % 10;

            if (valor == 0)
                digito = 0;
            else
                digito = 10 - valor;

            return digito.ToString();
        }
    }
}

