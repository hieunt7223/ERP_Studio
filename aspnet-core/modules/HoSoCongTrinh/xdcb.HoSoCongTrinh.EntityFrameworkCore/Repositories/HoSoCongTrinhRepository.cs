using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.HoSoCongTrinh.EntityFrameworkCore;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public class HoSoCongTrinhRepository : EfCoreRepository<HoSoCongTrinhDbContext, Entities.HoSoCongTrinh, Guid>, IHoSoCongTrinhRepository
    {
        public HoSoCongTrinhRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Entities.HoSoCongTrinh> GetEntityByIdAsync(Guid id)
        {
            return await base.WithDetails().Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietDiaDiems)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietNguonVons)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietCoSoPhapLys)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietKetQuaThamDinhs)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietCongViecs)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietGoiThaus)
                                           .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietThanhPhanHoSos).ThenInclude(s => s.HoSoCongTrinhChiTietThanhPhanHoSoFiles)
                                           .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<List<Entities.HoSoCongTrinh>> GetListAsyncByCongTrinhId(Guid congTrinhId)
        {
            return await GetQueryable().Where(s => s.CongTrinhId == congTrinhId && !s.IsDeleted)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietDiaDiems)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietNguonVons)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietCoSoPhapLys)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietKetQuaThamDinhs)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietCongViecs)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietGoiThaus)
                                       .Include(s => s.HoSoCongTrinhChiTiets).ThenInclude(s => s.HoSoCongTrinhChiTietThanhPhanHoSos).ThenInclude(s => s.HoSoCongTrinhChiTietThanhPhanHoSoFiles)
                                       .ToListAsync();
        }

        public bool IsHoSoCongTrinhByCongTrinhId(Guid Id)
        {
            var item = base.WithDetails().FirstOrDefaultAsync(s => s.CongTrinhId == Id && !s.IsDeleted);
            if (item.Result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}