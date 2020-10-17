using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public class PhuongThucDauThauRepository : EfCoreRepository<CommonDbContext, PhuongThucDauThau, Guid>, IPhuongThucDauThauRepository
    {
        public PhuongThucDauThauRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<List<PhuongThucDauThau>> GetListByIds(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
        }

        public async Task<PagedResultDto<PhuongThucDauThau>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<PhuongThucDauThau> list = new PagedResultDto<PhuongThucDauThau>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenPhuongThucDauThau).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenPhuongThucDauThau).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}