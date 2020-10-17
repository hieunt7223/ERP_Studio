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
    public class HoSoCongTrinhChiTietThanhPhanHoSoRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietThanhPhanHoSo, Guid>, IHoSoCongTrinhChiTietThanhPhanHoSoRepository
    {
        private readonly HoSoCongTrinhDbContext _db;

        public HoSoCongTrinhChiTietThanhPhanHoSoRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<List<HoSoCongTrinhChiTietThanhPhanHoSo>> GetThanhPhanHoSosByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => ids.Contains(s.HoSoCongTrinhChiTietId)).Include(s=>s.HoSoCongTrinhChiTietThanhPhanHoSoFiles).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InsertThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model)
        {
            try
            {
                string query = Query.InsertHSCTChiTietThanhPhanHoSo;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.Id, model.CreationTime, model.HoSoCongTrinhChiTietId, model.ThanhPhanHoSoId, model.IsDeleted);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model)
        {
            try
            {
                string query = Query.UpdateHSCTChiTietThanhPhanHoSo;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.ThanhPhanHoSoId, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model)
        {
            try
            {
                string query = Query.DeleteHSCTChiTietThanhPhanHoSo;
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