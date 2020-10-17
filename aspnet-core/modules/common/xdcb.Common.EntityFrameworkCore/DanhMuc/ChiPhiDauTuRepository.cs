using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public class ChiPhiDauTuRepository : EfCoreRepository<CommonDbContext, ChiPhiDauTu, Guid>, IChiPhiDauTuRepository
    {
        public ChiPhiDauTuRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<ChiPhiDauTu>> GetListByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && ids.Contains(s.Id)).AsNoTracking().ToListAsync();
        }

        public async Task<PagedResultDto<ChiPhiDauTu>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<ChiPhiDauTu> list = new PagedResultDto<ChiPhiDauTu>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenChiPhi).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenChiPhi).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }

        public async Task<List<ChiPhiDauTu>> GetListExcludeIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && !ids.Contains(s.Id)).AsNoTracking().ToListAsync();
        }
    }
}