using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axis.Infrastructure.MVC.Security;
//using Axis.Domain;

namespace Axis.Controllers
{
    public class HomeController : Controller
    {
        [Anonymous]
        public ActionResult Index(string id)
        {
            return View();
        }

        [Anonymous]
        public ActionResult About()
        {
            return View();
        }
    }
}
