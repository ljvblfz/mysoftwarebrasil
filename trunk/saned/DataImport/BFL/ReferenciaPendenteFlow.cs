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
    public class ReferenciaPendenteFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<ReferenciaPendente> Lista()
        {
            ReferenciaPendenteDAO ReferenciaPendente = new ReferenciaPendenteDAO();
            return ReferenciaPendente.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<ReferenciaPendente> ListReferenciaPendente)
        {
            ReferenciaPendenteDAO ReferenciaPendente = new ReferenciaPendenteDAO();

            try
            {
                foreach(ReferenciaPendente ItemReferenciaPendente in ListReferenciaPendente)
                    ReferenciaPendente.Insert(ItemReferenciaPendente);
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
            ReferenciaPendenteDAO ReferenciaPendente = new ReferenciaPendenteDAO();
            List<ReferenciaPendente> lista = ReferenciaPendente.Importar(grupo,rotaIni,rotaFim);
            foreach(ReferenciaPendente item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}