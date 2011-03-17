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
    public class MatriculaCargaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MatriculaCarga> Lista()
        {
            MatriculaCargaDAO MatriculaCarga = new MatriculaCargaDAO();
            return MatriculaCarga.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MatriculaCarga> ListMatriculaCarga)
        {
            MatriculaCargaDAO MatriculaCarga = new MatriculaCargaDAO();

            try
            {
                foreach(MatriculaCarga ItemMatriculaCarga in ListMatriculaCarga)
                    MatriculaCarga.Insert(ItemMatriculaCarga);
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
            MatriculaCargaDAO MatriculaCarga = new MatriculaCargaDAO();
            List<MatriculaCarga> lista = MatriculaCarga.Importar(grupo,rotaIni,rotaFim);
            foreach(MatriculaCarga item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}