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
    public class MatriculaImpostoDiademaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MatriculaImpostoDiadema> Lista()
        {
            MatriculaImpostoDiademaDAO MatriculaImpostoDiadema = new MatriculaImpostoDiademaDAO();
            return MatriculaImpostoDiadema.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MatriculaImpostoDiadema> ListMatriculaImpostoDiadema)
        {
            MatriculaImpostoDiademaDAO MatriculaImpostoDiadema = new MatriculaImpostoDiademaDAO();

            try
            {
                foreach(MatriculaImpostoDiadema ItemMatriculaImpostoDiadema in ListMatriculaImpostoDiadema)
                    MatriculaImpostoDiadema.Insert(ItemMatriculaImpostoDiadema);
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
            MatriculaImpostoDiademaDAO MatriculaImpostoDiadema = new MatriculaImpostoDiademaDAO();
            List<MatriculaImpostoDiadema> lista = MatriculaImpostoDiadema.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(MatriculaImpostoDiadema item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}