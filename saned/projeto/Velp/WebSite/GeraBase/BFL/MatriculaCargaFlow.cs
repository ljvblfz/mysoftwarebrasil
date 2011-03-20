using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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
