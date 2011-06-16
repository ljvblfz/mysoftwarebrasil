using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Interesse
    {


        public Interesse()
        {
        }

        public Interesse(int Interresseid, string Interressename)
        {
            this.Interresseid = Interresseid;
            this.Interressename = Interressename;
        }

        public virtual int Interresseid { get; set; }
        public virtual string Interressename { get; set; }
        public virtual IList<Inretessepessoa> InretessepessoaList { get; set; }
        public virtual IList<Inretessepessoa> PessoaidList { get; set; }

    }
}
