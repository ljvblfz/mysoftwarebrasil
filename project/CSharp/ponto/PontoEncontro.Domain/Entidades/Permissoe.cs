using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Permissoe
    {


        public Permissoe()
        {
        }

        public Permissoe(int Idpermissao, string Namepermissao, Action Idaction, Controller Idcontroller)
        {
            this.Idpermissao = Idpermissao;
            this.Namepermissao = Namepermissao;
            this.Idaction = Idaction;
            this.Idcontroller = Idcontroller;
        }

        public virtual int Idpermissao { get; set; }
        public virtual string Namepermissao { get; set; }
        public virtual Action Idaction { get; set; }
        public virtual Controller Idcontroller { get; set; }
        public virtual IList<Permissaorole> PermissaoroleList { get; set; }
        public virtual IList<Permissaorole> IdroleList { get; set; }

    }
}
