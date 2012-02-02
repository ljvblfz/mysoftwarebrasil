using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Estadocivil
    {


        public Estadocivil()
        {
        }

        public Estadocivil(int Idestadocivil, string Nameestadocivil)
        {
            this.Idestadocivil = Idestadocivil;
            this.Nameestadocivil = Nameestadocivil;
        }

        public virtual int Idestadocivil { get; set; }
        public virtual string Nameestadocivil { get; set; }
        public virtual IList<Perfil> PerfilList { get; set; }
        public virtual IList<Perfil> IdsexoList { get; set; }

    }
}
