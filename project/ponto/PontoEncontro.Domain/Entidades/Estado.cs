using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Estado
    {


        public Estado()
        {
        }

        public Estado(int Idestado, string Nameestado, string Siglaestado)
        {
            this.Idestado = Idestado;
            this.Nameestado = Nameestado;
            this.Siglaestado = Siglaestado;
        }

        public virtual int Idestado { get; set; }
        public virtual string Nameestado { get; set; }
        public virtual string Siglaestado { get; set; }
        public virtual IList<Cidade> CidadeList { get; set; }
        public virtual IList<Cidade> IdestadoList { get; set; }

    }
}
