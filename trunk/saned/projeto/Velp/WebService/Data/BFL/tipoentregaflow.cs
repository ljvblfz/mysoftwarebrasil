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
	public class TipoEntregaFlow
    {

        public static List<TipoEntregaONP> ListaTipoEntrega()
        {
            TipoEntregaDAO TipoEntrega = new TipoEntregaDAO();
            return TipoEntrega.Lista();
        }
    }
}