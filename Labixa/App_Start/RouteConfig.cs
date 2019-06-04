using Labixa.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Labixa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("culture", "language/{slug}", new { controller = "Home", action = "SetCulture", slug = UrlParameter.Optional });

            routes.MapRoute("about_us", "quy-trinh-hop-tac", new { controller = "Home", action = "about_us" });
            routes.MapRoute("Contact", "lien-he", new { controller = "Home", action = "Contact" });
            routes.MapRoute("Products", "san-pham", new { controller = "Products", action = "Products" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }


    }
}
