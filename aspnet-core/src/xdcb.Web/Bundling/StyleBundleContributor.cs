using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace xdcb.Web.Bundling
{
    public class StyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // AdminLTE
            context.Files.Add("/libs/Ionicons/css/ionicons.min.css");
            context.Files.Add("/plugins/overlayScrollbars/css/OverlayScrollbars.min.css");
            context.Files.Add("/plugins/chart.js/Chart.min.css");
            context.Files.Add("/themes/adminlte/css/AdminLTE.min.css");
            context.Files.Add("/themes/adminlte/css/layout.css");

            // XDCB style
            context.Files.Add("/css/xdcb/styles.css");

            // Devextrmeme
            context.Files.Add("/css/devextreme/dx.common.css");
            context.Files.Add("/css/devextreme/dx.light.css");
        }
    }
}
