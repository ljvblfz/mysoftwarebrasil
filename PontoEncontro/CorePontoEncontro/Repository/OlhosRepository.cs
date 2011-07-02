using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class OlhosRepository
    {
        private static Olho Convert(dynamic menu, int loop)
        {
            Olho entity = new Olho();
            entity.olhosId = menu.olhosId;
            entity.olhosName = menu.olhosName;
            return entity;
        }

        private static CorePontoEncontro.Model.Olho UnConvert(dynamic menu)
        {
            CorePontoEncontro.Model.Olho entity = new CorePontoEncontro.Model.Olho();
            entity.olhosId = menu.olhosId;
            entity.olhosName = menu.olhosName;
            return entity;
        }

        public static IList<Olho> ListAll()
        {
            IList<Olho> list = new List<Olho>();
            CorePontoEncontro.Model.Olho[] collection = CorePontoEncontro.Model.Olho.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }
    }
}
