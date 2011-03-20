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

	public class OcorrenciaTFlow
    {

        public static List<OcorrenciaTONP> ListaOcorrencia()
        {
            OcorrenciaTDAO Ocorrencia = new OcorrenciaTDAO();
            return Ocorrencia.Lista();
        }
    }
}