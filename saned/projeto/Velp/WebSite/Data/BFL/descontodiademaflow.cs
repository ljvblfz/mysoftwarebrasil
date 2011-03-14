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

    public class DescontoDiademaFlow
    {

        public static List<DescontoDiademaONP> ListaDescontoDiadema()
        {
            DescontoDiademaDAO DescontoDiadema = new DescontoDiademaDAO();
            return DescontoDiadema.Lista();
        }
    }
}