using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using PontoEncontro.Domain;

namespace PontoEncontro.Models
{

    public class ProfileModel
    {
        [HiddenInput]
        public virtual int Idperfil { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Sexo")]
        public IEnumerable<SelectListItem> Idsexo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Olhos")]
        public IEnumerable<SelectListItem> Idolho { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Cabelo")]
        public IEnumerable<SelectListItem> Idcabelo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Etnia")]
        public IEnumerable<SelectListItem> Idetinia { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Estado civil")]
        public IEnumerable<SelectListItem> Idestadocivil { get; set; }

        public ProfileModel()
        {
            this.Idsexo = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Masculino", Value = "1", Selected = false },
                new SelectListItem() { Text = "Feminino", Value = "2", Selected = false }
            };

            this.Idolho = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Claro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Escuro", Value = "2", Selected = false }
            };

            this.Idcabelo = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Preto", Value = "1", Selected = false },
                new SelectListItem() { Text = "Loiro", Value = "2", Selected = false }
            };

            this.Idetinia = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Negro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Branco", Value = "2", Selected = false }
            };

            this.Idestadocivil = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Solteiro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Casado", Value = "2", Selected = false }
            };
        }
    }
}
