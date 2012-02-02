using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Membro
    {


        public Membro()
        {
        }

        public Membro(int Idmembro, string Loginmembro, string Senhamembro, Pessoa Idpessoa, Role Idrole)
        {
            this.Idmembro = Idmembro;
            this.Loginmembro = Loginmembro;
            this.Senhamembro = Senhamembro;
            this.Idpessoa = Idpessoa;
            this.Idrole = Idrole;
        }

        public virtual int Idmembro { get; set; }
        public virtual string Loginmembro { get; set; }
        public virtual string Senhamembro { get; set; }
        public virtual Pessoa Idpessoa { get; set; }
        public virtual Role Idrole { get; set; }
        public virtual IList<Associado> AssociadoList { get; set; }
        public virtual IList<Associado> IdmembroList { get; set; }
        public virtual IList<Associacao> AssociacaoList { get; set; }
        public virtual IList<Associacao> IdtipoassociacaoList { get; set; }

    }
}
