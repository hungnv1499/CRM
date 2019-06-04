using System.Web.Mvc;

namespace Labixa.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
           
            context.MapRoute(
               "Admin_default_2",
               "Admin",
               new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
           );
            //Set route for FilesController
            context.MapRoute(null, "Admin/File/connector", new { controller = "File", action = "LoadFile" });
            context.MapRoute(null, "Admin/File/Thumbnails/{tmb}", new { controller = "File", action = "Thumbs", tmb = UrlParameter.Optional });

            context.MapRoute(
                         "Admin_default",
                         "Admin/{controller}/{action}/{id}",
                         new { action = "Index", id = UrlParameter.Optional }
                     );
        }
    }
}