using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Membrofavorito
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Membro membroid, Favorito favoritosid)
	        {
	            this.Membroid = membroid;
	            this.Favoritosid = favoritosid;
	        }

	        public virtual Membro Membroid { get; set; }
	        public virtual Favorito Favoritosid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Membrofavorito()
        {
        }

        public Membrofavorito(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
