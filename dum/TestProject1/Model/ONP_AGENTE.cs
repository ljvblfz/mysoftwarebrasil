using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile;

namespace ConsoleApplication1.Model
{
    public class ONP_AGENTE
    {
        [Primary("cod_agente")]
        public int cod_agente { get; set; }
        public string nom_agente { get; set; }
        public string des_senha { get; set; }
    }
}
