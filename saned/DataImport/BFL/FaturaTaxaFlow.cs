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
    public class FaturaTaxaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<FaturaTaxa> Lista()
        {
            FaturaTaxaDAO FaturaTaxa = new FaturaTaxaDAO();
            return FaturaTaxa.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<FaturaTaxa> ListFaturaTaxa)
        {
            FaturaTaxaDAO FaturaTaxa = new FaturaTaxaDAO();

            try
            {
                foreach(FaturaTaxa ItemFaturaTaxa in ListFaturaTaxa)
                    FaturaTaxa.Insert(ItemFaturaTaxa);
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
            FaturaTaxaDAO FaturaTaxa = new FaturaTaxaDAO();
            List<FaturaTaxa> lista = FaturaTaxa.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(FaturaTaxa item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}