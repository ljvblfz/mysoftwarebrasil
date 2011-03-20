using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
{
    public class MatriculaFlow
    {
        public static List<MatriculaONP> ListaMatricula(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MatriculaDAO Matricula = new MatriculaDAO();
            return Matricula.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
