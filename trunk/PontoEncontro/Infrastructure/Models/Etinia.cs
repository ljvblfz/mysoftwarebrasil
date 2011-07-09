
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public class Etinia                                                                                              
    {
        #region properties
 
		[ScaffoldColumn(false)]
		public int etiniaId { get; set; }
 
        [DisplayName("Etinia")]
        [UIHint("EtiniaDropDown")]
		[StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "EtiniaetiniaNameStringLength")]		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "EtiniaetiniaNameRequired")]
		public string etiniaName { get; set; }
 
        #endregion
 
        #region constructors
 
		public Etinia()
		{
		}
		
		public Etinia(dynamic entity)
		{
		this.etiniaId = entity.etiniaId;
		this.etiniaName = entity.etiniaName;
		}
	
		#endregion
	}
}


