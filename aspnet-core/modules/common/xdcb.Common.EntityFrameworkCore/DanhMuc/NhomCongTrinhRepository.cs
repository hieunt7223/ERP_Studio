using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public class NhomCongTrinhRepository : EfCoreRepository<CommonDbContext, NhomCongTrinh, Guid>, INhomCongTrinhRepository
    {

        public NhomCongTrinhRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<NhomCongTrinh>> GetNhomCongTrinhsAsync()
        {
            return await GetQueryable().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<PagedResultDto<NhomCongTrinh>> SearchAsync(ConditionSearch condition)
        {

            PagedResultDto<NhomCongTrinh> list = new PagedResultDto<NhomCongTrinh>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenNhomCongTrinh).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenNhomCongTrinh).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}