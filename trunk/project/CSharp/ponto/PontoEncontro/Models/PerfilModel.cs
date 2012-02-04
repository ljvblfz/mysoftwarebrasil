using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using PontoEncontro.Domain;

namespace PontoEncontro.Models
{

    public class PerfilModel
    {
        [HiddenInput]
        public virtual int Idperfil { get; set; }

        [Required]
        [DataType(DataType.Custom)]
        [Display(Name = "Sexo")]
        public virtual IList<Sexo> Idsexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Olhos")]
        public virtual IList<Olho> Idolho { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Cabelo")]
        public virtual IList<Cabelo> Idcabelo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Etnia")]
        public virtual IList<Etinia> Idetinia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Estado civil")]
        public virtual IList<Estadocivil> Idestadocivil { get; set; }
    }
}
