using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Controller
    {


        public Controller()
        {
        }

        public Controller(int Idcontroller, string Namecontroller)
        {
            this.Idcontroller = Idcontroller;
            this.Namecontroller = Namecontroller;
        }

        public virtual int Idcontroller { get; set; }
        public virtual string Namecontroller { get; set; }
        public virtual IList<Permissoe> PermissoeList { get; set; }
        public virtual IList<Permissoe> IdactionList { get; set; }

    }
}
