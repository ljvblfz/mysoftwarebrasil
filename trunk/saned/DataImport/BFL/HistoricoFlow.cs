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
    public class HistoricoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Historico> Lista()
        {
            HistoricoDAO Historico = new HistoricoDAO();
            return Historico.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Historico> ListHistorico)
        {
            HistoricoDAO Historico = new HistoricoDAO();

            try
            {
                foreach(Historico ItemHistorico in ListHistorico)
                    Historico.Insert(ItemHistorico);
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
            HistoricoDAO Historico = new HistoricoDAO();
            List<Historico> lista = Historico.Importar(grupo,rotaIni,rotaFim);
            foreach(Historico item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}