using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Associado
    {


        public Associado()
        {
        }

        public Associado(int Idassociado, Membro Idmembro, Associacao Idassociacao)
        {
            this.Idassociado = Idassociado;
            this.Idmembro = Idmembro;
            this.Idassociacao = Idassociacao;
        }

        public virtual int Idassociado { get; set; }
        public virtual Membro Idmembro { get; set; }
        public virtual Associacao Idassociacao { get; set; }

    }
}
