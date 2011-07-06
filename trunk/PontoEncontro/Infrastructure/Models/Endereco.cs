namespace Infrastructure.Models
{
	// data object class Endereco generated from Endereco
	// alexis [2011-06-13] Created
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;

	public partial class Endereco 
	{

		#region Properties

        [ScaffoldColumn(false)]
        public int enderecoId { get; set; }

        public string CEP { get; set; }

        public Cidade cidadeId { get; set; }

		#endregion

	} // Endereco
}

