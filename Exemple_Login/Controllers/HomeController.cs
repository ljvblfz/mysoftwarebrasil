using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exemple_Login.Infrastructure;

namespace Exemple_Login.Controllers
{
    public class HomeController : Controller
    {
        [Authenticated]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [Authenticated]
        public ActionResult About()
        {
            return View();
        }
    }
}
