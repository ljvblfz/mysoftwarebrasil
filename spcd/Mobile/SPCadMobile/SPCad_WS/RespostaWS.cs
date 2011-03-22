using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPCad_WS
{
    public class RespostaWS
    {
        public int errorCode{ get; set; }
        public String errorMsg { get; set; }
        public long idRecord { get; set; }
        public String aux { get; set; }
    }
}