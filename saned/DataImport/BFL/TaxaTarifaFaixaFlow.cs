using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Sinc_DATA.DAL;
using Sinc_DATA.Model;

namespace Sinc_DATA.BFL
{
    public class TaxaTarifaFaixaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TaxaTarifaFaixa> Lista()
        {
            TaxaTarifaFaixaDAO TaxaTarifaFaixa = new TaxaTarifaFaixaDAO();
            return TaxaTarifaFaixa.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TaxaTarifaFaixa> ListTaxaTarifaFaixa)
        {
            TaxaTarifaFaixaDAO TaxaTarifaFaixa = new TaxaTarifaFaixaDAO();

            try
            {
                foreach(TaxaTarifaFaixa ItemTaxaTarifaFaixa in ListTaxaTarifaFaixa)
                    TaxaTarifaFaixa.Insert(ItemTaxaTarifaFaixa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		
		/// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static string getImpotacao(int grupo,int rotaIni,int rotaFim)
        {
            string result = "";
            TaxaTarifaFaixaDAO TaxaTarifaFaixa = new TaxaTarifaFaixaDAO();
            List<TaxaTarifaFaixa> lista = TaxaTarifaFaixa.Importar(grupo,rotaIni,rotaFim);
            foreach(TaxaTarifaFaixa item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}