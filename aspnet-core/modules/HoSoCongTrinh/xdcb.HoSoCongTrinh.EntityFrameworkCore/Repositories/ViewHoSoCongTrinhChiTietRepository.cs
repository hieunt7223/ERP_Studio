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
    public class ViewHoSoCongTrinhChiTietRepository : EfCoreRepository<HoSoCongTrinhDbContext, vHoSoCongTrinhChiTiet, Guid>, IViewHoSoCongTrinhChiTietRepository
    {
        public ViewHoSoCongTrinhChiTietRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<vHoSoCongTrinhChiTiet>> GetHoSoCongTrinhChiTietAsync(Guid congTrinhId)
        {
            return await GetQueryable().Where(s => s.CongTrinhId == congTrinhId).AsNoTracking().ToListAsync();
        }
    }
}