using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public class ChucVuRepository : EfCoreRepository<CommonDbContext, ChucVu, Guid>, IChucVuRepository
    {
        public ChucVuRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<ChucVu>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<ChucVu> list = new PagedResultDto<ChucVu>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenChucVu).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaChucVu).Contains(condition.keyword) ) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenChucVu).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaChucVu).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}