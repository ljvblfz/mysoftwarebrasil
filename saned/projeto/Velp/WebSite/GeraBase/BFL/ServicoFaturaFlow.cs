using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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