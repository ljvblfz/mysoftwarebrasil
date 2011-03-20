using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
{
    public class FaturaTaxaFlow
    {
        public static List<FaturaTaxaONP> ListaFaturaTaxa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturaTaxaDAO FaturaTaxa = new FaturaTaxaDAO();
            return FaturaTaxa.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
