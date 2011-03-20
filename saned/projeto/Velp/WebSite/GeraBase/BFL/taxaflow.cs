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

	public class TaxaFlow
    {

        public static List<TaxaONP> ListaTaxa()
        {
            TaxaDAO Taxa = new TaxaDAO();
            return Taxa.Lista();
        }
    }
}