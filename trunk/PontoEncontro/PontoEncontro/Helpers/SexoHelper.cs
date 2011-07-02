using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class SexoHelper
    {
        private static Sexo Convert(dynamic menu, int loop)
        {
            Sexo entity = new Sexo();
            entity.sexoId = menu.sexoId;
            entity.sexoName = menu.sexoName;
            return entity;
        }

        //private static CorePontoEncontro.Model.Sexo UnConvert(dynamic menu)
        //{
        //    CorePontoEncontro.Model.Sexo entity = new CorePontoEncontro.Model.Sexo();
        //    entity.sexoId = menu.sexoId;
        //    entity.sexoName = menu.sexoName;
        //    return entity;
        //}

        //public static IList<Sexo> ListAll()
        //{
        //    IList<Sexo> list = new List<Sexo>();
        //    CorePontoEncontro.Model.Sexo[] collection = CorePontoEncontro.Model.Sexo.FindAll();
        //    foreach (var item in collection)
        //    {
        //        list.Add(Convert(item, 0));
        //    }
        //    return list;
        //}
    }
}