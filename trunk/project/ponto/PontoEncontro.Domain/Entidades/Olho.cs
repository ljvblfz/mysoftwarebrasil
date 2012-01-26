using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Olho
    {


        public Olho()
        {
        }

        public Olho(int Idolho, string Nameolho)
        {
            this.Idolho = Idolho;
            this.Nameolho = Nameolho;
        }

        public virtual int Idolho { get; set; }
        public virtual string Nameolho { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
