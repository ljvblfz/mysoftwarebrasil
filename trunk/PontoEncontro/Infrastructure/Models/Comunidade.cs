using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;

namespace Infrastructure.Models
{
    public class Comunidade
    {
        #region properties

        [ScaffoldColumn(false)]
        public int comunidadeId { get; set; }

        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "ComunidadecomunidadeNameStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "ComunidadecomunidadeNameRequired")]
        public string comunidadeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "ComunidadecomunidadeDataCreateRequired")]
        public DateTime comunidadeDataCreate { get; set; }

        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "ComunidadecomunidadeDescricaoStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "ComunidadecomunidadeDescricaoRequired")]
        public string comunidadeDescricao { get; set; }

        #endregion

        #region constructors

        public Comunidade()
        {
        }

        public Comunidade(dynamic entity)
        {
            this.comunidadeId = entity.comunidadeId;
            this.comunidadeName = entity.comunidadeName;
            this.comunidadeDataCreate = entity.comunidadeDataCreate;
            this.comunidadeDescricao = entity.comunidadeDescricao;
        }

        #endregion
    }
}
