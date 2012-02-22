using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure.MVC.DataAnnotations;
using Lms.API.Infrastructure.MVC.Extensions;
using System.Linq.Expressions;

namespace PontoEncontro.Models
{

    public class PersonModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Seu nome")]
        public string nomePessoa { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string e_MailPessoa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime nascimentoPessoa { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Estado")]
        public IEnumerable<SelectListItem> Idestado { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Cidade")]
        public IEnumerable<SelectListItem> Idcidade { get; set; }

        public PersonModel()
        {
        }
    }
}
