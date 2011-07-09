//

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;

namespace Infrastructure.Models
{
    public class ComunidadeMembro
    {
        #region properties

        public int comunidadeId { get; set; }

        public Comunidade comunidade { get; set; }
  
        public int membroId { get; set; }

        public Membro membro { get; set; }

        public int comunidadeMembroId { get; set; }

        #endregion

        #region constructors

        public ComunidadeMembro()
        {
        }

        public ComunidadeMembro(dynamic entity)
        {
            this.comunidadeId = entity.comunidadeId;
            if (entity.comunidade != null)
                this.comunidade = new Comunidade(entity.comunidade);
            this.membroId = entity.membroId;
            if (entity.membro != null)
                this.membro = new Membro(entity.membro);

            this.comunidadeMembroId = entity.comunidadeMembroId;
        }

        #endregion
    }
}
