using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class MatriculaCargaFlow
    {
        public static List<MatriculaCargaONP> ListaMatriculaCarga(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MatriculaCargaDAO MatriculaCarga = new MatriculaCargaDAO();
            return MatriculaCarga.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
