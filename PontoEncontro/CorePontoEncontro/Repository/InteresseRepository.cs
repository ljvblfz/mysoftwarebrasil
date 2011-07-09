using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class InteresseRepository
    {

        private static Interess Convert(dynamic menu, int loop)
        {
            Interess entity = new Interess();
            entity.interresseId = menu.interresseId;
            entity.interresseName = menu.interresseName;
            return entity;
        }

        private static CorePontoEncontro.Model.Interess UnConvert(dynamic menu)
        {
            CorePontoEncontro.Model.Interess entity = new CorePontoEncontro.Model.Interess();
            entity.interresseId = menu.interresseId;
            entity.interresseName = menu.interresseName;
            return entity;
        }


        public static IList<Interess> ListAll()
        {
            IList<Interess> list = new List<Interess>();
            CorePontoEncontro.Model.Interess[] collection = CorePontoEncontro.Model.Interess.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item,0));
            }
            return list;
        }

        public static void Insert(Interess menu)
        {
            CorePontoEncontro.Model.Interess entity = UnConvert(menu);
            entity.Save();
        }

    }
}
