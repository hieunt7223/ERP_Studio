using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.HoSoCongTrinh.Constants;
using xdcb.HoSoCongTrinh.Entities;
using xdcb.HoSoCongTrinh.EntityFrameworkCore;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public class HoSoCongTrinhChiTietMucDauTuRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietMucDauTu, Guid>, IHoSoCongTrinhChiTietMucDauTuRepository
    {
        private readonly HoSoCongTrinhDbContext _db;

        public HoSoCongTrinhChiTietMucDauTuRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<List<HoSoCongTrinhChiTietMucDauTu>> GetTongMucDauTuByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.HoSoCongTrinhChiTietId)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InsertMucDauTu(HoSoCongTrinhChiTietMucDauTu model)
        {
            try
            {
                string query = Query.InsertHSCTChiTietMucDauTu;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.Id, model.CreationTime, model.HoSoCongTrinhChiTietId, model.ChiPhiDauTuId, model.SoTien, model.SoTienThamDinh, model.IsDeleted);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMucDauTu(HoSoCongTrinhChiTietMucDauTu model)
        {
            try
            {
                string query = Query.UpdateHSCTChiTietMucDauTu;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.ChiPhiDauTuId, model.SoTien, model.SoTienThamDinh, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteMucDauTu(HoSoCongTrinhChiTietMucDauTu model)
        {
            try
            {
                string query = Query.DeleteHSCTChiTietMucDauTu;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.IsDeleted, model.DeletionTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}