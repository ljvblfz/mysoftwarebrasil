using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Estadocivil
    {


        public Estadocivil()
        {
        }

        public Estadocivil(int Estadocivilid, string Estadocivilname)
        {
            this.Estadocivilid = Estadocivilid;
            this.Estadocivilname = Estadocivilname;
        }

        public virtual int Estadocivilid { get; set; }
        public virtual string Estadocivilname { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
