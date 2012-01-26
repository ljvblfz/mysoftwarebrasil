using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Contato
    {


        public Contato()
        {
        }

        public Contato(int Idcontato, string Valorcontato, Perfil Idperfil, Tipocontato Idtipocontato)
        {
            this.Idcontato = Idcontato;
            this.Valorcontato = Valorcontato;
            this.Idperfil = Idperfil;
            this.Idtipocontato = Idtipocontato;
        }

        public virtual int Idcontato { get; set; }
        public virtual string Valorcontato { get; set; }
        public virtual Perfil Idperfil { get; set; }
        public virtual Tipocontato Idtipocontato { get; set; }

    }
}
