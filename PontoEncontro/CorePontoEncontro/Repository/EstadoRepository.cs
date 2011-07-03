using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class EstadoRepository
    {
        private static Estado Convert(dynamic oldEntity, int loop)
        {
            Estado entity = new Estado();
            entity.estadoId = oldEntity.estadoId;
            entity.estadoName = oldEntity.estadoName;
            entity.estadoSigla = oldEntity.estadoSigla;
            entity.paisId = oldEntity.paisId.paisId;
            return entity;
        }

        private static CorePontoEncontro.Model.Estado UnConvert(dynamic oldEntity)
        {
            CorePontoEncontro.Model.Estado entity = new CorePontoEncontro.Model.Estado();
            entity.estadoId = oldEntity.estadoId;
            entity.estadoName = oldEntity.estadoName;
            entity.estadoSigla = oldEntity.estadoSigla;
            entity.paisId = oldEntity.paisId;
            return entity;
        }

        public static IList<Estado> ListAll()
        {
            IList<Estado> list = new List<Estado>();
            CorePontoEncontro.Model.Estado[] collection = CorePontoEncontro.Model.Estado.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }
    }

}
