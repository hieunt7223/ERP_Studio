using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace xdcb.BookStore
{
    [DependsOn(
       typeof(BookStoreDomainSharedModule),
        typeof(BookStoreApplicationContractsModule),
        typeof(BookStoreEntityFrameworkCoreModule)
   )]
    public class BookStoreApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BookStoreApplicationAutoMapperProfile>();
            });
        }
    }
}
