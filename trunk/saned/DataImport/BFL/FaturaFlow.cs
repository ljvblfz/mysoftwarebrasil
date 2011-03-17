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
    public class FaturaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Fatura> Lista()
        {
            FaturaDAO Fatura = new FaturaDAO();
            return Fatura.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Fatura> ListFatura)
        {
            FaturaDAO Fatura = new FaturaDAO();

            try
            {
                foreach(Fatura ItemFatura in ListFatura)
                    Fatura.Insert(ItemFatura);
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
            FaturaDAO Fatura = new FaturaDAO();
            List<Fatura> lista = Fatura.Importar(grupo,rotaIni,rotaFim,DateTime.Now);
            foreach(Fatura item in lista)
            {
                result += item.__ToSQL.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "") + ";\n";
            }
            return result;
        }
    }
}