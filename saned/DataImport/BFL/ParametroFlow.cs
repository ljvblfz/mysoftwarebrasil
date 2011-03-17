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
    public class ParametroFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Parametro> Lista()
        {
            ParametroDAO Parametro = new ParametroDAO();
            return Parametro.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Parametro> ListParametro)
        {
            ParametroDAO Parametro = new ParametroDAO();

            try
            {
                foreach(Parametro ItemParametro in ListParametro)
                    Parametro.Insert(ItemParametro);
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
            ParametroDAO Parametro = new ParametroDAO();
            List<Parametro> lista = Parametro.Importar(grupo,rotaIni,rotaFim);
            foreach(Parametro item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}