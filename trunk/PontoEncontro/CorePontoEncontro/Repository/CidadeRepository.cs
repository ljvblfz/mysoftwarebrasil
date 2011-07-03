using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class CidadeRepository
    {
        private static Cidade Convert(dynamic oldEntity, int loop)
        {
            Cidade entity = new Cidade();

            entity.cidadeId = oldEntity.cidadeId;
            entity.cidadeName = oldEntity.cidadeName;
            entity.estadoId = oldEntity.estadoId.estadoId;
            return entity;
        }

        private static CorePontoEncontro.Model.Cidade UnConvert(dynamic oldEntity)
        {
            CorePontoEncontro.Model.Cidade entity = new CorePontoEncontro.Model.Cidade();
            entity.cidadeId = oldEntity.cidadeId;
            entity.cidadeName = oldEntity.cidadeName;
            entity.estadoId = oldEntity.estadoId;
            return entity;
        }

        public static IList<Cidade> ListAll()
        {
            IList<Cidade> list = new List<Cidade>();
            CorePontoEncontro.Model.Cidade[] collection = CorePontoEncontro.Model.Cidade.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }

    }
}
