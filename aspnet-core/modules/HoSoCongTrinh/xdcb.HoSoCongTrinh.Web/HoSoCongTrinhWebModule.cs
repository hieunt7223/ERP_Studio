using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using xdcb.HoSoCongTrinh.Localization;
using xdcb.HoSoCongTrinh.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Autofac;
using xdcb.HoSoCongTrinh.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;

namespace xdcb.HoSoCongTrinh.Web
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HoSoCongTrinhApplicationModule),
        typeof(HoSoCongTrinhApplicationContractsModule),
        typeof(HoSoCongTrinhEntityFrameworkCoreModule),
        typeof(HoSoCongTrinhHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HoSoCongTrinhWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(HoSoCongTrinhResource), typeof(HoSoCongTrinhWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HoSoCongTrinhWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new HoSoCongTrinhMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HoSoCongTrinhWebModule>("xdcb.HoSoCongTrinh.Web");
            });

            context.Services.AddAutoMapperObjectMapper<HoSoCongTrinhWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HoSoCongTrinhWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(HoSoCongTrinhApplicationModule).Assembly);
            });
        }
    }
}
