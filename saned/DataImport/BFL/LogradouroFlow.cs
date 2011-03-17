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
    public class LogradouroFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Logradouro> Lista()
        {
            LogradouroDAO Logradouro = new LogradouroDAO();
            return Logradouro.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Logradouro> ListLogradouro)
        {
            LogradouroDAO Logradouro = new LogradouroDAO();

            try
            {
                foreach(Logradouro ItemLogradouro in ListLogradouro)
                    Logradouro.Insert(ItemLogradouro);
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
            LogradouroDAO Logradouro = new LogradouroDAO();
            List<Logradouro> lista = Logradouro.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(Logradouro item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}