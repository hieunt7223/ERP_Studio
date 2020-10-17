using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace xdcb.Web
{
    [Dependency(ReplaceServices = true)]
    public class xdcbBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "xdcb";
    }
}
