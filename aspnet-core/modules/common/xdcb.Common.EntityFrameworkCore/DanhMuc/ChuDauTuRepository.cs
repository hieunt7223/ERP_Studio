using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class ChuDauTuRepository : EfCoreRepository<CommonDbContext, ChuDauTu, Guid>, IChuDauTuRepository
    {
        public ChuDauTuRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<ChuDauTu>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<ChuDauTu> list = new PagedResultDto<ChuDauTu>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.Ten).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaSoChuong).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.DiaChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.SoDienThoai).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.Email).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.Ten).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaSoChuong).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.DiaChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.SoDienThoai).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.Email).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }

        public async Task<List<ChuDauTu>> GetListAsync()
        {
            return await GetQueryable().Where(w=>!w.IsDeleted).AsNoTracking().ToListAsync();
        }

        public async Task<List<ChuDauTu>> GetListByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
        }
    }
}