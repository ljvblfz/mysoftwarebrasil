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
    public class FaturaServicoFlow
    {
        public static List<FaturaServicoONP> ListaFaturaServico(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturaServicoDAO FaturaServico = new FaturaServicoDAO();
            return FaturaServico.Lista(grupo,referencia,rotaInicial,rotaFinal);
        }
    }
}
