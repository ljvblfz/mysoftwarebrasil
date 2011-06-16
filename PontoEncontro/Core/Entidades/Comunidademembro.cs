using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Comunidademembro
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Comunidade comunidadeid, Membro membroid)
	        {
	            this.Comunidadeid = comunidadeid;
	            this.Membroid = membroid;
	        }

	        public virtual Comunidade Comunidadeid { get; set; }
	        public virtual Membro Membroid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Comunidademembro()
        {
        }

        public Comunidademembro(PK Pk, string Comunidademembromediador)
        {
            this.Pk = Pk;
            this.Comunidademembromediador = Comunidademembromediador;
        }

		public virtual PK Pk { get; set; }
        public virtual string Comunidademembromediador { get; set; }

    }
}
