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
    public class TaxaTarifaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TaxaTarifa> Lista()
        {
            TaxaTarifaDAO TaxaTarifa = new TaxaTarifaDAO();
            return TaxaTarifa.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TaxaTarifa> ListTaxaTarifa)
        {
            TaxaTarifaDAO TaxaTarifa = new TaxaTarifaDAO();

            try
            {
                foreach(TaxaTarifa ItemTaxaTarifa in ListTaxaTarifa)
                    TaxaTarifa.Insert(ItemTaxaTarifa);
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
            TaxaTarifaDAO TaxaTarifa = new TaxaTarifaDAO();
            List<TaxaTarifa> lista = TaxaTarifa.Importar(grupo,rotaIni,rotaFim);
            foreach(TaxaTarifa item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}