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
    public class MovimentoFotoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MovimentoFoto> Lista()
        {
            MovimentoFotoDAO MovimentoFoto = new MovimentoFotoDAO();
            return MovimentoFoto.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MovimentoFoto> ListMovimentoFoto)
        {
            MovimentoFotoDAO MovimentoFoto = new MovimentoFotoDAO();

            try
            {
                foreach(MovimentoFoto ItemMovimentoFoto in ListMovimentoFoto)
                    MovimentoFoto.Insert(ItemMovimentoFoto);
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
            MovimentoFotoDAO MovimentoFoto = new MovimentoFotoDAO();
            List<MovimentoFoto> lista = MovimentoFoto.Importar(grupo,rotaIni,rotaFim);
            foreach(MovimentoFoto item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}