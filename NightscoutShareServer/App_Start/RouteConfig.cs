using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NightscoutShareServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Token",
                 url: "ShareWebServices/Services/General/LoginPublisherAccountByName",
                 defaults: new { controller = "Token", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Glucose",
                url: "ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues",
                defaults: new { controller = "Glucose", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}