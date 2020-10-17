using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSoRepository : EfCoreRepository<CommonDbContext, LoaiHoSo, Guid>, ILoaiHoSoRepository
    {
        public LoaiHoSoRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<LoaiHoSo> GetLoaiHoSoByIdAsync(Guid id)
        {
            return await base.WithDetails().Include(s => s.LoaiHoSoThanhPhanHoSos)
                                           .Include(s => s.LoaiHoSoCoSoPhapLys)
                                           .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<List<LoaiHoSo>> GetLoaiHoSoDuocApDungAsync(bool isTrangThai = true)
        {
            return await GetQueryable().Where(s => s.IsTrangThai == isTrangThai && !s.IsDeleted).ToListAsync();
        }

        public async Task<PagedResultDto<LoaiHoSo>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<LoaiHoSo> list = new PagedResultDto<LoaiHoSo>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenLoaiHoSo).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenLoaiHoSo).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }

        public async Task<List<LoaiHoSo>> GetAllAsync()
        {
            return await GetQueryable().Where(w => !w.IsDeleted).ToListAsync();
        }
    }
}