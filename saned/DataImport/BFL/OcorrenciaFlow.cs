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
    public class OcorrenciaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Ocorrencia> Lista()
        {
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();
            return Ocorrencia.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Ocorrencia> ListOcorrencia)
        {
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();

            try
            {
                foreach(Ocorrencia ItemOcorrencia in ListOcorrencia)
                    Ocorrencia.Insert(ItemOcorrencia);
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
            OcorrenciaDAO Ocorrencia = new OcorrenciaDAO();
            List<Ocorrencia> lista = Ocorrencia.Importar(grupo,rotaIni,rotaFim);
            foreach(Ocorrencia item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}