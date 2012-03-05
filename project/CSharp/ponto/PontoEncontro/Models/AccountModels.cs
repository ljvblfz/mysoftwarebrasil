using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PontoEncontro.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ser, pelo menos, {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e confirmação de senha não correspondem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "O(A) {0} deve ser informado.")]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O(A) {0} deve ser informado.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [StringLength(100, ErrorMessage = "A {0} deve ser, pelo menos, {2} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Lembre de mim")]
        public bool RememberMe { get; set; }
    }
}
