
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.ComponentModel;

namespace Infrastructure.Models
{
	public partial class Pessoa 
	{
        [Required]
        [ScaffoldColumn(false)]
        public int pessoaId { get; set; }

        [Required]
        [DisplayName("Nome")]
        [Description("Digite seu nome")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string pessoaName { get; set; }

        [DisplayName("Sexo")]
        [UIHint("SexoDropDown")]
        public int sexoId { get; set; }

        [Required]
        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime pessoaNascimento { get; set; }

        [DisplayName("Estado Civil")]
        [UIHint("EstadoCivilDropDown")]
        public int estadoCivilId { get; set; }

        [Required]
        [DisplayName("Profissão")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string pessoaProfissao { get; set; }

        [Required]
        [DisplayName("Email")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string pessoaEmail { get; set; }

        [Required]
        [DisplayName("MSN")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string pessoaMSN { get; set; }

        [ScaffoldColumn(false)]
        public int olhosId { get; set; }

        [ScaffoldColumn(false)]
        public int cabelosId { get; set; }

        [ScaffoldColumn(false)]
        public int etiniaId { get; set; }

        [ScaffoldColumn(false)]
        public int perfilId { get; set; }

        [ScaffoldColumn(false)]
        public int enderecoId { get; set; }

	} // Pessoa
}

