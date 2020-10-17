using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace xdcb.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(xdcbHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class xdcbConsoleApiClientModule : AbpModule
    {
        
    }
}
