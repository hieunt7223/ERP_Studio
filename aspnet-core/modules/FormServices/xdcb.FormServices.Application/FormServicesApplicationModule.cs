using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace xdcb.FormServices
{
    [DependsOn(
        typeof(FormServicesDomainModule),
        typeof(FormServicesApplicationContractsModule)
        )]
    public class FormServicesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<FormServicesApplicationModule>();
            });
        }
    }
}