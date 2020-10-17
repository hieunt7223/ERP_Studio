using xdcb.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace xdcb.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(xdcbEntityFrameworkCoreDbMigrationsModule),
        typeof(xdcbApplicationContractsModule)
        )]
    public class xdcbDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
