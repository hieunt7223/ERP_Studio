using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class CongTrinhRepository : EfCoreRepository<CommonDbContext, CongTrinh, Guid>, ICongTrinhRepository
    {
        public CongTrinhRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }

        public async Task<CongTrinh> GetCongTrinhByIdAsync(Guid id)
        {
            return await base.WithDetails().Include(s => s.DiaDiemXayDungs)
                                            .Include(s => s.ChuDauTu)
                                            .Include(s => s.LoaiCongTrinh)
                                            .Include(s => s.NhomCongTrinh)
                                            .Include(s => s.LoaiKhoan)
                                            .Include(s=> s.ChuongTrinhMucTieuQuocGia)
                                           .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task DeleleDiaDiemXayDungByCongTrinhId(Guid CongTrinhId)
        {

            var listDelete = base.DbContext.DiaDiemXayDungs.Where(x => x.CongTrinhId == CongTrinhId);
            if (listDelete != null && listDelete.Count() > 0)
            {
                base.DbContext.DiaDiemXayDungs.RemoveRange(listDelete);
                base.DbContext.SaveChanges();
            }
        }

        public async Task<CongTrinh> SaveDiaDiemXayDung(CongTrinh congTrinh)
        {
            if (congTrinh != null && congTrinh.DiaDiemXayDungs.Count > 0)
            {
                base.DbContext.DiaDiemXayDungs.AddRange(congTrinh.DiaDiemXayDungs);
                base.DbContext.SaveChanges();
            }
            return congTrinh;
        }

        public async Task<PagedResultDto<CongTrinh>> SearchAsync(CongTrinhConditionSearch condition)
        {
            PagedResultDto<CongTrinh> list = new PagedResultDto<CongTrinh>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenCongTrinh).Contains(condition.keyword)
                                                            && (condition.chuDauTu == null || (condition.chuDauTu != null && condition.chuDauTu == w.ChuDauTuId))
                                                            && (condition.nhomCongTrinh == null || (condition.nhomCongTrinh != null && condition.nhomCongTrinh == w.NhomCongTrinhId))
                                                            && !w.IsDeleted).Count();
            list.Items = GetQueryable().Include(x => x.ChuDauTu).Include(x => x.LoaiCongTrinh).Include(x => x.NhomCongTrinh).Include(x => x.LoaiKhoan)
                                                        .AsEnumerable().Where(w => Common.ConvertToUnSign(w.TenCongTrinh).Contains(condition.keyword)
                                                       && (condition.chuDauTu == null || (condition.chuDauTu != null && condition.chuDauTu == w.ChuDauTuId))
                                                       && (condition.nhomCongTrinh == null || (condition.nhomCongTrinh != null && condition.nhomCongTrinh == w.NhomCongTrinhId))
                                                       && !w.IsDeleted).OrderByDescending(x=>x.CreationTime).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();
            return list;
        }

        public bool IsMaExist(string ma,Guid id)
        {
            if (id == null)
            {
                id = new Guid();
            }
            var item = GetQueryable().Where(x => x.Id != id && string.Compare(x.MaCongTrinh.ToLower(), ma.ToLower()) == 0 && !x.IsDeleted).FirstOrDefault();
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNameExist(string name,Guid id)
        {
            if (id == null)
            {
                id = new Guid();
            }
            var item = GetQueryable().Where(x =>x.Id!=id && string.Compare(x.TenCongTrinh.ToLower(), name.ToLower()) == 0 && !x.IsDeleted).FirstOrDefault();
            if (item != null)
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