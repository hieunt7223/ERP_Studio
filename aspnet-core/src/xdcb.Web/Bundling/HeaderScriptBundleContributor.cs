using System;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace xdcb.Web.Bundling
{
    public class HeaderScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.RemoveAll(x => x.StartsWith("/libs/jquery/jquery.js", StringComparison.InvariantCultureIgnoreCase));

            context.Files.AddIfNotContains("/js/devextreme/jquery.js");
        }
    }
}
