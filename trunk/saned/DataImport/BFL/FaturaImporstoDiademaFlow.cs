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
    public class FaturaImporstoDiademaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<FaturaImporstoDiadema> Lista()
        {
            FaturaImporstoDiademaDAO FaturaImporstoDiadema = new FaturaImporstoDiademaDAO();
            return FaturaImporstoDiadema.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<FaturaImporstoDiadema> ListFaturaImporstoDiadema)
        {
            FaturaImporstoDiademaDAO FaturaImporstoDiadema = new FaturaImporstoDiademaDAO();

            try
            {
                foreach(FaturaImporstoDiadema ItemFaturaImporstoDiadema in ListFaturaImporstoDiadema)
                    FaturaImporstoDiadema.Insert(ItemFaturaImporstoDiadema);
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
            FaturaImporstoDiademaDAO FaturaImporstoDiadema = new FaturaImporstoDiademaDAO();
            List<FaturaImporstoDiadema> lista = FaturaImporstoDiadema.Importar(grupo,rotaIni,rotaFim);
            foreach(FaturaImporstoDiadema item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}