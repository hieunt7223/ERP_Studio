using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.EntityFrameworkCore;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public class ViewHoSoCongTrinhRepository : EfCoreRepository<HoSoCongTrinhDbContext, vHoSoCongTrinh, Guid>, IViewHoSoCongTrinhRepository
    {
        public ViewHoSoCongTrinhRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<vHoSoCongTrinh>> GetListHoSoCongTrinhAsync(HoSoCongTrinhSearchInput condition)
        {
            var query = GetQueryable();
            if (!string.IsNullOrEmpty(condition.TenCongTrinh))
            {
                query = query.Where(s => s.TenCongTrinh.Contains(condition.TenCongTrinh));
            }

            if (Guid.Empty != (condition.ChuDauTuId ?? Guid.Empty))
            {
                query = query.Where(s => s.ChuDauTuId == condition.ChuDauTuId);
            }

            if (!string.IsNullOrEmpty(condition.NamThucHienCongTrinh))
            {
                int.TryParse(condition.NamThucHienCongTrinh, out int namThucHien);
                query = query.Where(s => namThucHien >= s.ThoiGianThucHienTuNgay.Value.Year && namThucHien <= s.ThoiGianThucHienDenNgay.Value.Year);
            }

            if (condition.TrangThaiHoSo > 0)
            {
                query = query.Where(s => s.TrangThai == condition.TrangThaiHoSo);
            }

            if (Guid.Empty != (condition.LoaiHoSoId ?? Guid.Empty))
            {
                query = query.Where(s => s.LoaiHoSoId == condition.LoaiHoSoId);
            }

            var ids = await query.Select(s => s.Id)
                                 .Distinct()
                                 .OrderBy(s => s)
                                 .Skip(condition.Skip).Take(condition.Take)
                                 .ToListAsync();

            return await query.Where(s => ids.Contains(s.Id)).ToListAsync();
        }

        public async Task<int> CountAsync(HoSoCongTrinhSearchInput condition)
        {
            var query = GetQueryable();
            if (!string.IsNullOrEmpty(condition.TenCongTrinh))
            {
                query = query.Where(s => s.TenCongTrinh.Contains(condition.TenCongTrinh));
            }

            if (Guid.Empty != (condition.ChuDauTuId ?? Guid.Empty))
            {
                query = query.Where(s => s.ChuDauTuId == condition.ChuDauTuId);
            }

            if (!string.IsNullOrEmpty(condition.NamThucHienCongTrinh))
            {
                int.TryParse(condition.NamThucHienCongTrinh, out int namThucHien);
                query = query.Where(s => namThucHien >= s.ThoiGianThucHienTuNgay.Value.Year && namThucHien <= s.ThoiGianThucHienDenNgay.Value.Year);
            }

            if (condition.TrangThaiHoSo > 0)
            {
                query = query.Where(s => s.TrangThai == condition.TrangThaiHoSo);
            }

            if (Guid.Empty != (condition.LoaiHoSoId ?? Guid.Empty))
            {
                query = query.Where(s => s.LoaiHoSoId == condition.LoaiHoSoId);
            }

            return await query.Select(s => s.Id).Distinct().CountAsync();
        }
    }
}