using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
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
