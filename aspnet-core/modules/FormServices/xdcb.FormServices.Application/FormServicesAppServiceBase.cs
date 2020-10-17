using Volo.Abp.Application.Services;

namespace xdcb.FormServices
{
    public class FormServicesAppServiceBase : ApplicationService
    {
        protected FormServicesAppServiceBase()
        {
            ObjectMapperContext = typeof(FormServicesApplicationModule);
        }
    }
}