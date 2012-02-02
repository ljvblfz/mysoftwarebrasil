using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Endereco
    {


        public Endereco()
        {
        }

        public Endereco(int Idendereco, string Cep, Cidade Idcidade, Bairro Idbairro)
        {
            this.Idendereco = Idendereco;
            this.Cep = Cep;
            this.Idcidade = Idcidade;
            this.Idbairro = Idbairro;
        }

        public virtual int Idendereco { get; set; }
        public virtual string Cep { get; set; }
        public virtual Cidade Idcidade { get; set; }
        public virtual Bairro Idbairro { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
