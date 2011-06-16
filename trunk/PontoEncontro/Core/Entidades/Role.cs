using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Role
    {


        public Role()
        {
        }

        public Role(int Roleid, string Rolename)
        {
            this.Roleid = Roleid;
            this.Rolename = Rolename;
        }

        public virtual int Roleid { get; set; }
        public virtual string Rolename { get; set; }
        public virtual IList<Rolemembro> RolemembroList { get; set; }
        public virtual IList<Menurole> MenuroleList { get; set; }

    }
}
