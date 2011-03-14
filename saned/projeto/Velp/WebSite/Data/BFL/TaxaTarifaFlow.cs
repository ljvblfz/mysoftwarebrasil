using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public static class TaxaTarifaFlow
    {
        public static List<TaxaTarifaONP> ListaTaxa(int grupo)
        {
            TaxaTarifaDAO taxa = new TaxaTarifaDAO();
            return taxa.Lista(grupo);
        }
    }
}
