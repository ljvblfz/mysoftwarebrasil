using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Rolemembro
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Role roleid, int membroid)
	        {
	            this.Roleid = roleid;
	            this.Membroid = membroid;
	        }

	        public virtual Role Roleid { get; set; }
	        public virtual int Membroid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Rolemembro()
        {
        }

        public Rolemembro(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
