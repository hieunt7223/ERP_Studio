using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using xdcb.Common;
using xdcb.Common.EfCore.DbMigrations;

namespace xdcb.EntityFrameworkCore
{
    [DependsOn(
        typeof(CommonEntityFrameworkCoreModule)
        )]
    public class CommonDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CommonMigrationDbContext>();
        }
    }
}