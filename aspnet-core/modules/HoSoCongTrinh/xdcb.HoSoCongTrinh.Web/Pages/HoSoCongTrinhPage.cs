using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using xdcb.HoSoCongTrinh.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace xdcb.HoSoCongTrinh.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits xdcb.HoSoCongTrinh.Web.Pages.HoSoCongTrinhPage
     */
    public abstract class HoSoCongTrinhPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<HoSoCongTrinhResource> L { get; set; }
    }
}
