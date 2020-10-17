using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace xdcb.HoSoCongTrinh
{
    [DependsOn(
        typeof(HoSoCongTrinhApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HoSoCongTrinhHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "HoSoCongTrinh";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HoSoCongTrinhApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
