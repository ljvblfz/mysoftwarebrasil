using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Role
    {


        public Role()
        {
        }

        public Role(int Idrole, string Namerole)
        {
            this.Idrole = Idrole;
            this.Namerole = Namerole;
        }

        public virtual int Idrole { get; set; }
        public virtual string Namerole { get; set; }
        public virtual IList<Membro> MembroList { get; set; }
        public virtual IList<Membro> IdpessoaList { get; set; }
        public virtual IList<Permissaorole> PermissaoroleList { get; set; }
        public virtual IList<Permissaorole> IdroleList { get; set; }

    }
}
