using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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