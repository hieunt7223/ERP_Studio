using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThaus
{
    public class HinhThucChonNhaThauRepository : EfCoreRepository<CommonDbContext, HinhThucChonNhaThau, Guid>, IHinhThucChonNhaThauRepository
    {
        public HinhThucChonNhaThauRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<HinhThucChonNhaThau>> GetListByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
        }

        public async Task<PagedResultDto<HinhThucChonNhaThau>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<HinhThucChonNhaThau> list = new PagedResultDto<HinhThucChonNhaThau>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenHinhThucChonNhaThau).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenHinhThucChonNhaThau).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }


    }
}