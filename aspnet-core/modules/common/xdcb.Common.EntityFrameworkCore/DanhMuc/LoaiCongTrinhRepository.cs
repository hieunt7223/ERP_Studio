using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public class LoaiCongTrinhRepository : EfCoreRepository<CommonDbContext, LoaiCongTrinh, Guid>, ILoaiCongTrinhRepository
    {

        public LoaiCongTrinhRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<List<LoaiCongTrinh>> GetLoaiCongTrinhsAsync()
        {
            return await GetQueryable().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<PagedResultDto<LoaiCongTrinh>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<LoaiCongTrinh> list = new PagedResultDto<LoaiCongTrinh>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLoaiCongTrinh).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLoaiCongTrinh).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}