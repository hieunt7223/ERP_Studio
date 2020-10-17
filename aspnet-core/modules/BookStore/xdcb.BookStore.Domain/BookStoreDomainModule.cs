using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace xdcb.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainSharedModule)
    )]
    public class BookStoreDomainModule : AbpModule
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
