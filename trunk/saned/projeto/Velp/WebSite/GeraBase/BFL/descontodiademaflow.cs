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

    public class DescontoDiademaFlow
    {

        public static List<DescontoDiademaONP> ListaDescontoDiadema()
        {
            DescontoDiademaDAO DescontoDiadema = new DescontoDiademaDAO();
            return DescontoDiadema.Lista();
        }
    }
}