using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Foto
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Membro membroid, int fotoid)
	        {
	            this.Membroid = membroid;
	            this.Fotoid = fotoid;
	        }

	        public virtual Membro Membroid { get; set; }
	        public virtual int Fotoid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Foto()
        {
        }

        public Foto(PK Pk, string Fotopath)
        {
            this.Pk = Pk;
            this.Fotopath = Fotopath;
        }

		public virtual PK Pk { get; set; }
        public virtual string Fotopath { get; set; }
        public virtual IList<Post> PostList { get; set; }
    }
}
