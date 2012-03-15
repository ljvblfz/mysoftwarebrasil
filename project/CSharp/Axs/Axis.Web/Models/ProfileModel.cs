using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Axis.Domain;
using AutoMapper;

namespace Axis.Models
{

    public class ProfileModel
    {
        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Sexo")]
        public IEnumerable<SelectListItem> idSexo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Olhos")]
        public IEnumerable<SelectListItem> idOlho { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Cabelo")]
        public IEnumerable<SelectListItem> idCabelo { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Etnia")]
        public IEnumerable<SelectListItem> idEtinia { get; set; }

        [Required]
        [UIHint("DropDown")]
        [Display(Name = "Estado civil")]
        public IEnumerable<SelectListItem> idEstadoCivil { get; set; }

        public ProfileModel()
        {
            this.idSexo = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Masculino", Value = "1", Selected = false },
                new SelectListItem() { Text = "Feminino", Value = "2", Selected = false }
            };

            this.idOlho = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Claro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Escuro", Value = "2", Selected = false }
            };

            this.idCabelo = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Preto", Value = "1", Selected = false },
                new SelectListItem() { Text = "Loiro", Value = "2", Selected = false }
            };

            this.idEtinia = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Negro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Branco", Value = "2", Selected = false }
            };

            this.idEstadoCivil = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Solteiro", Value = "1", Selected = false },
                new SelectListItem() { Text = "Casado", Value = "2", Selected = false }
            };
        }

        public ProfileModel(Perfil perfil)
        {
            Mapper.CreateMap<Perfil, ProfileModel>();
            Mapper.Map(perfil, this, typeof(Perfil), typeof(ProfileModel));
        }
    }
}
