namespace Infrastructure.Models
{
	// data object class Olho generated from Olhos
	// alexis [2011-06-13] Created
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public class Olho 
	{

		#region Properties

        [ScaffoldColumn(false)]
        public int olhosId { get; set; }

        [DisplayName("Olhos")]
        [UIHint("OlhosDropDown")]
        public string olhosName { get; set; }

		#endregion

	} // Olho
}

