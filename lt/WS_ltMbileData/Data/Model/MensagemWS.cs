using System;
using System.Collections.Generic;
using System.Text;

namespace WS_ltMbileData.Data.Model
{
    public class MensagemWS
    {
        
        public int ID_MSG { get; set; }

        
        public string DESC_MSG { get; set; }

        
        public int NUM_UC { get; set; }

        public string TIPO_MEDIC { get; set; }
        
        public int MES_ANO_FATUR { get; set; }

        
        public int COD_LOCAL { get; set; }

        
        public int COD_EMPRT { get; set; }

        
        public string STATUS_REG { get; set; }

        
        public int NUM_RAZAO { get; set; }

        
        public string FLAG_SENTIDO { get; set; }

        
        public DateTime DT_MSG { get; set; }
    }
}
