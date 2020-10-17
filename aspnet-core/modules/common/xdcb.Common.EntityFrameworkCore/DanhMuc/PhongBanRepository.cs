using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public class PhongBanRepository : EfCoreRepository<CommonDbContext, PhongBan, Guid>, IPhongBanRepository
    {

        public PhongBanRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<PhongBan>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<PhongBan> list = new PagedResultDto<PhongBan>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenPhongBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.SoDienThoai).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenPhongBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.SoDienThoai).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}