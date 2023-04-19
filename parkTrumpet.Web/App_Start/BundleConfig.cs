using System.Web.Optimization;

namespace parkTrumpet.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery/js")
                .Include("~/Scripts/jquery-3.6.4.min.js").Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr/js").Include("~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new StyleBundle("~/bundles/slick/css").Include("~/Content/Slick/slick.css", new CssRewriteUrlTransform()));
            /*  < link rel = "stylesheet" href = "~/Content/Slick/slick.css" >

         < link rel = "stylesheet" href = "~/Content/font-awesome.min.css" >

            < link rel = "stylesheet" href = "plugins/font-awesome/brands.css" >
            <script src="~/Scripts/modernizr-2.8.3.js"></script>
               < link rel = "stylesheet" href = "plugins/font-awesome/solid.css" >
      <script src="~/Scripts/Slick/slick.min.js"></script>
      <script src="~/Scripts/scrollmenu.min.js"></script>
            */
        }
    }
}