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
    public class FaturaCategoriaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<FaturaCategoria> Lista()
        {
            FaturaCategoriaDAO FaturaCategoria = new FaturaCategoriaDAO();
            return FaturaCategoria.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<FaturaCategoria> ListFaturaCategoria)
        {
            FaturaCategoriaDAO FaturaCategoria = new FaturaCategoriaDAO();

            try
            {
                foreach(FaturaCategoria ItemFaturaCategoria in ListFaturaCategoria)
                    FaturaCategoria.Insert(ItemFaturaCategoria);
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
            FaturaCategoriaDAO FaturaCategoria = new FaturaCategoriaDAO();
            List<FaturaCategoria> lista = FaturaCategoria.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(FaturaCategoria item in lista)
            {
                result += item.__ToSQL.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "") + ";\n";
            }
            return result;
        }
    }
}