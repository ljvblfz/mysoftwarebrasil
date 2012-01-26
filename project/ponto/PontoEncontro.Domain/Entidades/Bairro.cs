using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Bairro
    {


        public Bairro()
        {
        }

        public Bairro(int Idbairro, string Nomebairro)
        {
            this.Idbairro = Idbairro;
            this.Nomebairro = Nomebairro;
        }

        public virtual int Idbairro { get; set; }
        public virtual string Nomebairro { get; set; }
        public virtual IList<Endereco> EnderecoList { get; set; }
        public virtual IList<Endereco> IdcidadeList { get; set; }

    }
}
