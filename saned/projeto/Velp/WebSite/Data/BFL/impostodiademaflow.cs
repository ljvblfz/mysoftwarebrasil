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

	public class ImpostoDiademaFlow
    {

        public static List<ImpostoDiademaONP> ListaImpostoDiadema()
        {
            ImpostoDiademaDAO ImpostoDiadema = new ImpostoDiademaDAO();
            return ImpostoDiadema.Lista();
        }
    }
}