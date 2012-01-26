using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Pessoa
    {


        public Pessoa()
        {
        }

        public Pessoa(int Idpessoa, Perfil Idperfil, string Nomepessoa, string EMailpessoa, DateTime Nascimentopessoa)
        {
            this.Idpessoa = Idpessoa;
            this.Idperfil = Idperfil;
            this.Nomepessoa = Nomepessoa;
            this.EMailpessoa = EMailpessoa;
            this.Nascimentopessoa = Nascimentopessoa;
        }

        public virtual int Idpessoa { get; set; }
        public virtual Perfil Idperfil { get; set; }
        public virtual string Nomepessoa { get; set; }
        public virtual string EMailpessoa { get; set; }
        public virtual DateTime Nascimentopessoa { get; set; }
        public virtual IList<Membro> MembroList { get; set; }
        public virtual IList<Membro> IdpessoaList { get; set; }
        public virtual IList<Associacao> AssociacaoList { get; set; }
        public virtual IList<Associacao> IdtipoassociacaoList { get; set; }

    }
}
