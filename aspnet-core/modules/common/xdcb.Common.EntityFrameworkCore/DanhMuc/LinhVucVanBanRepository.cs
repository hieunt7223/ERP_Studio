using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public class LinhVucVanBanRepository : EfCoreRepository<CommonDbContext, LinhVucVanBan, Guid>, ILinhVucVanBanRepository
    {
        public LinhVucVanBanRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<LinhVucVanBan>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<LinhVucVanBan> list = new PagedResultDto<LinhVucVanBan>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLinhVuc).Contains(condition.keyword) 
            || Common.ConvertToUnSign(w.MaLinhVuc).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w => 
            (Common.ConvertToUnSign(w.TenLinhVuc).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MaLinhVuc).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
        /// <summary>
        /// get tất cả lĩnh vực văn bản
        /// </summary>
        /// <returns></returns>
        public async Task<IList<LinhVucVanBan>> GetListAsync()
        {
            return await GetQueryable().Where(w=> !w.IsDeleted).ToListAsync();
        }
    }
}