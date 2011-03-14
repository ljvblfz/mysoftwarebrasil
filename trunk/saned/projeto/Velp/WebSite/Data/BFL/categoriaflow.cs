using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriaFlow:CategoriaDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CategoriaONP> ListaCategoria()
        {
            CategoriaDAO Categoria = new CategoriaDAO();
            return Categoria.Lista();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq_categoria"></param>
        /// <returns></returns>
        public static List<CategoriaONP> ListaCategoria(int seq_categoria)
        {
            CategoriaDAO Categoria = new CategoriaDAO();
            string where = String.Format("seq_categoria = {0}", seq_categoria);
            return Categoria.Select(new GDA.Sql.Query(where));
        }
    }
}