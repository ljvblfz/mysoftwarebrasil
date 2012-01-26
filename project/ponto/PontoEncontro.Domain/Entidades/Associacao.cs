using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Associacao
    {


        public Associacao()
        {
        }

        public Associacao(int Idassociacao, Tipoassociacao Idtipoassociacao, Membro Idmembro, Pessoa Idpessoa)
        {
            this.Idassociacao = Idassociacao;
            this.Idtipoassociacao = Idtipoassociacao;
            this.Idmembro = Idmembro;
            this.Idpessoa = Idpessoa;
        }

        public virtual int Idassociacao { get; set; }
        public virtual Tipoassociacao Idtipoassociacao { get; set; }
        public virtual Membro Idmembro { get; set; }
        public virtual Pessoa Idpessoa { get; set; }
        public virtual IList<Associado> AssociadoList { get; set; }
        public virtual IList<Associado> IdmembroList { get; set; }

    }
}
