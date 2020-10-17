using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachVonNQChiTiets
{
    /// <summary>
    /// Generated Repositories for Table : KeHoachVonNQChiTiet.
    /// </summary>
    public class KeHoachVonNQChiTietRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachVonNQChiTiet, Guid>, IKeHoachVonNQChiTietRepository
    {
        public KeHoachVonNQChiTietRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public async Task<List<KeHoachVonNQChiTiet>> GetDataLuyKeByNam(int nam)
        {
            List<KeHoachVonNQChiTiet> list = new List<KeHoachVonNQChiTiet>();
            Guid KeHoachVonNQId = (from v in base.DbContext.KeHoachVonNQ
                                   where v.Nam == nam
                                     && v.IsDeleted == false
                                   select v.Id).ToList().FirstOrDefault();
            if (KeHoachVonNQId == null)
            {
                KeHoachVonNQId = Guid.Empty;
            }

            var TotalQuery = (from ct in base.DbContext.KeHoachVonNQChiTiet
                              join v in base.DbContext.KeHoachVonNQ on ct.KeHoachVonNQId equals v.Id
                              where v.Nam <= nam
                                && ct.IsDeleted == false
                                && v.IsDeleted == false
                              select new
                              {
                                  ct.KeHoachVonDauNamDuocDuyet,
                                  ct.KeHoachVonDieuChinhDuocDuyet,
                                  ct.IsDeleteDieuChinh,
                                  ct.IsSelectDieuChinh,
                                  ct.CongTrinhId,
                                  v.TrangThaiDauNam,
                                  v.TrangThaiDieuChinh
                              }
                    ).ToList();

            var KHVQuery = (from ct in base.DbContext.KeHoachVonNQChiTiet
                            join v in base.DbContext.KeHoachVonNQ on ct.KeHoachVonNQId equals v.Id
                            where v.Id == KeHoachVonNQId
                                && ct.IsDeleted == false
                                && v.IsDeleted == false
                            select new
                            {
                                ct.KeHoachVonDauNamDuocDuyet,
                                ct.KeHoachVonDieuChinhDuocDuyet,
                                ct.IsDeleteDieuChinh,
                                ct.IsSelectDieuChinh,
                                ct.CongTrinhId,
                                v.TrangThaiDauNam,
                                v.TrangThaiDieuChinh
                            }
                        ).ToList();

            if (TotalQuery != null && TotalQuery.Count > 0)
            {
                List<Guid> listCongtrinh = TotalQuery.Select(x => x.CongTrinhId).Distinct().ToList();
                listCongtrinh.ForEach(o =>
                {
                    KeHoachVonNQChiTiet obj = new KeHoachVonNQChiTiet();
                    obj.CongTrinhId = o;

                    //Tính lũy kế vốn tổng số
                    decimal totalDauNam = 0;
                    decimal totalDieuChinh = 0;
                    totalDauNam = TotalQuery.Where(x => string.IsNullOrEmpty(x.TrangThaiDieuChinh)
                                         && x.IsSelectDieuChinh == false
                                         && x.CongTrinhId == o).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);

                    totalDieuChinh = TotalQuery.Where(x => !string.IsNullOrEmpty(x.TrangThaiDieuChinh)
                                          && x.IsDeleteDieuChinh == false
                                          && x.CongTrinhId == o).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                    obj.LuyKeVonTongCong = totalDauNam + totalDieuChinh;

                    //Tính lũy kế vốn năm trước
                    if (KHVQuery != null && KHVQuery.Count > 0)
                    {
                        decimal vonDauNam = 0;
                        decimal vonDieuChinh = 0;
                        vonDauNam = KHVQuery.Where(x => string.IsNullOrEmpty(x.TrangThaiDieuChinh)
                                        && x.IsSelectDieuChinh == false
                                        && x.CongTrinhId == o).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);

                        vonDieuChinh = KHVQuery.Where(x => !string.IsNullOrEmpty(x.TrangThaiDieuChinh)
                                              && x.IsDeleteDieuChinh == false
                                              && x.CongTrinhId == o).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                        obj.LuyKeVonNamTruoc = vonDauNam + vonDieuChinh;
                    }
                    list.Add(obj);
                });
            }
            return list;
        }
    }
}
