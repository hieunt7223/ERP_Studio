using System.Threading.Tasks;

namespace xdcb.HoSoCongTrinh.Data
{
    public interface IHoSoCongTrinhDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}