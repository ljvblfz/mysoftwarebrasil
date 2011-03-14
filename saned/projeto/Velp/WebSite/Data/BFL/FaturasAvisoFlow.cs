using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class FaturasAvisoFlow
    {

        public static List<FaturasAvisoONP> ListaFaturasAviso(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturasAvisoDAO FaturasAviso = new FaturasAvisoDAO();
            return FaturasAviso.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}