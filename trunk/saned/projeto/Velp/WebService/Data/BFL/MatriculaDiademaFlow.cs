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
    public class MatriculaDiademaFlow
    {
        public static List<MatriculaDiademaONP> ListaMatriculaDiadema(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MatriculaDiademaDAO matriculaDiadema = new MatriculaDiademaDAO();
            return matriculaDiadema.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}
