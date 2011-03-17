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
    public class MovimentoOcorrenciaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MovimentoOcorrencia> Lista()
        {
            MovimentoOcorrenciaDAO MovimentoOcorrencia = new MovimentoOcorrenciaDAO();
            return MovimentoOcorrencia.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MovimentoOcorrencia> ListMovimentoOcorrencia)
        {
            MovimentoOcorrenciaDAO MovimentoOcorrencia = new MovimentoOcorrenciaDAO();

            try
            {
                foreach(MovimentoOcorrencia ItemMovimentoOcorrencia in ListMovimentoOcorrencia)
                    MovimentoOcorrencia.Insert(ItemMovimentoOcorrencia);
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
            MovimentoOcorrenciaDAO MovimentoOcorrencia = new MovimentoOcorrenciaDAO();
            List<MovimentoOcorrencia> lista = MovimentoOcorrencia.Importar(grupo,rotaIni,rotaFim);
            foreach(MovimentoOcorrencia item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}