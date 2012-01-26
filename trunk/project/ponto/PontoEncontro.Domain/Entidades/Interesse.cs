using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Interesse
    {


        public Interesse()
        {
        }

        public Interesse(int Idinteresse, string Descricao, Tipointeresse Idtipointeresse, Perfil Idperfil)
        {
            this.Idinteresse = Idinteresse;
            this.Descricao = Descricao;
            this.Idtipointeresse = Idtipointeresse;
            this.Idperfil = Idperfil;
        }

        public virtual int Idinteresse { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Tipointeresse Idtipointeresse { get; set; }
        public virtual Perfil Idperfil { get; set; }

    }
}
