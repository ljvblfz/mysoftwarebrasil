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
    public class GrupoFaturaFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<GrupoFatura> Lista()
        {
            GrupoFaturaDAO GrupoFatura = new GrupoFaturaDAO();
            return GrupoFatura.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<GrupoFatura> ListGrupoFatura)
        {
            GrupoFaturaDAO GrupoFatura = new GrupoFaturaDAO();

            try
            {
                foreach(GrupoFatura ItemGrupoFatura in ListGrupoFatura)
                    GrupoFatura.Insert(ItemGrupoFatura);
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
            GrupoFaturaDAO GrupoFatura = new GrupoFaturaDAO();
            List<GrupoFatura> lista = GrupoFatura.Importar(grupo,rotaIni,rotaFim);
            foreach(GrupoFatura item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}