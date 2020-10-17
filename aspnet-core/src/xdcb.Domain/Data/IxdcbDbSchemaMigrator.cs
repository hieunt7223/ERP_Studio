using System.Threading.Tasks;

namespace xdcb.Data
{
    public interface IxdcbDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
