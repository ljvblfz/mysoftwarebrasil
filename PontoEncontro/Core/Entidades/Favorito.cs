using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Favorito
    {


        public Favorito()
        {
        }

        public Favorito(int Favoritosid)
        {
            this.Favoritosid = Favoritosid;
        }

        public virtual int Favoritosid { get; set; }
        public virtual IList<Membrofavorito> MembrofavoritoList { get; set; }
        public virtual IList<Membrofavorito> MembroidList { get; set; }

    }
}
