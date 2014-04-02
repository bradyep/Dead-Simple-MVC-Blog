using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyntonicStudios.SSWebsite.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ViewBlog", "ViewBlog/{id}", new { controller = "Home", action = "ViewBlog" });
            routes.MapRoute("ViewExperiment", "ViewExperiment/{id}", new { controller = "Home", action = "ViewExperiment" });
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            // routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Admin", action = "Index", id = UrlParameter.Optional });
        }
    }
}
