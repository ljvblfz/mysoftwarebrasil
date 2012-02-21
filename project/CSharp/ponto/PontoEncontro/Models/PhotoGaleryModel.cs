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

    public class PhotoGaleryModel : PhotoModel
    {
        public Image legendaFoto { get; set; }

        public PhotoGaleryModel()
        {
        }
    }
}
