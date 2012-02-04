using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.MVC.Security;
//using PontoEncontro.Domain;

namespace PontoEncontro.Controllers
{
    public class HomeController : Controller
    {
        //[Anonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //var user = new PontoEncontro.Domain.ActionRepository().ListAll();
            return View();
        }

        //[Anonymous]
        public ActionResult About()
        {
            return View();
        }
    }
}
