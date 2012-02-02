using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Tipocontato
    {


        public Tipocontato()
        {
        }

        public Tipocontato(int Idtipocontato, string Nametipocontato)
        {
            this.Idtipocontato = Idtipocontato;
            this.Nametipocontato = Nametipocontato;
        }

        public virtual int Idtipocontato { get; set; }
        public virtual string Nametipocontato { get; set; }
        public virtual IList<Contato> ContatoList { get; set; }
        public virtual IList<Contato> IdperfilList { get; set; }

    }
}
