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
    public class ServicoFaturaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<ServicoFatura> Lista()
        {
            ServicoFaturaDAO ServicoFatura = new ServicoFaturaDAO();
            return ServicoFatura.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<ServicoFatura> ListServicoFatura)
        {
            ServicoFaturaDAO ServicoFatura = new ServicoFaturaDAO();

            try
            {
                foreach(ServicoFatura ItemServicoFatura in ListServicoFatura)
                    ServicoFatura.Insert(ItemServicoFatura);
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
            ServicoFaturaDAO ServicoFatura = new ServicoFaturaDAO();
            List<ServicoFatura> lista = ServicoFatura.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(ServicoFatura item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}