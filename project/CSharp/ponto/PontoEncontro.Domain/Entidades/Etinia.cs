using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Etinia
    {


        public Etinia()
        {
        }

        public Etinia(int Idetinia, string Nameetinia)
        {
            this.Idetinia = Idetinia;
            this.Nameetinia = Nameetinia;
        }

        public virtual int Idetinia { get; set; }
        public virtual string Nameetinia { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
