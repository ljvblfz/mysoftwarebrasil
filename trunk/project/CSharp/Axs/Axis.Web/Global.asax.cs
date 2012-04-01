using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Axis.Infrastructure.MVC.Security;
using Axis.Infrastructure.Log;
using Axis.Infrastructure.MVC;
using Axis.Application;

namespace Axis
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Authenticated());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute("LogOn",
                "LogOn",
                new { controller = "Account", action = "LogOn", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            InitialChargeApplication.Start();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Adciona Atributos customizados ao MetaData
            ModelMetadataProviders.Current = new ExtendModelMetadataProvider(new CustomMetadataProvider());
        }
    }
}