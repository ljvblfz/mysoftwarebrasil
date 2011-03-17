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
    public class RoteiroFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Roteiro> Lista()
        {
            RoteiroDAO Roteiro = new RoteiroDAO();
            return Roteiro.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Roteiro> ListRoteiro)
        {
            RoteiroDAO Roteiro = new RoteiroDAO();

            try
            {
                foreach(Roteiro ItemRoteiro in ListRoteiro)
                    Roteiro.Insert(ItemRoteiro);
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
            RoteiroDAO Roteiro = new RoteiroDAO();
            List<Roteiro> lista = Roteiro.Importar(grupo,rotaIni,rotaFim);
            foreach(Roteiro item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}