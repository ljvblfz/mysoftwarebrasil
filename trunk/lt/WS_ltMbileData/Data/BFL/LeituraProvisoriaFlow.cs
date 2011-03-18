using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using WS_ltMbileData.Data.DAO;

namespace WS_ltMbileData.Data.BFL
{
    public class LeituraProvisoriaFlow
    {
        public static void Insert(LeituraProvisoriaWS LeituraProvisoria)
        {
            new LeituraProvisoriaDAO().Insert(LeituraProvisoria);
        }
    }
}
