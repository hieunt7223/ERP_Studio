using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using xdcb.HoSoCongTrinh.Localization;

namespace xdcb.HoSoCongTrinh
{
    public class HoSoCongTrinhDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HoSoCongTrinhDomainSharedModule>("xdcb.HoSoCongTrinh");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<HoSoCongTrinhResource>("en")
                    .AddVirtualJson("/Localization/HoSoCongTrinh");

                options.DefaultResourceType = typeof(HoSoCongTrinhResource);
            });
        }
    }
}