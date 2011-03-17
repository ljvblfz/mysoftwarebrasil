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
    public class MovimentoTaxaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MovimentoTaxa> Lista()
        {
            MovimentoTaxaDAO MovimentoTaxa = new MovimentoTaxaDAO();
            return MovimentoTaxa.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MovimentoTaxa> ListMovimentoTaxa)
        {
            MovimentoTaxaDAO MovimentoTaxa = new MovimentoTaxaDAO();

            try
            {
                foreach(MovimentoTaxa ItemMovimentoTaxa in ListMovimentoTaxa)
                    MovimentoTaxa.Insert(ItemMovimentoTaxa);
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
            MovimentoTaxaDAO MovimentoTaxa = new MovimentoTaxaDAO();
            List<MovimentoTaxa> lista = MovimentoTaxa.Importar(grupo,rotaIni,rotaFim);
            foreach(MovimentoTaxa item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}