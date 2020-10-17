using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace xdcb.Common
{
    [DependsOn(
        typeof(CommonDomainSharedModule)
    )]
    public class CommonDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
            });
        }
    }
}