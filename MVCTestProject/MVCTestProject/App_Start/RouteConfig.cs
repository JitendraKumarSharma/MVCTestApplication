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



            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
                //constraints: new { controller = "^H.*", action = "^Index$|^Contact$" }
            );

            //routes.MapRoute(
            //    name: "test",
            //    url: "CascadeDropdown/Index",
            //    defaults: new { controller = "CascadeDropdown", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
