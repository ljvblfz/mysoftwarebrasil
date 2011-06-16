using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PontoEncontro.Models
{
    public class Menu
    {
        [Required]
        [ScaffoldColumn(false)]
        public int MenuId { get; set; }

        [DisplayFormat(NullDisplayText = "(null value)")]
        public Menu MenuIdPai { get ; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MenuName { get ; set; }

        [Required]
        public int MenuOrdem { get ; set; }

        [Required]
        [DataType(DataType.Url)]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MenuPath { get ; set; }


    } // Menu
}

