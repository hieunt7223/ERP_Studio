using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public class KhoanChiRepository : EfCoreRepository<CommonDbContext, KhoanChi, Guid>, IKhoanChiRepository
    {
        public KhoanChiRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<KhoanChi>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<KhoanChi> list = new PagedResultDto<KhoanChi>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenKhoanChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaKhoanChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.GhiChu).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenKhoanChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaKhoanChi).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.GhiChu).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}
