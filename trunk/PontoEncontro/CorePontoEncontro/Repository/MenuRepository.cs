using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class MenuRepository
    {

        private static Menu Convert(CorePontoEncontro.Model.Menu menu)
        {
            Menu entity = new Menu();
            entity.MenuId = menu.MenuId;
            entity.MenuIdPai = (menu.MenuIdPai == null ? null : Convert(menu.MenuIdPai));
            entity.MenuName = menu.MenuName;
            entity.MenuOrdem = menu.MenuOrdem;
            entity.MenuPath = menu.MenuPath;
            return entity;
        }

        private static CorePontoEncontro.Model.Menu UnConvert(Menu menu)
        {
            CorePontoEncontro.Model.Menu entity = new CorePontoEncontro.Model.Menu();
            entity.MenuId = menu.MenuId;
            entity.MenuIdPai = (menu.MenuIdPai == null ? null : UnConvert(menu.MenuIdPai));
            entity.MenuName = menu.MenuName;
            entity.MenuOrdem = menu.MenuOrdem;
            entity.MenuPath = menu.MenuPath;
            return entity;
        }


        public static IList<Menu> ListAll()
        {
            IList<Menu> list = new List<Menu>();
            CorePontoEncontro.Model.Menu[] collection = CorePontoEncontro.Model.Menu.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static void Insert(Menu menu)
        {
            CorePontoEncontro.Model.Menu entity = UnConvert(menu);
            entity.Save();
        }

    }
}
