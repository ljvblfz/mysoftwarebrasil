using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Infrastructure.Models;

namespace CorePontoEncontro.Repository
{
    public class EstadoCivilRepository
    {
        private static EstadoCivil Convert(dynamic oldEntity, int loop)
        {
            EstadoCivil entity = new EstadoCivil();
            entity.estadoCivilId = oldEntity.estadoCivilId;
            entity.estadoCivilName = oldEntity.estadoCivilName;
            return entity;
        }

        private static CorePontoEncontro.Model.EstadoCivil UnConvert(dynamic oldEntity)
        {
            CorePontoEncontro.Model.EstadoCivil entity = new CorePontoEncontro.Model.EstadoCivil();
            entity.estadoCivilId = oldEntity.estadoCivilId;
            entity.estadoCivilName = oldEntity.estadoCivilName;
            return entity;
        }

        public static IList<EstadoCivil> ListAll()
        {
            IList<EstadoCivil> list = new List<EstadoCivil>();
            CorePontoEncontro.Model.EstadoCivil[] collection = CorePontoEncontro.Model.EstadoCivil.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }
    }

}
