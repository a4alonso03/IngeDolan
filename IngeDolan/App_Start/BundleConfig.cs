using System.Web;
using System.Web.Optimization;

namespace IngeDolan
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Toastr (Sistema de Mensajes)
            bundles.Add(new StyleBundle("~/content/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css")
            .Include("~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js")
            .Include("~/Scripts/toastr.js"));

            //Font Awesome
            bundles.Add(new StyleBundle("~/content/font-awesome", "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css")
            .Include("~/Content/font-awesome.css"));

            //Multiselect
            bundles.Add(new StyleBundle("~/content/multi-select")
            .Include("~/Content/multi-select.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.multi-select")
            .Include("~/Scripts/jquery.multi-select.js"));

            //jQuery UI
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
              "~/Content/themes/base/all.css"));

            //Intro JS
            bundles.Add(new ScriptBundle("~/bundles/introjs").Include(
            "~/Scripts/intro.js"));

            bundles.Add(new StyleBundle("~/Content/introjs").Include(
              "~/Content/introjs.css"));
        }
    }
}
