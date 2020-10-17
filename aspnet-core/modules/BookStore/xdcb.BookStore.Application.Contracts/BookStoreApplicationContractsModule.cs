using Volo.Abp.Modularity;

namespace xdcb.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainSharedModule)
    )]
    public class BookStoreApplicationContractsModule : AbpModule
    {

    }
}
