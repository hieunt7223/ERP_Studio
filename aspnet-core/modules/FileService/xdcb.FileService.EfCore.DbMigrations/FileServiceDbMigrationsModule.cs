using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using xdcb.FileService;

namespace xdcb.EntityFrameworkCore
{
    [DependsOn(
        typeof(FileServiceEntityFrameworkCoreModule)
        )]
    public class FileServiceDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<FileService.EntityFrameworkCore.FileServiceMigrationDbContext>();
        }
    }
}