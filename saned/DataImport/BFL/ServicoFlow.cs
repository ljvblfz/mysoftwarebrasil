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
    public class ServicoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Servico> Lista()
        {
            ServicoDAO Servico = new ServicoDAO();
            return Servico.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Servico> ListServico)
        {
            ServicoDAO Servico = new ServicoDAO();

            try
            {
                foreach(Servico ItemServico in ListServico)
                    Servico.Insert(ItemServico);
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
            ServicoDAO Servico = new ServicoDAO();
            List<Servico> lista = Servico.Importar(grupo,rotaIni,rotaFim);
            foreach(Servico item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}