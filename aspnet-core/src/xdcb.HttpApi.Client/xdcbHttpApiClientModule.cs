using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using xdcb.FormServices;
using xdcb.QuanLyVon;

namespace xdcb
{
    [DependsOn(
        typeof(xdcbApplicationContractsModule),
        typeof(FormServicesApplicationContractsModule),
        typeof(QuanLyVonApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule)
    )]
    public class xdcbHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(xdcbApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            context.Services.AddHttpClientProxies(
                typeof(FormServicesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            context.Services.AddHttpClientProxies(
                typeof(QuanLyVonApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
