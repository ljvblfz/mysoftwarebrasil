using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Etinia
    {


        public Etinia()
        {
        }

        public Etinia(int Etiniaid, string Etinianame)
        {
            this.Etiniaid = Etiniaid;
            this.Etinianame = Etinianame;
        }

        public virtual int Etiniaid { get; set; }
        public virtual string Etinianame { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
