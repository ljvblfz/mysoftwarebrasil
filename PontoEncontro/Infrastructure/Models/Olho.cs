
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
    public class Olho                                                                                               
    {
        #region properties
 
		[ScaffoldColumn(false)]
		public int olhosId { get; set; }
 
        [DisplayName("Olhos")]
        [UIHint("OlhosDropDown")]
		[StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "OlhosolhosNameStringLength")]
		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "OlhosolhosNameRequired")]
		public string olhosName { get; set; }
 
        #endregion
 
        #region constructors
 
		public Olho()
		{
		}

        public Olho(dynamic entity)
		{
		this.olhosId = entity.olhosId;
		this.olhosName = entity.olhosName;
		}
	
		#endregion
	}
}


