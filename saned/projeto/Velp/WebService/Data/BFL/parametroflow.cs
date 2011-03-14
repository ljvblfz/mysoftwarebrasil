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

	public class ParametroFlow
    {

        public static List<ParametroONP> ListaParametro()
        {
            ParametroDAO Parametro = new ParametroDAO();
            return Parametro.Lista();
        }
    }
}