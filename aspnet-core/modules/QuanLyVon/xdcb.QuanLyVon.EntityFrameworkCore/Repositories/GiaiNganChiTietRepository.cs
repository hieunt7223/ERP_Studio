using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.GiaiNganChiTiets
{
    /// <summary>
    /// Generated Repositories for Table : GiaiNganChiTiet.
    /// </summary>
    public class GiaiNganChiTietRepository : EfCoreRepository<QuanLyVonDbContext, GiaiNganChiTiet, Guid>, IGiaiNganChiTietRepository
    {
        public GiaiNganChiTietRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<List<GiaiNganChiTiet>> GetDataIsNew(int nam, Guid chuDauTuId)
        {
            List<GiaiNganChiTiet> list = new List<GiaiNganChiTiet>();
            var query = (from v in base.DbContext.vKeHoachVon
                         where v.Nam == nam
                             && v.ChuDauTuId == chuDauTuId
                         select v).ToList();
            if (query != null || query.Count() != 0)
            {
                query.Where(x => x.KeHoachVonNSTChiTietId != null && x.KeHoachVonNSTChiTietId != Guid.Empty).ToList().ForEach(o =>
                  {
                      GiaiNganChiTiet obj = new GiaiNganChiTiet();
                      obj.CongTrinhId = o.CongTrinhId;
                      obj.KeHoachVonNSTChiTietId = o.KeHoachVonNSTChiTietId == null ? Guid.Empty : new Guid(o.KeHoachVonNSTChiTietId.ToString());
                      obj.KeHoachVonNamNayNST = o.KeHoachVon;
                      list.Add(obj);
                  });
                query.Where(x => x.KeHoachVonNSTWChiTietId != null && x.KeHoachVonNSTWChiTietId != Guid.Empty).ToList().ForEach(o =>
                {
                    GiaiNganChiTiet obj = new GiaiNganChiTiet();
                    if (list.Where(x => x.CongTrinhId == o.CongTrinhId).Count() > 0)
                    {
                        obj = list.Where(x => x.CongTrinhId == o.CongTrinhId).FirstOrDefault();
                        obj.KeHoachVonNSTWChiTietId = o.KeHoachVonNSTWChiTietId == null ? Guid.Empty : new Guid(o.KeHoachVonNSTWChiTietId.ToString());
                        obj.KeHoachVonNamNayNSTW = o.KeHoachVon;
                    }
                    else
                    {
                        obj.CongTrinhId = o.CongTrinhId;
                        obj.KeHoachVonNSTWChiTietId = o.KeHoachVonNSTWChiTietId == null ? Guid.Empty : new Guid(o.KeHoachVonNSTWChiTietId.ToString());
                        obj.KeHoachVonNamNayNSTW = o.KeHoachVon;
                        list.Add(obj);
                    }
                });
            }
            return list;
        }

        public async Task<List<GiaiNganChiTiet>> GetDataDetailForTongHop(int nam, string tenkehoach, int? quyThang, bool? isKeHoachKeoDai, Guid congTrinhId)
        {
            var query = (from ct in base.DbContext.GiaiNganChiTiet
                         join v in base.DbContext.GiaiNgan on ct.GiaiNganId equals v.Id
                         where v.Nam == nam
                           && v.TenKeHoach == tenkehoach
                           && v.QuyThang == quyThang
                           && v.TrangThai != "DANG_SOAN"
                           && (quyThang == null || v.QuyThang == quyThang)
                           && (isKeHoachKeoDai == null || v.IsKeHoachKeoDai == isKeHoachKeoDai)
                           && (congTrinhId == Guid.Empty || ct.CongTrinhId == congTrinhId)
                           && ct.IsDeleted == false
                           && v.IsDeleted == false
                         select ct
                    ).ToList();
            return query;
        }
    }
}
