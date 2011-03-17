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
    public class CategoriaDiademaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaDiadema> Lista()
        {
            CategoriaDiademaDAO CategoriaDiadema = new CategoriaDiademaDAO();
            return CategoriaDiadema.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<CategoriaDiadema> ListCategoriaDiadema)
        {
            CategoriaDiademaDAO CategoriaDiadema = new CategoriaDiademaDAO();

            try
            {
                foreach(CategoriaDiadema ItemCategoriaDiadema in ListCategoriaDiadema)
                    CategoriaDiadema.Insert(ItemCategoriaDiadema);
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
            CategoriaDiademaDAO CategoriaDiadema = new CategoriaDiademaDAO();
            List<CategoriaDiadema> lista = CategoriaDiadema.Importar(grupo,rotaIni,rotaFim);
            foreach(CategoriaDiadema item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}