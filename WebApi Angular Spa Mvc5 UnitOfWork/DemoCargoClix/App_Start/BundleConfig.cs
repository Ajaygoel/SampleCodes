// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright © 2015 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.DemoCargoClix
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css"));


            bundles.Add(new StyleBundle("~/content/css/toastr").Include("~/content/toastr.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/toastr").Include("~/scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/js/moment").Include("~/scripts/moment.js"));


            bundles.Add(new ScriptBundle("~/js/angular").Include(
             "~/Scripts/angular.js",
             "~/Scripts/angular-animate.js",
             "~/Scripts/angular-cookies.js",
             "~/Scripts/angular-loader.js",
             "~/Scripts/angular-mocks.js",
             "~/Scripts/angular-resource.js",
             "~/Scripts/angular-route.js",
             "~/Scripts/angular-sanitize.js",
             "~/Scripts/loading-bar.js"
            ));


            bundles.Add(new ScriptBundle("~/js/app").Include(
              //   "~/scripts/angular-ui-router.js",
                "~/scripts/app/filters.js",
                "~/scripts/app/services.js",
                "~/scripts/app/directives.js",
                "~/scripts/app/controllers.js",
                "~/scripts/app/app.js"));
        }
    }
}
