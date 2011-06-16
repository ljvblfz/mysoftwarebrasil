using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Core.Repository
{
    public class MenuRepository
    {
        public static Object[] ListAll()
        {
            return Core.Model.Menu.FindAll();
        }
    }
}
