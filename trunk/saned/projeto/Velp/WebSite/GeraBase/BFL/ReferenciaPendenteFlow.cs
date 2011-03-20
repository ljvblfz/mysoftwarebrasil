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

    public class ReferenciaPendenteFlow
    {

        public static List<ReferenciaPendenteONP> ListaReferenciaPendente(int grupo, int rotaInicial, int rotaFinal)
        {
            ReferenciaPendenteDAO ReferenciaPendente = new ReferenciaPendenteDAO();
            return ReferenciaPendente.Lista( grupo,  rotaInicial,  rotaFinal);
        }
    }
}