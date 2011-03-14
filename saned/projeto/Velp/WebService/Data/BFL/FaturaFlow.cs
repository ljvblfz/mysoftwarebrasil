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
    public class FaturaFlow
    {
        public static List<FaturaONP> ListaFatura(int grupo,DateTime referencia,int rotaInicial,int rotaFinal,int pagina)
        {
            FaturaDAO Fatura = new FaturaDAO();
            return Fatura.Lista(grupo,referencia,rotaInicial,rotaFinal,pagina);
        }
    }
}
