using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Permissaorole
    {

		[Serializable]
		public class PK
		{
	        public PK()
	        {
	        }

	        public PK(Role idrole, Permissoe idpermissao)
	        {
	            this.Idrole = idrole;
	            this.Idpermissao = idpermissao;
	        }

	        public virtual Role Idrole { get; set; }
	        public virtual Permissoe Idpermissao { get; set; }


			public override bool Equals(object obj)
			{
			    return base.Equals(obj);
			}

			public override int GetHashCode()
			{
			    return base.GetHashCode();
			}

		}


        public Permissaorole()
        {
        }

        public Permissaorole(PK Pk)
        {
            this.Pk = Pk;
        }

		public virtual PK Pk { get; set; }

    }
}
