using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using WS_ltMbileData.Data.DAO;

namespace WS_ltMbileData.Data.BFL
{
    public class CorreioEletronicoFlow
    {
        public static List<CorreioEletronicoWS> getCorreioEletronico(string strUsuario)
        {
            return new CorreioEletronicoDAO().getCorreioEletronico(strUsuario);
        }

        public static void Insert(CorreioEletronicoWS correio)
        {
           new CorreioEletronicoDAO().Insert(correio);
        }

        public static void setCorreioEletronicoConfirmado(string Usuario, string Condicao)
        {
            new CorreioEletronicoDAO().setCorreioEletronicoConfirmado(Usuario, Condicao);
        }
    }
}
