using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PontoEncontro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Themes()
        {
            HttpCookie themeCookie = Request.Cookies["Theme"];

            string theme = themeCookie != null ? themeCookie.Value : "Default";

            ViewBag.Themes = new SelectList(
                new[] { "Default", "1Column", "2Column", "3Column" }, theme);

            return PartialView();
        }

        [HttpPost]
        public ActionResult Themes(string theme)
        {
            HttpCookie themeCookie = new HttpCookie("Theme", theme);
            HttpContext.Response.Cookies.Add(themeCookie);

            ViewBag.Themes = new SelectList(
                new[] { "Default", "1Column", "2Column", "3Column" }, theme);

            return PartialView();
        }
    }
}
