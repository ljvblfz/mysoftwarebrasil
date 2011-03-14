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
    public static class MovimentoTaxaFlow
    {

        public static List<MovimentoTaxaONP> ListaMovimentoTaxa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MovimentoTaxaDAO MovimentoTaxa = new MovimentoTaxaDAO();
            return MovimentoTaxa.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}

