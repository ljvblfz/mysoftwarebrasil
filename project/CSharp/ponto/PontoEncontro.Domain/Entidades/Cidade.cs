using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Cidade
    {


        public Cidade()
        {
        }

        public Cidade(int Idcidade, string Namecidade, Estado Idestado)
        {
            this.Idcidade = Idcidade;
            this.Namecidade = Namecidade;
            this.Idestado = Idestado;
        }

        public virtual int Idcidade { get; set; }
        public virtual string Namecidade { get; set; }
        public virtual Estado Idestado { get; set; }
        public virtual IList<Endereco> EnderecoList { get; set; }
        public virtual IList<Endereco> IdcidadeList { get; set; }

    }
}
