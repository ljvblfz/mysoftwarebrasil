using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Tipointeresse
    {


        public Tipointeresse()
        {
        }

        public Tipointeresse(int Idtipointeresse, string Nametipointeresse)
        {
            this.Idtipointeresse = Idtipointeresse;
            this.Nametipointeresse = Nametipointeresse;
        }

        public virtual int Idtipointeresse { get; set; }
        public virtual string Nametipointeresse { get; set; }
        public virtual IList<Interesse> InteresseList { get; set; }
        public virtual IList<Interesse> IdtipointeresseList { get; set; }

    }
}
