using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace xdcb.QuanLyVon.EntityFrameworkCore
{
    [DependsOn(
        typeof(QuanLyVonEntityFrameworkCoreModule)
        )]
    public class QuanLyVonEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<QuanLyVonMigrationsDbContext>();
        }
    }
}