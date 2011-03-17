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
    public class AgenteFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<Agente> Lista()
        {
            AgenteDAO Agente = new AgenteDAO();
            return Agente.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<Agente> ListAgente)
        {
            AgenteDAO Agente = new AgenteDAO();

            try
            {
                foreach(Agente ItemAgente in ListAgente)
                    Agente.Insert(ItemAgente);
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
            AgenteDAO Agente = new AgenteDAO();
            List<Agente> lista = Agente.Importar(grupo,rotaIni,rotaFim);
            foreach(Agente item in lista)
            {
                result += item.__ToSQL.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "") + ";\n";
            }
            return result;
        }
    }
}