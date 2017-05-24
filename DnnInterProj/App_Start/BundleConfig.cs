using System.Web;
using System.Web.Optimization;

namespace DnnInterProj
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/uilib").Include(
            //    "~/Scripts/jquery-1.9.1.js",
            //    "~/Scripts/ui191/jquery.ui.core.js",
            //    "~/Scripts/ui191/jquery.ui.widget.js",
            //    "~/Scripts/ui191/jquery.ui.mouse.js",
            //    "~/Scripts/ui191/jquery.ui.button.js",
            //    "~/Scripts/ui191/jquery.ui.draggable.js",
            //    "~/Scripts/ui191/jquery.ui.position.js",
            //    "~/Scripts/ui191/jquery.ui.resizable.js",
            //    "~/Scripts/ui191/jquery.ui.button.js",
            //    "~/Scripts/ui191/jquery.ui.dialog.js",
            //    "~/Scripts/ui191/jquery.ui.effect.js"
            //    ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(

        
              "~/Scripts/bootstrap.js",
            "~/Scripts/bootbox.js",
            "~/Scripts/respond.js"
              ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-Lumen.css",             
                      "~/Content/site.css"));
        }
    }
}
