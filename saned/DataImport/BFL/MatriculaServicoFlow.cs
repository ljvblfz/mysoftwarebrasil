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
    public class MatriculaServicoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MatriculaServico> Lista()
        {
            MatriculaServicoDAO MatriculaServico = new MatriculaServicoDAO();
            return MatriculaServico.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MatriculaServico> ListMatriculaServico)
        {
            MatriculaServicoDAO MatriculaServico = new MatriculaServicoDAO();

            try
            {
                foreach(MatriculaServico ItemMatriculaServico in ListMatriculaServico)
                    MatriculaServico.Insert(ItemMatriculaServico);
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
            MatriculaServicoDAO MatriculaServico = new MatriculaServicoDAO();
            List<MatriculaServico> lista = MatriculaServico.Importar(grupo,rotaIni,rotaFim);
            foreach(MatriculaServico item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}