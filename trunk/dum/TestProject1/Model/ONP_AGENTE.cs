using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile;

namespace ConsoleApplication1.Model
{
    [Primary("cod_agente")]
    public class ONP_AGENTE
    {
        public int cod_agente { get; set; }
        public string nom_agente { get; set; }
        public string des_senha { get; set; }
    }
}
