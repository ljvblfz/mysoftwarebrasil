using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Tipoassociacao
    {


        public Tipoassociacao()
        {
        }

        public Tipoassociacao(int Idtipoassociacao, string Nometipoassociacao)
        {
            this.Idtipoassociacao = Idtipoassociacao;
            this.Nometipoassociacao = Nometipoassociacao;
        }

        public virtual int Idtipoassociacao { get; set; }
        public virtual string Nometipoassociacao { get; set; }
        public virtual IList<Associacao> AssociacaoList { get; set; }
        public virtual IList<Associacao> IdtipoassociacaoList { get; set; }

    }
}
