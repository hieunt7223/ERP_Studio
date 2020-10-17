using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace xdcb.Web.Bundling
{
    public class ScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // AdminLTE
            context.Files.Add("/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
            context.Files.Add("/plugins/chart.js/Chart.min.js");
            context.Files.Add("/themes/adminlte/js/adminlte.js");
            context.Files.Add("/themes/adminlte/js/layout.js");

            // XDCB
            context.Files.AddIfNotContains("/js/xdcb/consts.js");
            context.Files.AddIfNotContains("/js/xdcb/messages.js");
            context.Files.AddIfNotContains("/js/xdcb/scripts.js");
        }
    }
}
