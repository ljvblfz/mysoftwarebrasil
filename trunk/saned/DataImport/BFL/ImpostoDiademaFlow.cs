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
    public class ImpostoDiademaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<ImpostoDiadema> Lista()
        {
            ImpostoDiademaDAO ImpostoDiadema = new ImpostoDiademaDAO();
            return ImpostoDiadema.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<ImpostoDiadema> ListImpostoDiadema)
        {
            ImpostoDiademaDAO ImpostoDiadema = new ImpostoDiademaDAO();

            try
            {
                foreach(ImpostoDiadema ItemImpostoDiadema in ListImpostoDiadema)
                    ImpostoDiadema.Insert(ItemImpostoDiadema);
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
            ImpostoDiademaDAO ImpostoDiadema = new ImpostoDiademaDAO();
            List<ImpostoDiadema> lista = ImpostoDiadema.Importar(grupo,rotaIni,rotaFim);
            foreach(ImpostoDiadema item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}