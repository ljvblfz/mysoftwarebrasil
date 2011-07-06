using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;

namespace Infrastructure.Models
{
    public class Menu
    {
        [Required]
        [ScaffoldColumn(false)]
        public int MenuId { get; set; }

        [ScaffoldColumn(false)]
        public int? MenuIdPai { get ; set; }

        [DisplayName("Menu Pai")]
        [UIHint("MenuDropDown")]
        public string MenuPaiName { get; set; }

        [Required]
        [DisplayName("Nome")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MenuName { get ; set; }

        [Required]
        [DisplayName("Ordem")]
        public int MenuOrdem { get ; set; }

        [Required]
        [DisplayName("URL")]
        [DataType(DataType.Url)]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        public string MenuPath { get ; set; }

    } // Menu
}

