using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Membroamigo
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Membro membroid, Amigo amigoid)
	        {
	            this.Membroid = membroid;
	            this.Amigoid = amigoid;
	        }

	        public virtual Membro Membroid { get; set; }
	        public virtual Amigo Amigoid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Membroamigo()
        {
        }

        public Membroamigo(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
