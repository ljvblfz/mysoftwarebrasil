using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPCad_WS
{
    public class Autenticantion
    {
        public int IdUser { get; set; }
        public string User{ get; set; }
        public string Password { get; set; }
        public string IdPDA { get; set; }
        public string IpPDA { get; set; }        
        public bool parcial{ get; set; }
        //public string syncLast{ get; set; }
    }
}
