
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
    public class EstadoCivil                                                                                         
    {
        #region properties
 
		[ScaffoldColumn(false)]
		public int estadoCivilId { get; set; }
 
        [DisplayName("Estado Civil")]
        [UIHint("EstadoCivilDropDown")]
		[StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "EstadoCivilestadoCivilNameStringLength")]		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "EstadoCivilestadoCivilNameRequired")]
		public string estadoCivilName { get; set; }
 
        #endregion
 
        #region constructors
 
		public EstadoCivil()
		{
		}
		
		public EstadoCivil(dynamic entity)
		{
		this.estadoCivilId = entity.estadoCivilId;
		this.estadoCivilName = entity.estadoCivilName;
		}
	
		#endregion
	}
}

