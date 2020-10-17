using System.Threading.Tasks;

namespace xdcb.Common.Data

{
    public interface ICommonDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}