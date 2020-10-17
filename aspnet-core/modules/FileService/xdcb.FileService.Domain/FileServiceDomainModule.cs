using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace xdcb.FileService
{
    [DependsOn(
        typeof(FileServiceDomainSharedModule)
    )]
    public class FileServiceDomainModule : AbpModule
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