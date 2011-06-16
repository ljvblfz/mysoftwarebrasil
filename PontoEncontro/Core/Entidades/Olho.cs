using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Olho
    {


        public Olho()
        {
        }

        public Olho(int Olhosid, string Olhosname)
        {
            this.Olhosid = Olhosid;
            this.Olhosname = Olhosname;
        }

        public virtual int Olhosid { get; set; }
        public virtual string Olhosname { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
