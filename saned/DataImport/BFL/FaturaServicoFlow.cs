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
    public class FaturaServicoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<FaturaServico> Lista()
        {
            FaturaServicoDAO FaturaServico = new FaturaServicoDAO();
            return FaturaServico.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<FaturaServico> ListFaturaServico)
        {
            FaturaServicoDAO FaturaServico = new FaturaServicoDAO();

            try
            {
                foreach(FaturaServico ItemFaturaServico in ListFaturaServico)
                    FaturaServico.Insert(ItemFaturaServico);
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
            FaturaServicoDAO FaturaServico = new FaturaServicoDAO();
            List<FaturaServico> lista = FaturaServico.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(FaturaServico item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}