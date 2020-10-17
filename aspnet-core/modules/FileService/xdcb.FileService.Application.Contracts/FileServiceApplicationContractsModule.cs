using Volo.Abp.Modularity;

namespace xdcb.FileService
{
    [DependsOn(
        typeof(FileServiceDomainSharedModule)
    )]
    public class FileServiceApplicationContractsModule : AbpModule
    {
    }
}