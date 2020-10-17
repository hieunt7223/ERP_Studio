using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using xdcb.BookStore;
using xdcb.BookStore.EntityFrameworkCore;

namespace xdcb.EntityFrameworkCore
{
    [DependsOn(
        typeof(BookStoreEntityFrameworkCoreModule)
        )]
    public class BookStoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookStore.EntityFrameworkCore.BookStoreMigrationDbContext>();
        }
    }
}
