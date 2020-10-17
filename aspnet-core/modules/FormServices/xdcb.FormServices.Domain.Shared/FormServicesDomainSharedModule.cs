using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using xdcb.FormServices.Localization;

namespace xdcb.FormServices
{
    public class FormServicesDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<FormServicesDomainSharedModule>("xdcb.FormServices");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<FormServicesResource>("en")
                    .AddVirtualJson("/Localization/FormServices");

                options.DefaultResourceType = typeof(FormServicesResource);
            });
        }
    }
}