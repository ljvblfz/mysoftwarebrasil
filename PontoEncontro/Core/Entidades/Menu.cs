using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Menu
    {


        public Menu()
        {
        }

        public Menu(int Menuid, Menu Menuidpai, string Menuname, int Menuordem, string Menupath)
        {
            this.Menuid = Menuid;
            this.Menuidpai = Menuidpai;
            this.Menuname = Menuname;
            this.Menuordem = Menuordem;
            this.Menupath = Menupath;
        }

        public virtual int Menuid { get; set; }
        public virtual Menu Menuidpai { get; set; }
        public virtual string Menuname { get; set; }
        public virtual int Menuordem { get; set; }
        public virtual string Menupath { get; set; }
        public virtual IList<Menu> MenuList { get; set; }
        public virtual IList<Menurole> MenuroleList { get; set; }

    }
}
