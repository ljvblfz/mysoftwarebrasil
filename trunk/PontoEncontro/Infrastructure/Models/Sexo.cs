//

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;
using System.ComponentModel;

namespace Infrastructure.Models
{
    public class Sexo
    {
        #region properties

        [ScaffoldColumn(false)]
        public int sexoId { get; set; }

        [DisplayName("Sexo")]
        [UIHint("SexoDropDown")]
        [StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "SexosexoNameStringLength")]
        [Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "SexosexoNameRequired")]
        public string sexoName { get; set; }

        #endregion

        #region constructors

        public Sexo()
        {
        }

        public Sexo(dynamic entity)
        {
            this.sexoId = entity.sexoId;
            this.sexoName = entity.sexoName;
        }

        #endregion
    }
}
