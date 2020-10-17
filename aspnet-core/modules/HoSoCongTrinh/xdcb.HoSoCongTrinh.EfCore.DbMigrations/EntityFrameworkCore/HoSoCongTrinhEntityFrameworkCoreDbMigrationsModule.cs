using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    [DependsOn(
        typeof(HoSoCongTrinhEntityFrameworkCoreModule)
        )]
    public class HoSoCongTrinhEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HoSoCongTrinhMigrationsDbContext>();
        }
    }
}