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
using System.Web;

namespace PontoEncontro.Models
{

    public class PhotoModel
    {
        [UIHint("File")]
        [Display(Name = "Foto")]
        public HttpPostedFileBase nameFoto { get; set; }

        [Display(Name = "Legenda")]
        public string legendaFoto { get; set; }

        public PhotoModel()
        {
        }
    }
}
