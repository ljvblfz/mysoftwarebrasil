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

	public class ParametroFlow
    {

        public static List<ParametroONP> ListaParametro()
        {
            ParametroDAO Parametro = new ParametroDAO();
            return Parametro.Lista();
        }
    }
}