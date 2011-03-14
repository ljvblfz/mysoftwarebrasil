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
    public class FaturaCategoriaFlow
    {
        public static List<FaturaCategoriaONP> ListaFaturaCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturaCategoriaDAO FaturaCategoria = new FaturaCategoriaDAO();
            return FaturaCategoria.Lista(grupo, referencia,rotaInicial,rotaFinal);
        }
    }
}
