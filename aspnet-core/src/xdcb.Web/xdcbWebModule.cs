using Abp.AspNetCore.Mvc.UI.Theme.AdminLTE;
using Abp.AspNetCore.Mvc.UI.Theme.AdminLTE.Bundling;
using EasyAbp.Abp.SettingUi;
using EasyAbp.Abp.SettingUi.Web;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using xdcb.Common;
using xdcb.EntityFrameworkCore;
using xdcb.FileService;
using xdcb.HoSoCongTrinh.Web;
using xdcb.Localization;
using xdcb.MultiTenancy;
using xdcb.Web.Bundling;
using xdcb.Web.Menus;
using xdcb.FormServices;
using xdcb.QuanLyVon;
namespace xdcb.Web
{
    [DependsOn(
        typeof(xdcbHttpApiModule),
        typeof(xdcbApplicationModule),
        typeof(xdcbEntityFrameworkCoreDbMigrationsModule),
        typeof(xdcbCommonWebModule),
        typeof(HoSoCongTrinhWebModule),
        typeof(xdcbFileServiceWebModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiAdminLTEThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(SettingUiWebModule)
        )]
    public class xdcbWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(xdcbResource),
                    typeof(xdcbDomainModule).Assembly,
                    typeof(xdcbDomainSharedModule).Assembly,
                    typeof(xdcbApplicationModule).Assembly,
                    typeof(xdcbApplicationContractsModule).Assembly,
                    typeof(CommonDomainSharedModule).Assembly,
                    typeof(FileServiceDomainSharedModule).Assembly,
                    typeof(xdcbWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);

            Configure<AbpBundlingOptions>(options =>
            {
                //Styles bundle
                options
                    .StyleBundles.Get(AdminLTEThemeBundles.Styles.Global).Contributors
                    .Replace<AdminThemeGlobalStyleContributor, StyleBundleContributor>();

                //Scripts bundle
                options
                    .ScriptBundles
                        .Add(AdminLTEThemeBundles.HeaderScripts.Global, bundle =>
                            {
                                bundle.AddContributors(typeof(HeaderScriptBundleContributor));
                            })
                        .Get(AdminLTEThemeBundles.Scripts.Global)
                            .Contributors.Replace<AdminLTEThemeGlobalScriptContributor, ScriptBundleContributor>();
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "xdcb";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<xdcbWebModule>();

            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            var sc = Path.DirectorySeparatorChar;
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{sc}xdcb.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{sc}xdcb.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{sc}xdcb.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{sc}xdcb.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbCommonWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, $@"..{sc}..{sc}modules{sc}common{sc}xdcb.Common.Web"));
                    options.FileSets.ReplaceEmbeddedByPhysical<HoSoCongTrinhWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, $@"..{sc}..{sc}modules{sc}HoSoCongTrinh{sc}xdcb.HoSoCongTrinh.Web"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpAspNetCoreMvcUiAdminLTEThemeModule>(Path.Combine(hostingEnvironment.ContentRootPath, $@"..{sc}..{sc}themes{sc}theme{sc}Abp.AspNetCore.Mvc.UI.Theme.AdminLTE"));
                    options.FileSets.ReplaceEmbeddedByPhysical<xdcbWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<xdcbResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("vi", "vi", "Tiếng Việt"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new xdcbMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(xdcbApplicationModule).Assembly);
                options.ConventionalControllers.Create(typeof(SettingUiApplicationModule).Assembly);
                options.ConventionalControllers.Create(typeof(FormServicesApplicationModule).Assembly);
                options.ConventionalControllers.Create(typeof(QuanLyVonApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "xdcb API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "xdcb API");
            });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
