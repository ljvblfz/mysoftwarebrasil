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
    public class TabelasCargaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TabelasCarga> Lista()
        {
            TabelasCargaDAO TabelasCarga = new TabelasCargaDAO();
            return TabelasCarga.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TabelasCarga> ListTabelasCarga)
        {
            TabelasCargaDAO TabelasCarga = new TabelasCargaDAO();

            try
            {
                foreach(TabelasCarga ItemTabelasCarga in ListTabelasCarga)
                    TabelasCarga.Insert(ItemTabelasCarga);
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
            TabelasCargaDAO TabelasCarga = new TabelasCargaDAO();
            List<TabelasCarga> lista = TabelasCarga.Importar(grupo,rotaIni,rotaFim);
            foreach(TabelasCarga item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}