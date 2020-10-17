using System.Threading.Tasks;

namespace xdcb.QuanLyVon.Data
{
    public interface IQuanLyVonDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}