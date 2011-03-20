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

	public class ImpostoDiademaFlow
    {

        public static List<ImpostoDiademaONP> ListaImpostoDiadema()
        {
            ImpostoDiademaDAO ImpostoDiadema = new ImpostoDiademaDAO();
            return ImpostoDiadema.Lista();
        }
    }
}