using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.EntityFrameworkCore;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public class NoiDungYeuCauRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietNoiDungYeuCau, Guid>, INoiDungYeuCauRepository
    {
        public NoiDungYeuCauRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<HoSoCongTrinhChiTietNoiDungYeuCau>> GetNoiDungYeuCausByIdAsync(Guid hoSoCongTrinhChiTietId)
        {
            return await GetQueryable().Where(s => s.HoSoCongTrinhChiTietId == hoSoCongTrinhChiTietId && !s.IsDeleted).AsNoTracking().ToListAsync();
        }
    }
}