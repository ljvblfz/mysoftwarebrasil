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
    public class MatriculaSCSFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MatriculaSCS> Lista()
        {
            MatriculaSCSDAO MatriculaSCS = new MatriculaSCSDAO();
            return MatriculaSCS.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MatriculaSCS> ListMatriculaSCS)
        {
            MatriculaSCSDAO MatriculaSCS = new MatriculaSCSDAO();

            try
            {
                foreach(MatriculaSCS ItemMatriculaSCS in ListMatriculaSCS)
                    MatriculaSCS.Insert(ItemMatriculaSCS);
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
            MatriculaSCSDAO MatriculaSCS = new MatriculaSCSDAO();
            List<MatriculaSCS> lista = MatriculaSCS.Importar(grupo,rotaIni,rotaFim);
            foreach(MatriculaSCS item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}