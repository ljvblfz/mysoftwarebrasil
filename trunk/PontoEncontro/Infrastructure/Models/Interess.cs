namespace Infrastructure.Models
{
	// data object class Interess generated from Interesses
	// alexis [2011-06-13] Created

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public partial class Interess 
	{
        [Required]
        [ScaffoldColumn(false)]
        public int interresseId { get; set; }

        [UIHint("CheckBoxDropDown")]
        public string interresseName { get; set; }

	} // Interess
}

