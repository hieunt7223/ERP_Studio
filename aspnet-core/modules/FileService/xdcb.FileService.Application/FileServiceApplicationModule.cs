using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;

namespace xdcb.FileService
{
    [DependsOn(
         typeof(AbpBlobStoringFileSystemModule),
        typeof(AbpBlobStoringModule),
       typeof(FileServiceDomainSharedModule),
        typeof(FileServiceApplicationContractsModule),
        typeof(FileServiceEntityFrameworkCoreModule)
   )]
    public class FileServiceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<FileServiceApplicationAutoMapperProfile>();
            });
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureDefault(container =>
                {
                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = FileServiceDBConsts.FolderSaveFile;
                    });
                });
            });
        }
    }
}