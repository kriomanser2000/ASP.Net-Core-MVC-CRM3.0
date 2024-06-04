using System.Web;
using System.Web.Optimization;

namespace CRM3._0.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* ==============================================================================
             *                              JavaScript Files
             * ==============================================================================
             */
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-val").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-plugins").Include(
                        "~/Scripts/jquery.form.js",
                        "~/Scripts/jquery.chainedSelects.js",
                        "~/Scripts/jquery.pulse.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/bootstrap-fileupload.js",
                        "~/Scripts/bootstrap-inputmask.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/fullcalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/mms").Include(
                        "~/Scripts/mms-utils.js"));

            /* ==============================================================================
             *                               Style Sheets
             * ==============================================================================
             */
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap-responsive.css",
                        "~/Content/css/bootstrap-docs.css",
                        "~/Content/css/font-awesome.css",
                        "~/Content/css/datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/css/fullcalendar").Include(
                        "~/Content/css/fullcalendar.css"));

            bundles.Add(new StyleBundle("~/Content/css/site").Include(
                        "~/Content/css/Site.css"));
        }
    }
}