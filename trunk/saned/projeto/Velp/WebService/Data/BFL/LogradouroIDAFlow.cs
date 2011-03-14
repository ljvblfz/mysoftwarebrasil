using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.DAL;
using Data.Model;

namespace Data.BFL
{
    public class LogradouroIDAFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<LogradouroIDA> Lista()
        {
            LogradouroIDADAO LogradouroIDA = new LogradouroIDADAO();
            return LogradouroIDA.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<LogradouroIDA> ListLogradouroIDA)
        {
            LogradouroIDADAO LogradouroIDA = new LogradouroIDADAO();

            try
            {
                foreach(LogradouroIDA ItemLogradouroIDA in ListLogradouroIDA)
                    LogradouroIDA.Insert(ItemLogradouroIDA);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os logradouros apartir das ligaçoes
        /// </summary>
        /// <param name="listaLigacao"></param>
        /// <returns></returns>
        public static List<LogradouroIDA> ListaLogradouro(List<Ligacoes> listaLigacao)
        {
            LogradouroIDADAO objLogradouro = new LogradouroIDADAO();
            List<LogradouroIDA> listaLogradouro = new List<LogradouroIDA>();

            // Percorre todos os resultados adicionando na lista de saida
            foreach (Ligacoes itemLigacao in listaLigacao)
            {
                string where = string.Format("Codigo = {0}", itemLigacao.Codigo_Logradouro);

                // Retorna um logradouro
                List<LogradouroIDA> listaLogradouroAUX = objLogradouro.Select(new GDA.Sql.Query(where));
                listaLogradouro.Add(listaLogradouroAUX[0]);
            }
            return listaLogradouro;
        }
    }
}