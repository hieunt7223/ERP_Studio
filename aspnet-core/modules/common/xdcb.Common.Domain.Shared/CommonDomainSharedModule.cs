using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace xdcb.Common
{
    public class CommonDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CommonDomainSharedModule>("xdcb.Common");
            });
        }
    }
}