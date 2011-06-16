using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Sexo
    {


        public Sexo()
        {
        }

        public Sexo(int Sexoid, string Sexoname)
        {
            this.Sexoid = Sexoid;
            this.Sexoname = Sexoname;
        }

        public virtual int Sexoid { get; set; }
        public virtual string Sexoname { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
