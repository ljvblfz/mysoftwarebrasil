using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using WS_ltMbileData.Data.DAO;
using GDA;

namespace WS_ltMbileData.Data.BFL
{
    public class LeituraFlow
    {
        public static List<LeituraWS> getLeitura(string Usuario)
        {
            return new LeituraDAO().getLeitura(Usuario);
        }

        public static DateTime GetServerDate()
        {
            return new LeituraDAO().GetServerDate();
        }

        public static void setLeituraConfirmada(string Usuario, string Condicao)
        {
            new LeituraDAO().setLeituraConfirmada(Usuario, Condicao);
        }

        public static void Update(LeituraWS leitura)
        {
            new LeituraDAO().Update(leitura);
        }

        public static void Insert(LeituraWS leitura)
        {
            new LeituraDAO().Insert(leitura);
        }
    }
}
