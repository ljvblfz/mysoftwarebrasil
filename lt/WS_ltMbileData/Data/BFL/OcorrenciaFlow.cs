using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.DAO;
using WS_ltMbileData.Data.Model;

namespace WS_ltMbileData.Data.BFL
{
    public class OcorrenciaFlow
    {
        public static List<OcorrenciaWS> getOcorrencia()
        {
            return new OcorrenciaDAO().getOcorrencia();
        }
    }
}
