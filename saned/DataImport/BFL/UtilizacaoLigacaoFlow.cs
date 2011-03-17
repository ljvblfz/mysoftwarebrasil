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
    public class UtilizacaoLigacaoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<UtilizacaoLigacao> Lista()
        {
            UtilizacaoLigacaoDAO UtilizacaoLigacao = new UtilizacaoLigacaoDAO();
            return UtilizacaoLigacao.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<UtilizacaoLigacao> ListUtilizacaoLigacao)
        {
            UtilizacaoLigacaoDAO UtilizacaoLigacao = new UtilizacaoLigacaoDAO();

            try
            {
                foreach(UtilizacaoLigacao ItemUtilizacaoLigacao in ListUtilizacaoLigacao)
                    UtilizacaoLigacao.Insert(ItemUtilizacaoLigacao);
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
            UtilizacaoLigacaoDAO UtilizacaoLigacao = new UtilizacaoLigacaoDAO();
            List<UtilizacaoLigacao> lista = UtilizacaoLigacao.Importar(grupo,rotaIni,rotaFim);
            foreach(UtilizacaoLigacao item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}