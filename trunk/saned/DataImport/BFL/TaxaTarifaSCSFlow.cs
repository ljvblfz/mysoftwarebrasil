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
    public class TaxaTarifaSCSFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TaxaTarifaSCS> Lista()
        {
            TaxaTarifaSCSDAO TaxaTarifaSCS = new TaxaTarifaSCSDAO();
            return TaxaTarifaSCS.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TaxaTarifaSCS> ListTaxaTarifaSCS)
        {
            TaxaTarifaSCSDAO TaxaTarifaSCS = new TaxaTarifaSCSDAO();

            try
            {
                foreach(TaxaTarifaSCS ItemTaxaTarifaSCS in ListTaxaTarifaSCS)
                    TaxaTarifaSCS.Insert(ItemTaxaTarifaSCS);
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
            TaxaTarifaSCSDAO TaxaTarifaSCS = new TaxaTarifaSCSDAO();
            List<TaxaTarifaSCS> lista = TaxaTarifaSCS.Importar(grupo,rotaIni,rotaFim);
            foreach(TaxaTarifaSCS item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}