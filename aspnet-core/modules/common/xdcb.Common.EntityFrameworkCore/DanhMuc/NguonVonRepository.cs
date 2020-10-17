using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public class NguonVonRepository : EfCoreRepository<CommonDbContext, NguonVon, Guid>, INguonVonRepository
    {
        public NguonVonRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<List<NguonVon>> GetAllAsync()
        {
            return await GetQueryable().Where(w=>!w.IsDeleted).OrderBy(x => x.OrderIndex).ToListAsync();
        }

        public async Task<List<NguonVon>> GetListExcludeIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && !ids.Contains(s.Id)).AsNoTracking().ToListAsync();
        }

        public async Task<List<NguonVon>> SearchAsync(string keyword)
        {
            return GetQueryable().AsEnumerable().Where(w =>
            Common.ConvertToUnSign(w.TenNguonVon).Contains(keyword) && !w.IsDeleted
            ).OrderBy(x => x.OrderIndex).ToList();
        }
        /// <summary>
        /// get các id con của nguồn vốn bị xóa
        /// </summary>
        /// <param name="id">id nguồn vốn</param>
        /// <returns></returns>
        public async Task<List<Guid>> GetChildIdAsync(Guid id)
        {
            return await GetQueryable().Where(w => w.ParentId == id && !w.IsDeleted).Select(w => w.Id).ToListAsync();
        }

        public async Task<List<NguonVon>> GetNguonVonsByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.Id) && !s.IsDeleted).ToListAsync();
        }
    }
}