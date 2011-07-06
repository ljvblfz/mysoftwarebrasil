namespace Infrastructure.Models
{
	// data object class Cabelo generated from Cabelos
	// alexis [2011-06-13] Created
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public partial class Cabelo 
	{
		#region Properties

        [ScaffoldColumn(false)]
        public int cabelosId { get; set; }

        [DisplayName("Cabelos")]
        [UIHint("CabelosDropDown")]
        public string cabelosName { get; set; }

		#endregion

	} // Cabelo
}

