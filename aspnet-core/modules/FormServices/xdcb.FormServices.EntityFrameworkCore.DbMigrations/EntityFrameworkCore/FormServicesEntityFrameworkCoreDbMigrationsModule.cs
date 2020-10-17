using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace xdcb.FormServices.EntityFrameworkCore
{
    [DependsOn(
        typeof(FormServicesEntityFrameworkCoreModule)
        )]
    public class FormServicesEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<FormServicesMigrationsDbContext>();
        }
    }
}