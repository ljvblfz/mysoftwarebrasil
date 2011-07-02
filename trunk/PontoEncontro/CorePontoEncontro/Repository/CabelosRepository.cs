using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class CabeloRepository
    {
        private static Cabelo Convert(dynamic menu, int loop)
        {
            Cabelo entity = new Cabelo();
            entity.cabelosId = menu.cabelosId;
            entity.cabelosName = menu.cabelosName;
            return entity;
        }

        private static CorePontoEncontro.Model.Cabelo UnConvert(dynamic menu)
        {
            CorePontoEncontro.Model.Cabelo entity = new CorePontoEncontro.Model.Cabelo();
            entity.cabelosId = menu.cabelosId;
            entity.cabelosName = menu.cabelosName;
            return entity;
        }

        public static IList<Cabelo> ListAll()
        {
            IList<Cabelo> list = new List<Cabelo>();
            CorePontoEncontro.Model.Cabelo[] collection = CorePontoEncontro.Model.Cabelo.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }
    }
}
