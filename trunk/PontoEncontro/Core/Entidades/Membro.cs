using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Membro
    {


        public Membro()
        {
        }

        public Membro(Pessoa Pessoaid, int Membroid, string Membronickname, DateTime Membroultimologin, string Membrosenha)
        {
            this.Pessoaid = Pessoaid;
            this.Membroid = Membroid;
            this.Membronickname = Membronickname;
            this.Membroultimologin = Membroultimologin;
            this.Membrosenha = Membrosenha;
        }

        public virtual Pessoa Pessoaid { get; set; }
        public virtual int Membroid { get; set; }
        public virtual string Membronickname { get; set; }
        public virtual DateTime Membroultimologin { get; set; }
        public virtual string Membrosenha { get; set; }
        public virtual IList<Encontromembro> EncontromembroList { get; set; }
        public virtual IList<Foto> FotoList { get; set; }
        public virtual IList<Membrofavorito> MembrofavoritoList { get; set; }
        public virtual IList<Membroamigo> MembroamigoList { get; set; }
        public virtual IList<Anuncio> AnuncioList { get; set; }
        public virtual IList<Comunidademembro> ComunidademembroList { get; set; }
    }
}
