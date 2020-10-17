using Localization.Resources.AbpUi;
using xdcb.HoSoCongTrinh.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace xdcb.HoSoCongTrinh
{
    [DependsOn(
        typeof(HoSoCongTrinhApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HoSoCongTrinhHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HoSoCongTrinhHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HoSoCongTrinhResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
