namespace Infrastructure.Models
{
	// data object class Estado generated from Estado
	// alexis [2011-06-13] Created
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public partial class Estado 
	{

		#region Properties

        [DisplayName("Estado")]
        [UIHint("EstadoDropDown")]
        public int estadoId { get; set; }

        [ScaffoldColumn(false)]
        public string estadoName { get; set; }

        [ScaffoldColumn(false)]
        public string estadoSigla { get; set; }

        [ScaffoldColumn(false)]
        public int paisId { get; set; }

		#endregion

	} // Estado
}
