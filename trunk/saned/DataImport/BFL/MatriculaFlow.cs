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
    public class MatriculaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Matricula> Lista()
        {
            MatriculaDAO Matricula = new MatriculaDAO();
            return Matricula.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Matricula> ListMatricula)
        {
            MatriculaDAO Matricula = new MatriculaDAO();

            try
            {
                foreach(Matricula ItemMatricula in ListMatricula)
                    Matricula.Insert(ItemMatricula);
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
            MatriculaDAO Matricula = new MatriculaDAO();
            List<Matricula> lista = Matricula.Importar(grupo,rotaIni,rotaFim,DateTime.Now);
            foreach(Matricula item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}