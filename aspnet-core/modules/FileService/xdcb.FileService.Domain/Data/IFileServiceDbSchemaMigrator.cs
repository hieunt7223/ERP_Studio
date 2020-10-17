using System.Threading.Tasks;

namespace xdcb.FileService.Data
{
    public interface IFileServiceDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}