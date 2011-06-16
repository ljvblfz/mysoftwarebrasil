using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Inretessepessoa
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Pessoa pessoaid, Interesse interresseid)
	        {
	            this.Pessoaid = pessoaid;
	            this.Interresseid = interresseid;
	        }

	        public virtual Pessoa Pessoaid { get; set; }
	        public virtual Interesse Interresseid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Inretessepessoa()
        {
        }

        public Inretessepessoa(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
