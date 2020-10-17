using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace xdcb.FileService
{
    public class FileServiceDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<FileServiceDomainSharedModule>("xdcb.FileService");
            });
        }
    }
}