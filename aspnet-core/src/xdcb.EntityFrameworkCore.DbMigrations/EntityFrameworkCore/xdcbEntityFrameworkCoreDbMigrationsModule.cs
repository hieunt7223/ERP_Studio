using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace xdcb.EntityFrameworkCore
{
    [DependsOn(
        typeof(xdcbEntityFrameworkCoreModule)
        )]
    public class xdcbEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<xdcbMigrationsDbContext>();
        }
    }
}
