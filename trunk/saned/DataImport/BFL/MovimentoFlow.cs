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
    public class MovimentoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Movimento> Lista()
        {
            MovimentoDAO Movimento = new MovimentoDAO();
            return Movimento.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Movimento> ListMovimento)
        {
            MovimentoDAO Movimento = new MovimentoDAO();

            try
            {
                foreach(Movimento ItemMovimento in ListMovimento)
                    Movimento.Insert(ItemMovimento);
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
            MovimentoDAO Movimento = new MovimentoDAO();
            List<Movimento> lista = Movimento.Importar(grupo, rotaIni, rotaFim, 1,1);
            foreach(Movimento item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}