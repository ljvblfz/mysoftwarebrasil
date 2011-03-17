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
    public class LocalizacaoHidrometroFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<LocalizacaoHidrometro> Lista()
        {
            LocalizacaoHidrometroDAO LocalizacaoHidrometro = new LocalizacaoHidrometroDAO();
            return LocalizacaoHidrometro.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<LocalizacaoHidrometro> ListLocalizacaoHidrometro)
        {
            LocalizacaoHidrometroDAO LocalizacaoHidrometro = new LocalizacaoHidrometroDAO();

            try
            {
                foreach(LocalizacaoHidrometro ItemLocalizacaoHidrometro in ListLocalizacaoHidrometro)
                    LocalizacaoHidrometro.Insert(ItemLocalizacaoHidrometro);
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
            LocalizacaoHidrometroDAO LocalizacaoHidrometro = new LocalizacaoHidrometroDAO();
            List<LocalizacaoHidrometro> lista = LocalizacaoHidrometro.Importar(grupo,rotaIni,rotaFim);
            foreach(LocalizacaoHidrometro item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}