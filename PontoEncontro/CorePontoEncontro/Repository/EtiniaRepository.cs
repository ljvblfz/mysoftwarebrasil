using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class EtiniaRepository
    {
        private static Etinia Convert(dynamic menu, int loop)
        {
            Etinia entity = new Etinia();
            entity.etiniaId = menu.etiniaId;
            entity.etiniaName = menu.etiniaName;
            return entity;
        }

        private static CorePontoEncontro.Model.Etinia UnConvert(dynamic menu)
        {
            CorePontoEncontro.Model.Etinia entity = new CorePontoEncontro.Model.Etinia();
            entity.etiniaId = menu.etiniaId;
            entity.etiniaName = menu.etiniaName;
            return entity;
        }

        public static IList<Etinia> ListAll()
        {
            IList<Etinia> list = new List<Etinia>();
            CorePontoEncontro.Model.Etinia[] collection = CorePontoEncontro.Model.Etinia.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }
    }
}
