using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using xdcb.Common.DanhMuc;
using xdcb.FileService;
using xdcb.FileService.Localization;

namespace xdcb.Common
{
    [DependsOn(
          typeof(AbpAutofacModule),
        typeof(CommonDomainSharedModule),
        typeof(CommonApplicationModule),
        typeof(CommonApplicationContractsModule),
        typeof(CommonEntityFrameworkCoreModule),
        typeof(xdcbFileServiceWebModule)

        )]
    public class xdcbCommonWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(typeof(AbpTenantManagementResource), typeof(AbpTenantManagementWebModule).Assembly);
            //});

            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(fileServiceResource),
                    typeof(FileServiceApplicationContractsModule).Assembly,
                    typeof(FileServiceDomainSharedModule).Assembly,
                    typeof(FileServiceApplicationModule).Assembly,
                    typeof(FileServiceApplicationContractsModule).Assembly
                );
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(xdcbCommonWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new xdcbCommonMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<xdcbCommonWebModule>("xdcb.Common.Web");
            });
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ThuVienVanBanWebAutoMapperProfile>();
               
            });

            //context.Services.AddAutoMapperObjectMapper<xdcbCommonWebModule>();
            //Configure<AbpAutoMapperOptions>(options =>
            //{
            //    options.AddProfile<xdcbCommonWebModule>(validate: true);
            //});

            //Configure<RazorPagesOptions>(options =>
            //{
            //    options.Conventions.AuthorizePage("/Books/Tenants/Index", TenantManagementPermissions.Tenants.Default);
            //    options.Conventions.AuthorizePage("/TenantManagement/Tenants/CreateModal", TenantManagementPermissions.Tenants.Create);
            //    options.Conventions.AuthorizePage("/TenantManagement/Tenants/EditModal", TenantManagementPermissions.Tenants.Update);
            //    options.Conventions.AuthorizePage("/TenantManagement/Tenants/ConnectionStrings", TenantManagementPermissions.Tenants.ManageConnectionStrings);
            //});

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(CommonApplicationModule).Assembly);
            });
        }
    }
}