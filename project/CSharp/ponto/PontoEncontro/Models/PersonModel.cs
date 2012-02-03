using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure.MVC.DataAnnotations;

namespace PontoEncontro.Models
{

    public class PersonModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Seu nome")]
        public virtual string Nomepessoa { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public virtual string EMailpessoa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public virtual DateTime Nascimentopessoa { get; set; }

        [Required]
        [DropDown]
        [Display(Name = "Estado")]
        public virtual IList<Estado> Idestado { get; set; }

        [Required]
        [DropDown]
        [Display(Name = "Cidade")]
        public virtual IList<Cidade> Idcidade { get; set; }
    }
}
