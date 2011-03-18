using System;
using System.Collections.Generic;
using System.Text;

namespace WS_ltMbileData.Data.Model
{
    public class CorreioEletronicoWS
    {
        public CorreioEletronicoWS()
        { }

        public int COD_EMPRT { get; set; }

        public int MATRIC_FUNC { get; set; }

        public int ID_MSG { get; set; }

        public string ASSUNTO { get; set; }

        public DateTime DT_MSG { get; set; }

        public string STATUS_MSG { get; set; }

        public string DESC_MSG { get; set; }

        public string TIPO_MSG { get; set; }

        public string STATUS_REG { get; set; }
    }
}
