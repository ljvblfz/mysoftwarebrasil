using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class HidrometroFlow
    {
        public static List<HidrometroONP> ListaHidrometro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            HidrometroDAO Hidrometro = new HidrometroDAO();
            List<HidrometroONP> ListaHidrometro = Hidrometro.Lista(grupo, referencia, rotaInicial, rotaFinal);

            return ListaHidrometro;
        }
    }
}
