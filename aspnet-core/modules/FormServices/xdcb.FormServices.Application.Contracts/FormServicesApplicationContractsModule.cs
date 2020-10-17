using Volo.Abp.Modularity;

namespace xdcb.FormServices
{
    [DependsOn(
        typeof(FormServicesDomainSharedModule)
    )]
    public class FormServicesApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            FormServicesDtoExtensions.Configure();
        }
    }
}