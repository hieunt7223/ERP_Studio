using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace xdcb.FileService
{
    [DependsOn(
          typeof(AbpAutofacModule),
        typeof(FileServiceDomainSharedModule),
        typeof(FileServiceApplicationModule),
        typeof(FileServiceApplicationContractsModule),
        typeof(FileServiceEntityFrameworkCoreModule)
        )]
    public class xdcbFileServiceWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(typeof(AbpTenantManagementResource), typeof(AbpTenantManagementWebModule).Assembly);
            //});

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(xdcbFileServiceWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new xdcbFileServiceMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<xdcbFileServiceWebModule>("xdcb.FileService.Web");
            });

            //context.Services.AddAutoMapperObjectMapper<xdcbFileServiceWebModule>();
            //Configure<AbpAutoMapperOptions>(options =>
            //{
            //    options.AddProfile<xdcbFileServiceWebModule>(validate: true);
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
                options.ConventionalControllers.Create(typeof(FileServiceApplicationModule).Assembly);
            });
        }
    }
}