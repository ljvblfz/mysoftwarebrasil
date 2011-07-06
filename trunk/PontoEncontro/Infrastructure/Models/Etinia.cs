
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;


namespace Infrastructure.Models
{
    public class Etinia
    {

        #region Properties

        [Required]
        [ScaffoldColumn(false)]
        public int etiniaId { get; set; }

        [DisplayName("Etinia")]
        [UIHint("EtiniaDropDown")]
        public string etiniaName { get; set; }

        #endregion

    } // Etinia
}

