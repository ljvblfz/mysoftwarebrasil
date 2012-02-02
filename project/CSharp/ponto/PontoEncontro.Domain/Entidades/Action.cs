using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Action
    {


        public Action()
        {
        }

        public Action(int Idaction, string Nameaction)
        {
            this.Idaction = Idaction;
            this.Nameaction = Nameaction;
        }

        public virtual int Idaction { get; set; }
        public virtual string Nameaction { get; set; }
        public virtual IList<Permissoe> PermissoeList { get; set; }
        public virtual IList<Permissoe> IdactionList { get; set; }

    }
}
