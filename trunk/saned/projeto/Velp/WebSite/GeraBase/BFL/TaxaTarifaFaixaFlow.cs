using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
{
    public static class TaxaTarifaFaixaFlow
    {
        public static List<TaxaTarifaFaixaONP> ListaTaxaTarifaFaixa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            TaxaTarifaFaixaDAO faixa = new TaxaTarifaFaixaDAO();
            return faixa.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
