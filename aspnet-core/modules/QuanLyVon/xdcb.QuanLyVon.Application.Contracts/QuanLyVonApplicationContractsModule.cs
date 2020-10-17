using Volo.Abp.Modularity;

namespace xdcb.QuanLyVon
{
    [DependsOn(
        typeof(QuanLyVonDomainSharedModule)
    )]
    public class QuanLyVonApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            QuanLyVonDtoExtensions.Configure();
        }
    }
}