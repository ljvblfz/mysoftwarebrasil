using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Cabelo
    {


        public Cabelo()
        {
        }

        public Cabelo(int Cabelosid, string Cabelosname)
        {
            this.Cabelosid = Cabelosid;
            this.Cabelosname = Cabelosname;
        }

        public virtual int Cabelosid { get; set; }
        public virtual string Cabelosname { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
