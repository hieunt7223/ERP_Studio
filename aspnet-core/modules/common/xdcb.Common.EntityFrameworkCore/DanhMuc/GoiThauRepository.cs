using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public class GoiThauRepository : EfCoreRepository<CommonDbContext, GoiThau, Guid>, IGoiThauRepository
    {
        public GoiThauRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task DeleteByParentIdAsync(Guid id)
        {
            var item = GetQueryable().FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            if (item != null)
            {
                if (item.GoiThauParentId == null)
                {
                    var items = await GetQueryable().Where(s => s.GoiThauParentId == item.Id && !s.IsDeleted).ToListAsync();
                    DbContext.Remove(item);
                    DbContext.RemoveRange(items);
                }
                else
                {
                    DbContext.Remove(item);
                }
            }

            await DbContext.SaveChangesAsync();
        }
    }
}