using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Sexo
    {


        public Sexo()
        {
        }

        public Sexo(int Idsexo, string Namesexo)
        {
            this.Idsexo = Idsexo;
            this.Namesexo = Namesexo;
        }

        public virtual int Idsexo { get; set; }
        public virtual string Namesexo { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
