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
    public static class MovimentoCategoriaFlow
    {

        public static List<MovimentoCategoriaONP> ListaMovimentoCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MovimentoCategoriaDAO MovimentoCategoria = new MovimentoCategoriaDAO();
            return MovimentoCategoria.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
