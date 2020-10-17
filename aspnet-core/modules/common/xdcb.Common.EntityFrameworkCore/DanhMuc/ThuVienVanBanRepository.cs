using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class ThuVienVanBanRepository : EfCoreRepository<CommonDbContext, ThuVienVanBan, Guid>, IThuVienVanBanRepository
    {
        public ThuVienVanBanRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<ThuVienVanBan>> SearchAsync(ThuVienVanBanConditionSearch condition)
        {
            PagedResultDto<ThuVienVanBan> list = new PagedResultDto<ThuVienVanBan>();
            if (condition.DenNgay != null && condition.TuNgay != null)
            {
                list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
                    (condition.keyword == "" || (condition.keyword != "" && (Common.ConvertToUnSign(w.SoKyHieu).Contains(condition.keyword) || Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword))))
                    && (condition.LoaiVanBan == null || (condition.LoaiVanBan != null && w.LoaiVanBanId == condition.LoaiVanBan))
                    && (condition.CapBanHanh == 0 || (w.CapBanHanh != 0 && (w.CapBanHanh == condition.CapBanHanh)))
                    && (condition.DonViBanHanh == null || (condition.DonViBanHanh != null && w.DonViBanHanhId == condition.DonViBanHanh))
                    && ((DateTime.Compare(w.NgayBanHanh, (DateTime)condition.TuNgay) >= 0) && (DateTime.Compare(w.NgayBanHanh, (DateTime)condition.DenNgay) <= 0))
                    && !w.IsDeleted
                ).Count();

                list.Items = await GetQueryable().Include(t => t.LoaiVanBan).Include(s => s.FileCuaThuVienVanBans).AsEnumerable().Where(w => (condition.keyword == "" || (condition.keyword != "" && (Common.ConvertToUnSign(w.SoKyHieu).Contains(condition.keyword) || Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword))))
                    && (condition.LoaiVanBan == null || (condition.LoaiVanBan != null && w.LoaiVanBanId == condition.LoaiVanBan))
                    && (condition.CapBanHanh == 0 || (w.CapBanHanh != 0 && (w.CapBanHanh == condition.CapBanHanh)))
                    && (condition.DonViBanHanh == null || (condition.DonViBanHanh != null && w.DonViBanHanhId == condition.DonViBanHanh))
                    && (DateTime.Compare(w.NgayBanHanh, (DateTime)condition.TuNgay) >= 0 && DateTime.Compare(w.NgayBanHanh, (DateTime)condition.DenNgay) <= 0)
                    && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).AsQueryable().ToListAsync();
            }
            else
            {
                list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
                    (condition.keyword == "" || (condition.keyword != "" && (Common.ConvertToUnSign(w.SoKyHieu).Contains(condition.keyword) || Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword))))
                    && (condition.LoaiVanBan == null || (condition.LoaiVanBan != null && w.LoaiVanBanId == condition.LoaiVanBan))
                    && (condition.CapBanHanh == 0 || (w.CapBanHanh != 0 && (w.CapBanHanh == condition.CapBanHanh)))
                    && (condition.DonViBanHanh == null || (condition.DonViBanHanh != null && w.DonViBanHanhId == condition.DonViBanHanh))
                    && !w.IsDeleted
               ).Count();

                list.Items = GetQueryable().Include(t => t.LoaiVanBan).Include(s => s.FileCuaThuVienVanBans).AsEnumerable()
                    .Where(w => (condition.keyword == "" || (condition.keyword != "" && (Common.ConvertToUnSign(w.SoKyHieu).Contains(condition.keyword) || Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword))))
                    && (condition.LoaiVanBan == null || (condition.LoaiVanBan != null && w.LoaiVanBanId == condition.LoaiVanBan))
                    && (condition.CapBanHanh == 0 || (w.CapBanHanh != 0 && (w.CapBanHanh == condition.CapBanHanh)))
                    && (condition.DonViBanHanh == null || (condition.DonViBanHanh != null && w.DonViBanHanhId == condition.DonViBanHanh))
                    && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).AsQueryable().ToList();
            }
            return list;
        }

        public async Task<PagedResultDto<ThuVienVanBan>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<ThuVienVanBan> list = new PagedResultDto<ThuVienVanBan>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();

            list.Items = await GetQueryable().Where(w => !w.IsDeleted).Include(t => t.LoaiVanBan).Include(s => s.FileCuaThuVienVanBans).Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<ThuVienVanBan>> GetCoSoPhapLyByIds(List<Guid> ids)
        {
            return await base.WithDetails().Include(s => s.LoaiVanBan).Include(s => s.FileCuaThuVienVanBans).Where(s => !s.IsDeleted && ids.Contains(s.Id)).AsNoTracking().ToListAsync();
        }
    }
}