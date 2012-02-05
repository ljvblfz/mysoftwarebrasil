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
        public string Nomepessoa { get; set; }

        //[StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        //[Display(Name = "CEP")]
        //public string Cep { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EMailpessoa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime Nascimentopessoa { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Estado")]
        public IEnumerable<SelectListItem> Idestado { get; set; }

        [UIHint("DropDown")]
        [Display(Name = "Cidade")]
        public IEnumerable<SelectListItem> Idcidade { get; set; }

        public PersonModel()
        {
        }

        public PersonModel(IList<Estado> listState)
        {
            this.Idestado = EnumerableExtensions.CreateSelectListItem(listState, t => t.Nameestado, y => y.Idestado);
            //Idcidade = new List<SelectListItem>() { new SelectListItem(){Text="Selecione um estado",Value="",Selected=true}};
        }
    }
}
