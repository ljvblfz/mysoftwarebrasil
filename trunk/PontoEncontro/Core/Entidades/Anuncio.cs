using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Anuncio
    {


        public Anuncio()
        {
        }

        public Anuncio(int Anuncioid, double Anunciovalorhora, string Anucioproficional, string Anunciotitulo, string Anunciotexto, Membro Membroid)
        {
            this.Anuncioid = Anuncioid;
            this.Anunciovalorhora = Anunciovalorhora;
            this.Anucioproficional = Anucioproficional;
            this.Anunciotitulo = Anunciotitulo;
            this.Anunciotexto = Anunciotexto;
            this.Membroid = Membroid;
        }

        public virtual int Anuncioid { get; set; }
        public virtual double Anunciovalorhora { get; set; }
        public virtual string Anucioproficional { get; set; }
        public virtual string Anunciotitulo { get; set; }
        public virtual string Anunciotexto { get; set; }
        public virtual Membro Membroid { get; set; }

    }
}
