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
	public class TipoEntregaFlow
    {

        public static List<TipoEntregaONP> ListaTipoEntrega()
        {
            TipoEntregaDAO TipoEntrega = new TipoEntregaDAO();
            return TipoEntrega.Lista();
        }
    }
}