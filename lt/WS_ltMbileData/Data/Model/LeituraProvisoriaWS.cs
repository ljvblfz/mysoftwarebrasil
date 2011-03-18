using System;
using System.Collections.Generic;
using System.Text;

namespace WS_ltMbileData.Data.Model
{
    public class LeituraProvisoriaWS
    {
        
        public int MES_ANO_FATUR { get; set; }
               
        public int COD_LOCAL { get; set; }
               
        public int COD_EMPRT { get; set; }
               
        public string TIPO_MEDIC { get; set; }
              
        public string NUM_MEDIDR { get; set; }
           
        public int MATRIC_FUNC { get; set; }
           
        public int NUM_UC_REF { get; set; }
        
        public int NUM_RAZAO { get; set; }
        
        public int IRREGL_ATUAL1 { get; set; }

        public int IRREGL_ATUAL2 { get; set; }
        
        public int IRREGL_ATUAL3 { get; set; }

        public DateTime DATA_VISITA { get; set; }
        
        public string HORA_VISITA { get; set; }

        public int LEITUR_VISITA { get; set; }
        
        public string COORD_X { get; set; }

        public string COORD_Y { get; set; }
              
        public string STATUS_REG { get; set; }
        
        public string COMPL_ATUAL1 { get; set; }

        public string COMPL_ATUAL2 { get; set; }
        
        public string COMPL_ATUAL3 { get; set; }

        public string OBSERVACAO { get; set; }
    }
}
