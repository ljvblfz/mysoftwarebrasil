using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class ServicoFaturaFlow
    {

        public static List<ServicoFaturaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            ServicoFaturaDAO ServicoFatura = new ServicoFaturaDAO();
            return ServicoFatura.Lista(grupo, referencia, rotaInicial, rotaFinal);
        }
    }
}