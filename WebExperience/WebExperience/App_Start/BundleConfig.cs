using System.Web;
using System.Web.Optimization;

namespace WebExperience
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Script/Angular")
                .Include("~/bundles/main-es5*",
                        "~/bundles/polyfills-es5*",
                        "~/bundles/runtime-es5*",
                        "~/bundles/styles-es5*",
                        "~/bundles/vendor-es5*"));

            bundles.Add(new StyleBundle("~/Content/Angular")
              .Include("~/bundles/styles.*"));
        }
    }
}
