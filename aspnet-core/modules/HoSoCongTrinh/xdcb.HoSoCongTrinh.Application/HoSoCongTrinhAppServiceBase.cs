using Volo.Abp.Application.Services;
using xdcb.HoSoCongTrinh.Localization;

namespace xdcb.HoSoCongTrinh
{
    public abstract class HoSoCongTrinhAppServiceBase : ApplicationService
    {
        protected HoSoCongTrinhAppServiceBase()
        {
            ObjectMapperContext = typeof(HoSoCongTrinhApplicationModule);
            LocalizationResource = typeof(HoSoCongTrinhResource);
        }
    }
}