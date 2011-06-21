using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CorePontoEncontro;

namespace PontoEncontro
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            CorePontoEncontro.Inicialize.Ini();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            RazorViewEngine engine = (RazorViewEngine)System.Web.Mvc.ViewEngines.Engines[1];

            HttpCookie themeCookie = Request.Cookies["Theme"];

            string themeName = "Default";

            if (themeCookie != null)
                themeName = themeCookie.Value;

            engine.MasterLocationFormats = new string[] {
                    "~/Themes/" + themeName + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + themeName + "/Views/Shared/{0}.cshtml",
                };

            engine.ViewLocationFormats = new string[] {
                    "~/Themes/" + themeName + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + themeName + "/Views/Shared/{0}.cshtml",
                };

            engine.PartialViewLocationFormats = new string[] {
                    "~/Themes/" + themeName + "/Views/{1}/{0}.cshtml",
                    "~/Themes/" + themeName + "/Views/Shared/{0}.cshtml",
                };

            string extensionsPath = Server.MapPath(string.Format("~/Themes/{0}/Extensions/", themeName));
        }
    }
}