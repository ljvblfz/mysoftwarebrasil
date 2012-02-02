using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Cabelo
    {


        public Cabelo()
        {
        }

        public Cabelo(int Idcabelo, string Namecabelo)
        {
            this.Idcabelo = Idcabelo;
            this.Namecabelo = Namecabelo;
        }

        public virtual int Idcabelo { get; set; }
        public virtual string Namecabelo { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
