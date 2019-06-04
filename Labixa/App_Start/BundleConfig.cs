using System.Web;
using System.Web.Optimization;

namespace Labixa
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //CSS for  Ace admin
            bundles.Add(new StyleBundle("~/Style/Common").Include(
     "~/Content/admin/css/bootstrap.min.css",
      "~/Content/admin/css/font-awesome.min.css",
       "~/Content/admin/css/ace.min.css",
       "~/Content/admin/css/ace-rtl.min.css",
         "~/Content/admin/css/ace-skins.min.css",
         "~/Content/admin/css/ace-fonts.css",
          "~/Content/admin/css/datepicker.css",
          "~/Content/admin/css/font-awesome.min.css",
         "~/Content/admin/admincustom.css"
            ));

            //Scipts for  Ace admin
            bundles.Add(new ScriptBundle("~/Scripts/Common").Include(
    "~/Content/admin/js/jquery-2.0.3.min.js",
    "~/Content/admin/js/bootstrap.min.js",
    "~/Content/admin/js/jquery-ui-1.10.3.full.min.js",
    "~/Content/admin/js/date-time/bootstrap-datepicker.min.js",
                    "~/Content/assets/js/ace-elements.min.js",
    "~/Content/admin/js/ace.min.js",
    "~/Content/admin/js/ace-extra.min.js",
    "~/Content/admin/vpn/adminvpn.js"
            ));
        }
    }
}
