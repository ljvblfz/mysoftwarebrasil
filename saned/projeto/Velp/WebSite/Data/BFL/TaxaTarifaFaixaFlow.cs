using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
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
