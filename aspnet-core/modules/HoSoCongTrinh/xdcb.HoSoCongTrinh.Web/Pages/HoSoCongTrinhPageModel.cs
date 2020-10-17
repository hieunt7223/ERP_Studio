using xdcb.HoSoCongTrinh.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace xdcb.HoSoCongTrinh.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HoSoCongTrinhPageModel : AbpPageModel
    {
        protected HoSoCongTrinhPageModel()
        {
            LocalizationResourceType = typeof(HoSoCongTrinhResource);
            ObjectMapperContext = typeof(HoSoCongTrinhWebModule);
        }
    }
}