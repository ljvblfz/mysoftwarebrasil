using System;
using System.Collections.Generic;
using System.Text;

namespace WS_ltMbileData.Data.Model
{
    public class FotoWS
    {
        
        public int ID_FOTO { get; set; }
                
        public int MES_ANO_FATUR { get; set; }
                
        public string TIPO_MEDIC { get; set; }
                
        public int COD_LOCAL { get; set; }
                
        public int NUM_UC { get; set; }
                
        public int COD_EMPRT { get; set; }
                
        public int NUM_RAZAO { get; set; }
                
        public string NUM_MEDIDR { get; set; }
                
        public int NUM_SEQ_FOTO { get; set; }
                
        public string DESC_FOTO { get; set; }
                
        public string USUAR_ATLZ { get; set; }
                
        public DateTime DATA_ATLZ { get; set; }
                
        public string HORA_ATLZ { get; set; }
                
        public string CORD_X { get; set; }
                
        public string CORD_Y { get; set; }
                
        public string STATUS_REG { get; set; }

        private byte[] m_Buffer;

        public byte[] Buffer
        {
            get { return m_Buffer; }
            set { m_Buffer = value; }
        }
    }
}
