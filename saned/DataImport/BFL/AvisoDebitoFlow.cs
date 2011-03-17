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
    public class AvisoDebitoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<AvisoDebito> Lista()
        {
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();
            return AvisoDebito.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<AvisoDebito> ListAvisoDebito)
        {
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();

            try
            {
                foreach(AvisoDebito ItemAvisoDebito in ListAvisoDebito)
                    AvisoDebito.Insert(ItemAvisoDebito);
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
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();
            List<AvisoDebito> lista = AvisoDebito.Importar(grupo,rotaIni,rotaFim);
            foreach(AvisoDebito item in lista)
            {
                result += item.__ToSQL.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "") + ";\n";
            }
            return result;
        }
    }
}