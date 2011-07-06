namespace Infrastructure.Models
{
	// data object class Cidade generated from Cidade
	// alexis [2011-06-13] Created
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public partial class Cidade 
	{

		#region Properties

        [DisplayName("Cidade")]
        [UIHint("CidadeDropDown")]
        public int cidadeId { get; set; }

        [ScaffoldColumn(false)]
        public string cidadeName { get; set; }

        [ScaffoldColumn(false)]
        public int estadoId { get; set; }

		#endregion

	} // Cidade
}

