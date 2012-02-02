using System;
using System.Collections.Generic;

namespace PontoEncontro.Domain
{
    [Serializable]
    public class Menu
    {


        public Menu()
        {
        }

        public Menu(int Idmenu, Menu Menuidpai, string Namemenu, int Ordemmenu, string Pathmenu)
        {
            this.Idmenu = Idmenu;
            this.Menuidpai = Menuidpai;
            this.Namemenu = Namemenu;
            this.Ordemmenu = Ordemmenu;
            this.Pathmenu = Pathmenu;
        }

        public virtual int Idmenu { get; set; }
        public virtual Menu Menuidpai { get; set; }
        public virtual string Namemenu { get; set; }
        public virtual int Ordemmenu { get; set; }
        public virtual string Pathmenu { get; set; }
        public virtual IList<Menu> MenuList { get; set; }
        public virtual IList<Menu> MenuidpaiList { get; set; }

    }
}
