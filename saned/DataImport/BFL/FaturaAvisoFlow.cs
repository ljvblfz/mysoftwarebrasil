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
    public class FaturaAvisoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<FaturaAviso> Lista()
        {
            FaturaAvisoDAO FaturaAviso = new FaturaAvisoDAO();
            return FaturaAviso.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<FaturaAviso> ListFaturaAviso)
        {
            FaturaAvisoDAO FaturaAviso = new FaturaAvisoDAO();

            try
            {
                foreach(FaturaAviso ItemFaturaAviso in ListFaturaAviso)
                    FaturaAviso.Insert(ItemFaturaAviso);
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
            FaturaAvisoDAO FaturaAviso = new FaturaAvisoDAO();
            List<FaturaAviso> lista = FaturaAviso.Importar(grupo,rotaIni,rotaFim);
            foreach(FaturaAviso item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}