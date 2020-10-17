using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBans
{
    public class FileCuaThuVienVanBanRepository : EfCoreRepository<CommonDbContext, FileCuaThuVienVanBan, Guid>, IFileCuaThuVienVanBanRepository
    {
        private readonly CommonDbContext _context;
        private readonly IDbContextProvider<CommonDbContext> _dbContextProvider;

        public FileCuaThuVienVanBanRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
            _context = context;
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Guid> GetIdByFileIdAsync(Guid FileId)
        {
            return _context.FileCuaThuVienVanBans.FirstOrDefault(w => w.FileId == FileId).Id;
        }

        public async Task<IList<Guid>> GetFileIdListAsync(Guid ThuVienVanBanId)
        {
            return await _context.FileCuaThuVienVanBans.Where(w => w.ThuVienVanBanId == ThuVienVanBanId).Select(x => x.FileId).ToListAsync();
        }

        public async Task<List<FileCuaThuVienVanBan>> InsertMultiAsync(List<FileCuaThuVienVanBan> listFiles)
        {
            await _dbContextProvider.GetDbContext().BulkInsertAsync(listFiles);
            return listFiles;
        }
    }
}