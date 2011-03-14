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

	public class OcorrenciaTFlow
    {

        public static List<OcorrenciaTONP> ListaOcorrencia()
        {
            OcorrenciaTDAO Ocorrencia = new OcorrenciaTDAO();
            return Ocorrencia.Lista();
        }
    }
}