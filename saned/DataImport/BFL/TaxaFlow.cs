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
    public class TaxaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Taxa> Lista()
        {
            TaxaDAO Taxa = new TaxaDAO();
            return Taxa.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Taxa> ListTaxa)
        {
            TaxaDAO Taxa = new TaxaDAO();

            try
            {
                foreach(Taxa ItemTaxa in ListTaxa)
                    Taxa.Insert(ItemTaxa);
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
            TaxaDAO Taxa = new TaxaDAO();
            List<Taxa> lista = Taxa.Importar(grupo,rotaIni,rotaFim);
            foreach(Taxa item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}