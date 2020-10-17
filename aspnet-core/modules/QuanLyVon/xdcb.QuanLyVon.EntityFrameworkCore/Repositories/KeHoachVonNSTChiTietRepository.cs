using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.KeHoachVonNSTChiTiets
{
    public class KeHoachVonNSTChiTietRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachVonNSTChiTiet, Guid>, IKeHoachVonNSTChiTietRepository
    {
        public KeHoachVonNSTChiTietRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public async Task<List<KeHoachVonNSTChiTiet>> GetDataLuyKeByNam(int nam)
        {
            List<KeHoachVonNSTChiTiet> list = new List<KeHoachVonNSTChiTiet>();
            Guid KeHoachVonNSTId = (from v in base.DbContext.KeHoachVonNST
                                    where v.Nam == nam
                                      && v.IsDeleted == false
                                    select v.Id).FirstOrDefault();
            if (KeHoachVonNSTId == null)
            {
                KeHoachVonNSTId = Guid.Empty;
            }

           

            var KHVQuery = (from ct in base.DbContext.KeHoachVonNSTChiTiet
                            join v in base.DbContext.KeHoachVonNST on ct.KeHoachVonNSTId equals v.Id
                            where v.Id == KeHoachVonNSTId
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
                                v.TrangThaiDieuChinh,
                                v.Nam
                            }
                        ).ToList();

            var TotalQuery = KHVQuery.Where(v => v.Nam <= nam).ToList();
                

            if (TotalQuery != null && TotalQuery.Count > 0)
            {
                List<Guid> listCongtrinh = TotalQuery.Select(x => x.CongTrinhId).Distinct().ToList();
                listCongtrinh.ForEach( o =>
                {
                    KeHoachVonNSTChiTiet obj = new KeHoachVonNSTChiTiet();
                    obj.CongTrinhId = o;

                    //Tính lũy kế vốn tổng số
                    decimal totalDauNam = 0;
                    decimal totalDieuChinh = 0;
                    var listKHV =  TotalQuery.Where(x =>  x.IsSelectDieuChinh == false
                                           && x.CongTrinhId == o).ToList();
                    totalDauNam = listKHV.Sum(x => x.KeHoachVonDauNamDuocDuyet);

                    totalDieuChinh = listKHV.Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                    obj.LuyKeVonTongCong = totalDauNam + totalDieuChinh;

                    //Tính lũy kế vốn năm trước
                    if (KHVQuery != null && KHVQuery.Count > 0)
                    {
                        decimal vonDauNam = 0;
                        decimal vonDieuChinh = 0;
                        listKHV = KHVQuery.Where(x=>
                                        x.IsSelectDieuChinh == false
                                        && x.CongTrinhId == o).ToList();
                        vonDauNam = listKHV.Sum(x => x.KeHoachVonDauNamDuocDuyet);

                        vonDieuChinh = listKHV.Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                        obj.LuyKeVonNamTruoc = vonDauNam + vonDieuChinh;
                    }
                    list.Add(obj);
                });
            }
            return list;

        }
    }
}
