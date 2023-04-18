using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace parkTrumpet.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Console",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ParkingConsole", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminDashboard",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdminDashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
