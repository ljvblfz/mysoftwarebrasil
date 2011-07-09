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
    public class Cabelo                                                                                             
    {
        #region properties
 
		[ScaffoldColumn(false)]
		public int cabelosId { get; set; }
 
        [DisplayName("Cabelos")]
        [UIHint("CabelosDropDown")]
		[StringLength(255, ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "CabeloscabelosNameStringLength")]
		public string cabelosName { get; set; }
 
        #endregion
 
        #region constructors
 
		public Cabelo()
		{
		}

        public Cabelo(dynamic entity)
		{
		this.cabelosId = entity.cabelosId;
		this.cabelosName = entity.cabelosName;
		}
	
		#endregion
	}
}

