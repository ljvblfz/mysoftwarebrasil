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
    public class FaturaCategoriaFlow
    {
        public static List<FaturaCategoriaONP> ListaFaturaCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            FaturaCategoriaDAO FaturaCategoria = new FaturaCategoriaDAO();
            return FaturaCategoria.Lista(grupo, referencia,rotaInicial,rotaFinal);
        }
    }
}
