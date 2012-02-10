using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PontoEncontro.Models
{

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string loginMembro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senhaMembro { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("senhaMembro", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public RegisterModel()
        {
        }
    }
}
