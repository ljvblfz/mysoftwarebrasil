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
    public class HidrometroFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Hidrometro> Lista()
        {
            HidrometroDAO Hidrometro = new HidrometroDAO();
            return Hidrometro.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Hidrometro> ListHidrometro)
        {
            HidrometroDAO Hidrometro = new HidrometroDAO();

            try
            {
                foreach(Hidrometro ItemHidrometro in ListHidrometro)
                    Hidrometro.Insert(ItemHidrometro);
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
            HidrometroDAO Hidrometro = new HidrometroDAO();
            List<Hidrometro> lista = Hidrometro.Importar(grupo, rotaIni, rotaFim, DateTime.Now);
            foreach(Hidrometro item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}