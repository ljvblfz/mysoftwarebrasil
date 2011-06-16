using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Pai
    {


        public Pai()
        {
        }

        public Pai(int Paisid, string Paisname)
        {
            this.Paisid = Paisid;
            this.Paisname = Paisname;
        }

        public virtual int Paisid { get; set; }
        public virtual string Paisname { get; set; }
        public virtual IList<Estado> EstadoList { get; set; }
        public virtual IList<Estado> PaisidList { get; set; }

    }
}
