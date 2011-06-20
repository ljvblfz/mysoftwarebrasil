using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;

namespace Core.Repository
{
    public class MenuRepository
    {
        public static Object[] ListAll()
        {
            IList<Menu> listMenu = new Core.MenuRepositorios().GetMenu();
            
            return listMenu.ToArray();

        }
    }
}
