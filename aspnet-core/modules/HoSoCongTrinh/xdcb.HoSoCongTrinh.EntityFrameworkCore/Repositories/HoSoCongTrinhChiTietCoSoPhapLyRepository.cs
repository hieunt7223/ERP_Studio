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
    public class HoSoCongTrinhChiTietCoSoPhapLyRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietCoSoPhapLy, Guid>, IHoSoCongTrinhChiTietCoSoPhapLyRepository
    {
        private readonly HoSoCongTrinhDbContext _db;

        public HoSoCongTrinhChiTietCoSoPhapLyRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<List<HoSoCongTrinhChiTietCoSoPhapLy>> GetCoSoPhapLyByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && ids.Contains(s.HoSoCongTrinhChiTietId)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InsertCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model)
        {
            try
            {
                string query = Query.InsertHSCTChiTietCoSoPhapLy;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.Id, model.CreationTime, model.HoSoCongTrinhChiTietId, model.ThuVienVanBanId, model.NoiDungJson, model.IsDeleted);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model)
        {
            try
            {
                string query = Query.UpdateHSCTChiTietCoSoPhapLy;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.ThuVienVanBanId, model.NoiDungJson, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model)
        {
            try
            {
                string query = Query.DeleteHSCTChiTietCoSoPhapLy;
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