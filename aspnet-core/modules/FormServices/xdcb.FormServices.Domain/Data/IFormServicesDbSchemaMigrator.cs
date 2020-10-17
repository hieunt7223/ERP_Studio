using System.Threading.Tasks;

namespace xdcb.FormServices.Data
{
    public interface IFormServicesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}