using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class RoteiroFlow
    {
        public static List<RoteiroONP> ListaRoteiro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            RoteiroDAO agente = new RoteiroDAO();
            return agente.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
