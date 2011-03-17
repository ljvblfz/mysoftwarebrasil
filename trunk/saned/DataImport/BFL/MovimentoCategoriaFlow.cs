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
    public class MovimentoCategoriaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MovimentoCategoria> Lista()
        {
            MovimentoCategoriaDAO MovimentoCategoria = new MovimentoCategoriaDAO();
            return MovimentoCategoria.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MovimentoCategoria> ListMovimentoCategoria)
        {
            MovimentoCategoriaDAO MovimentoCategoria = new MovimentoCategoriaDAO();

            try
            {
                foreach(MovimentoCategoria ItemMovimentoCategoria in ListMovimentoCategoria)
                    MovimentoCategoria.Insert(ItemMovimentoCategoria);
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
            MovimentoCategoriaDAO MovimentoCategoria = new MovimentoCategoriaDAO();
            List<MovimentoCategoria> lista = MovimentoCategoria.Importar(grupo,rotaIni,rotaFim);
            foreach(MovimentoCategoria item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}