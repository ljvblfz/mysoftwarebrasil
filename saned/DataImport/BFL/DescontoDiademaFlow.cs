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
    public class DescontoDiademaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<DescontoDiadema> Lista()
        {
            DescontoDiademaDAO DescontoDiadema = new DescontoDiademaDAO();
            return DescontoDiadema.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<DescontoDiadema> ListDescontoDiadema)
        {
            DescontoDiademaDAO DescontoDiadema = new DescontoDiademaDAO();

            try
            {
                foreach(DescontoDiadema ItemDescontoDiadema in ListDescontoDiadema)
                    DescontoDiadema.Insert(ItemDescontoDiadema);
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
            DescontoDiademaDAO DescontoDiadema = new DescontoDiademaDAO();
            List<DescontoDiadema> lista = DescontoDiadema.Importar(grupo,rotaIni,rotaFim);
            foreach(DescontoDiadema item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}