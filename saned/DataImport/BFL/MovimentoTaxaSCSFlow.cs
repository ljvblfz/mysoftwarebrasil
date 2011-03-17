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
    public class MovimentoTaxaSCSFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MovimentoTaxaSCS> Lista()
        {
            MovimentoTaxaSCSDAO MovimentoTaxaSCS = new MovimentoTaxaSCSDAO();
            return MovimentoTaxaSCS.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MovimentoTaxaSCS> ListMovimentoTaxaSCS)
        {
            MovimentoTaxaSCSDAO MovimentoTaxaSCS = new MovimentoTaxaSCSDAO();

            try
            {
                foreach(MovimentoTaxaSCS ItemMovimentoTaxaSCS in ListMovimentoTaxaSCS)
                    MovimentoTaxaSCS.Insert(ItemMovimentoTaxaSCS);
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
            MovimentoTaxaSCSDAO MovimentoTaxaSCS = new MovimentoTaxaSCSDAO();
            List<MovimentoTaxaSCS> lista = MovimentoTaxaSCS.Importar(grupo,rotaIni,rotaFim);
            foreach(MovimentoTaxaSCS item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}