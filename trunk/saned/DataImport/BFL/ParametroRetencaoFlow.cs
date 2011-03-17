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
    public class ParametroRetencaoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<ParametroRetencao> Lista()
        {
            ParametroRetencaoDAO ParametroRetencao = new ParametroRetencaoDAO();
            return ParametroRetencao.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<ParametroRetencao> ListParametroRetencao)
        {
            ParametroRetencaoDAO ParametroRetencao = new ParametroRetencaoDAO();

            try
            {
                foreach(ParametroRetencao ItemParametroRetencao in ListParametroRetencao)
                    ParametroRetencao.Insert(ItemParametroRetencao);
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
            ParametroRetencaoDAO ParametroRetencao = new ParametroRetencaoDAO();
            List<ParametroRetencao> lista = ParametroRetencao.Importar(grupo,rotaIni,rotaFim);
            foreach(ParametroRetencao item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}