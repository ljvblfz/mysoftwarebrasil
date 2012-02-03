using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using PontoEncontro.Domain;

namespace PontoEncontro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //var user = new PontoEncontro.Domain.ActionRepository().ListAll();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
