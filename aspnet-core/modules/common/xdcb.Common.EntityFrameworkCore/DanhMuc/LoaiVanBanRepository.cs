using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public class LoaiVanBanRepository : EfCoreRepository<CommonDbContext, LoaiVanBan, Guid>, ILoaiVanBanRepository
    {
        public LoaiVanBanRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<LoaiVanBan>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<LoaiVanBan> list = new PagedResultDto<LoaiVanBan>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLoaiVanBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaLoaiVanBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLoaiVanBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaLoaiVanBan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }

        public IQueryable<LoaiVanBan> GetList()
        {
            return GetQueryable().Where(w=>!w.IsDeleted).AsQueryable();
        }
    }
}