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
    public static class MovimentoCategoriaFlow
    {

        public static List<MovimentoCategoriaONP> ListaMovimentoCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MovimentoCategoriaDAO MovimentoCategoria = new MovimentoCategoriaDAO();
            return MovimentoCategoria.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
