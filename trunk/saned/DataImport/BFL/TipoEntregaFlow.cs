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
    public class TipoEntregaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TipoEntrega> Lista()
        {
            TipoEntregaDAO TipoEntrega = new TipoEntregaDAO();
            return TipoEntrega.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TipoEntrega> ListTipoEntrega)
        {
            TipoEntregaDAO TipoEntrega = new TipoEntregaDAO();

            try
            {
                foreach(TipoEntrega ItemTipoEntrega in ListTipoEntrega)
                    TipoEntrega.Insert(ItemTipoEntrega);
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
            TipoEntregaDAO TipoEntrega = new TipoEntregaDAO();
            List<TipoEntrega> lista = TipoEntrega.Importar(grupo,rotaIni,rotaFim);
            foreach(TipoEntrega item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}