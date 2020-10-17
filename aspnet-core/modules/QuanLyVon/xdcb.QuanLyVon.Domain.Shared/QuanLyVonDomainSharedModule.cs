using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using xdcb.QuanLyVon.Localization;

namespace xdcb.QuanLyVon
{
    public class QuanLyVonDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<QuanLyVonDomainSharedModule>("xdcb.QuanLyVon");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<QuanLyVonResource>("en")
                    .AddVirtualJson("/Localization/QuanLyVon");

                options.DefaultResourceType = typeof(QuanLyVonResource);
            });
        }
    }
}