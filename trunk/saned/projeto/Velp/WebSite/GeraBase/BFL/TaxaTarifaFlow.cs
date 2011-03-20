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
    public static class TaxaTarifaFlow
    {
        public static List<TaxaTarifaONP> ListaTaxa(int grupo)
        {
            TaxaTarifaDAO taxa = new TaxaTarifaDAO();
            return taxa.Lista(grupo);
        }
    }
}
