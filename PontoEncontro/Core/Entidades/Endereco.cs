using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Endereco
    {


        public Endereco()
        {
        }

        public Endereco(int Enderecoid, string Cep, Cidade Cidadeid)
        {
            this.Enderecoid = Enderecoid;
            this.Cep = Cep;
            this.Cidadeid = Cidadeid;
        }

        public virtual int Enderecoid { get; set; }
        public virtual string Cep { get; set; }
        public virtual Cidade Cidadeid { get; set; }
        public virtual IList<Encontro> EncontroList { get; set; }
        public virtual IList<Encontro> EnderecoidList { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}
