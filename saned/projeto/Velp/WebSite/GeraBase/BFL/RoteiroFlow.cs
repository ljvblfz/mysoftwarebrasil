using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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
