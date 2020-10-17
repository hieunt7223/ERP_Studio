using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;

namespace xdcb
{
    [DependsOn(
        typeof(xdcbApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
        )]
    public class xdcbHttpApiModule : AbpModule
    {
        
    }
}
