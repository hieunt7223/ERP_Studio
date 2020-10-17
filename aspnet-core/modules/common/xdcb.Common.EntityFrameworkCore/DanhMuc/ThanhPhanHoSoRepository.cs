using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public class ThanhPhanHoSoRepository : EfCoreRepository<CommonDbContext, ThanhPhanHoSo, Guid>, IThanhPhanHoSoRepository
    {
        public ThanhPhanHoSoRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<ThanhPhanHoSo>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<ThanhPhanHoSo> list = new PagedResultDto<ThanhPhanHoSo>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenThanhPhanHoSo).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenThanhPhanHoSo).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }

        public async Task<PagedResultDto<ThanhPhanHoSo>> GetThanhPhanHoSoList(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<ThanhPhanHoSo> list = new PagedResultDto<ThanhPhanHoSo>();
            list.TotalCount = await GetQueryable().CountAsync();
            list.Items = await GetQueryable().Where(w=>!w.IsDeleted).Include(t => t.LoaiVanBan).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return list;
        }

        public async Task<List<ThanhPhanHoSo>> GetThanhPhanHoSoByIds(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && ids.Contains(s.Id)).Include(s => s.LoaiVanBan).AsNoTracking().ToListAsync();
        }

        public async Task<ThanhPhanHoSo> IsByThanhPhanHoSoAsync(Guid id)
        {
            return await GetQueryable().FirstOrDefaultAsync(s => !s.IsDeleted && s.LoaiVanBanId == id);
        }

        public async Task<List<ThanhPhanHoSo>> GetThanhPhanHoSosAsync()
        {
            return await GetQueryable().Where(s => !s.IsDeleted).Include(s=>s.LoaiVanBan).AsNoTracking().ToListAsync();
        }

        public async Task<List<ThanhPhanHoSo>> GetThanhPhanHoSoByLoaiVanBanIdAsync(Guid id)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && s.LoaiVanBanId == id).AsNoTracking().ToListAsync();
        }
    }
}