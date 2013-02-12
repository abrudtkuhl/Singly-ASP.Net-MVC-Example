using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SinglyAPIExample.App_Start.BundleConfig), "RegisterBundles")]

namespace SinglyAPIExample.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(
                new ScriptBundle("~/bundles/scripts").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/knockout-{version}.js",
                    "~/Scripts/knockout.mapping-latest.js"
                ));
        }
    }
}