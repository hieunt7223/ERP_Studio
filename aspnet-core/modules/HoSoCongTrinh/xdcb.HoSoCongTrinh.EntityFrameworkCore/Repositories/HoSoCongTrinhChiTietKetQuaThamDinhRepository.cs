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
    public class HoSoCongTrinhChiTietKetQuaThamDinhRepository : EfCoreRepository<HoSoCongTrinhDbContext, HoSoCongTrinhChiTietKetQuaThamDinh, Guid>, IHoSoCongTrinhChiTietKetQuaThamDinhRepository
    {
        private readonly HoSoCongTrinhDbContext _db;

        public HoSoCongTrinhChiTietKetQuaThamDinhRepository(IDbContextProvider<HoSoCongTrinhDbContext> dbContextProvider, HoSoCongTrinhDbContext db) : base(dbContextProvider)
        {
            _db = db;
        }

        public async Task<List<HoSoCongTrinhChiTietKetQuaThamDinh>> GetKetQuaThamDinhByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(s => !s.IsDeleted && ids.Contains(s.HoSoCongTrinhChiTietId)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InsertKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model)
        {
            try
            {
                string query = Query.InsertHSCTChiTietKetQuaThamDinh;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.Id, model.CreationTime, model.HoSoCongTrinhChiTietId, model.FileId, model.IsDeleted);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model)
        {
            try
            {
                string query = Query.UpdateHSCTChiTietKetQuaThamDinh;
                int noOfRowUpdated = _db.Database.ExecuteSqlCommand(query, model.FileId, model.LastModificationTime, model.Id);
                _db.SaveChanges();
                return noOfRowUpdated > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model)
        {
            try
            {
                string query = Query.DeleteHSCTChiTietKetQuaThamDinh;
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