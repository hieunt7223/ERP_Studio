using xdcb.HoSoCongTrinh.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace xdcb.HoSoCongTrinh
{
    public abstract class HoSoCongTrinhController : AbpController
    {
        protected HoSoCongTrinhController()
        {
            LocalizationResource = typeof(HoSoCongTrinhResource);
        }
    }
}
