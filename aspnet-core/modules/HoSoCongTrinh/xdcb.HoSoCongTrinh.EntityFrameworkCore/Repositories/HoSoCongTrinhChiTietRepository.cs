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
using Mapster;
using xdcb.HoSoCongTrinh.Dtos.HoSoCongTrinh;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public class HoSoCongTrinhChiTietRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTiet, Guid>, IHoSoCongTrinhChiTietRepository
    {
        private readonly HoSoCongTrinhDbContext _db;

        public HoSoCongTrinhChiTietRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<HoSoCongTrinhChiTiet> InsertHoSoCongTrinhChiTiet(HoSoCongTrinhChiTiet model)
        {
            try
            {
                var result = await this.InsertAsync(model);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateHoSoCongTrinhChiTiet(HoSoCongTrinhChiTiet model)
        {
            try
            {
                string query = Query.UpdateHoSoCongTrinhChiTiet;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, (int)model.TrangThai, model.SoLanDieuChinh, model.SuCanThietDauTu, model.QuyMoDauTu, model.NguonVonDauTu, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}