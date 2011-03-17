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
    public class MatriculaAlteracaoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MatriculaAlteracao> Lista()
        {
            MatriculaAlteracaoDAO MatriculaAlteracao = new MatriculaAlteracaoDAO();
            return MatriculaAlteracao.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MatriculaAlteracao> ListMatriculaAlteracao)
        {
            MatriculaAlteracaoDAO MatriculaAlteracao = new MatriculaAlteracaoDAO();

            try
            {
                foreach(MatriculaAlteracao ItemMatriculaAlteracao in ListMatriculaAlteracao)
                    MatriculaAlteracao.Insert(ItemMatriculaAlteracao);
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
            MatriculaAlteracaoDAO MatriculaAlteracao = new MatriculaAlteracaoDAO();
            List<MatriculaAlteracao> lista = MatriculaAlteracao.Importar(grupo,rotaIni,rotaFim);
            foreach(MatriculaAlteracao item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}