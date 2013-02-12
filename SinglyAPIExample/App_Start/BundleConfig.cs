using System.Web.Optimization;

namespace SinglyAPIExample.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(
                new ScriptBundle("~/bundles/scripts")
                .Include(
                "~/Sripts/jquery-1.9.2*",
                "~/Scripts/knockout*"
                ));
        }
    }
}