using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.DAO;
using WS_ltMbileData.Data.Model;

namespace WS_ltMbileData.Data.BFL
{
    public class FotoFlow
    {
        public static List<FotoWS> getFoto(string Usuario)
        {
            return new FotoDAO().getFoto(Usuario);
        }

        public static void Insert(FotoWS foto)
        {
            new FotoDAO().Insert(foto);
        }

        public static int getLastIdFoto()
        {
            return new FotoDAO().getLastIdFoto();
        }
    }
}
