using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Menurole
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Role roleid, Menu menuid)
	        {
	            this.Roleid = roleid;
	            this.Menuid = menuid;
	        }

	        public virtual Role Roleid { get; set; }
	        public virtual Menu Menuid { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Menurole()
        {
        }

        public Menurole(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
