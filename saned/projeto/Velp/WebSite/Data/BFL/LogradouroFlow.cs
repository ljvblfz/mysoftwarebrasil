using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class LogradouroFlow
    {
        /// <summary>
        /// Lista os logradouros para o PDA
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public static List<LogradouroONP> ListaLogradouro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            LogradouroDAO Logradouro = new LogradouroDAO();
            return Logradouro.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
