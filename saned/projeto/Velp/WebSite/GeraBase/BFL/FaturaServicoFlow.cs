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
    public class FaturaServicoFlow
    {
        public static List<FaturaServicoONP> ListaFaturaServico(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturaServicoDAO FaturaServico = new FaturaServicoDAO();
            return FaturaServico.Lista(grupo,referencia,rotaInicial,rotaFinal);
        }
    }
}
