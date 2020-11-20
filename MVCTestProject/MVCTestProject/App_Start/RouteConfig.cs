using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCTestProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SendDataFromViewToAction", action = "SimpleInterestWithModel", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "test",
                url: "CascadeDropdown/Index",
                defaults: new { controller = "CascadeDropdown", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
