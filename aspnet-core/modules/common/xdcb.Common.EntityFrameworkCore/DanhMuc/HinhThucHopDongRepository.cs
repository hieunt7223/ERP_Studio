using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.HinhThucHopDongs
{
    public class HinhThucHopDongRepository : EfCoreRepository<CommonDbContext, HinhThucHopDong, Guid>, IHinhThucHopDongRepository
    {
        public HinhThucHopDongRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<HinhThucHopDong>> GetListByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).AsNoTracking().ToListAsync();
        }

        public bool IsNameExist(string name, Guid id)
        {
            var item = GetQueryable().Where(x => x.Id != id && string.Compare(x.TenHinhThucHopDong.ToLower(), name.ToLower()) == 0 && !x.IsDeleted).FirstOrDefault();
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PagedResultDto<HinhThucHopDong>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<HinhThucHopDong> list = new PagedResultDto<HinhThucHopDong>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenHinhThucHopDong).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenHinhThucHopDong).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}