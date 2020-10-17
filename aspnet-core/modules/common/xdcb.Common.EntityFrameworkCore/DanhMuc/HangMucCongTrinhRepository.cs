using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public class HangMucCongTrinhRepository : EfCoreRepository<CommonDbContext, HangMucCongTrinh, Guid>, IHangMucCongTrinhRepository
    {
        private readonly CommonDbContext _context;

        public HangMucCongTrinhRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
            _context = context;
        }

        public async Task<PagedResultDto<HangMucCongTrinh>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<HangMucCongTrinh> list = new PagedResultDto<HangMucCongTrinh>();
            list.TotalCount = await _context.HangMucCongTrinhs.Where(w => w.TenHangMuc.Contains(condition.keyword)).CountAsync();
            list.Items = await _context.HangMucCongTrinhs.Where(w => w.TenHangMuc.Contains(condition.keyword)).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToListAsync();

            return list;
        }
    }
}