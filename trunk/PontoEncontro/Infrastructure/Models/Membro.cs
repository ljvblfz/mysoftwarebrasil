namespace Infrastructure.Models
{
	// data object class Membro generated from Membro
	// alexis [2011-06-13] Created

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

	public partial class Membro 
	{
        [Required]
        [ScaffoldColumn(false)]
        public Pessoa pessoaId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int membroId { get; set; }

        [Required]
        [DisplayName("Login")]
        public string membroNickName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime membroUltimoLogin { get; set; }

        [Required]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string membroSenha { get; set; }

	} // Membro
}

