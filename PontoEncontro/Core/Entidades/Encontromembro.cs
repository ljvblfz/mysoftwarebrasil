using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Encontromembro
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Membro membroid, Encontro encontroid)
	        {
	            this.Membroid = membroid;
	            this.Encontroid = encontroid;
	        }

	        public virtual Membro Membroid { get; set; }
	        public virtual Encontro Encontroid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Encontromembro()
        {
        }

        public Encontromembro(PK Pk, string Encontromembrocriador)
        {
            this.Pk = Pk;
            this.Encontromembrocriador = Encontromembrocriador;
        }

		public virtual PK Pk { get; set; }
        public virtual string Encontromembrocriador { get; set; }

    }
}
