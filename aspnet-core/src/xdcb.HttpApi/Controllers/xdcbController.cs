using xdcb.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace xdcb.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class xdcbController : AbpController
    {
        protected xdcbController()
        {
            LocalizationResource = typeof(xdcbResource);
        }
    }
}