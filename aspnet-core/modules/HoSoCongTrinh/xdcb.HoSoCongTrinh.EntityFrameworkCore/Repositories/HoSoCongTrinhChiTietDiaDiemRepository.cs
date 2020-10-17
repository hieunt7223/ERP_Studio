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
    public class HoSoCongTrinhChiTietDiaDiemRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietDiaDiem, Guid>, IHoSoCongTrinhChiTietDiaDiemRepository
    {
        private readonly HoSoCongTrinhDbContext _db;
        public HoSoCongTrinhChiTietDiaDiemRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<List<HoSoCongTrinhChiTietDiaDiem>> GetDiaDiemByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.HoSoCongTrinhChiTietId)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InsertDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model)
        {
            try
            {
                string query = Query.InsertHSCTChiTietDiaDiem;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.Id, model.CreationTime, model.HoSoCongTrinhChiTietId, model.DonViHanhChinhId, model.GhiChu, model.IsDeleted);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model)
        {
            try
            {
                string query = Query.UpdateHSCTChiTietDiaDiem;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.GhiChu, model.DonViHanhChinhId, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model)
        {
            try
            {
                string query = Query.DeleteHSCTChiTietDiaDiem;
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