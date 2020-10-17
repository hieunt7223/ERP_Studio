using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.FormServices.EntityFrameworkCore;

namespace xdcb.FormServices.ConfigColumns
{
    public class ConfigColumnRepository : EfCoreRepository<FormServicesDbContext, ConfigColumn, int>, IConfigColumnRepository
    {
        public ConfigColumnRepository(IDbContextProvider<FormServicesDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}