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
    public class CategoriaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Categoria> Lista()
        {
            CategoriaDAO Categoria = new CategoriaDAO();
            return Categoria.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Categoria> ListCategoria)
        {
            CategoriaDAO Categoria = new CategoriaDAO();

            try
            {
                foreach(Categoria ItemCategoria in ListCategoria)
                    Categoria.Insert(ItemCategoria);
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
            CategoriaDAO Categoria = new CategoriaDAO();
            List<Categoria> lista = Categoria.Importar(grupo,rotaIni,rotaFim);
            foreach(Categoria item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}