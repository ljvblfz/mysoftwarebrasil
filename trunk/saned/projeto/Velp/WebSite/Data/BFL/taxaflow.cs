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

	public class TaxaFlow
    {

        public static List<TaxaONP> ListaTaxa()
        {
            TaxaDAO Taxa = new TaxaDAO();
            return Taxa.Lista();
        }
    }
}