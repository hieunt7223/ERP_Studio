using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;

namespace xdcb.QuanLyVon.NhuCauKeHoachVons
{
    /// <summary>
    /// Generated Repositories for Table : NhuCauKeHoachVon.
    /// </summary>
    public class NhuCauKeHoachVonRepository : EfCoreRepository<QuanLyVonDbContext, NhuCauKeHoachVon, Guid>, INhuCauKeHoachVonRepository
    {
        public NhuCauKeHoachVonRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<NhuCauKeHoachVon> GetHangNambyYearAsync(int Year)
        {
            return DbContext.NhuCauKeHoachVon.FirstOrDefaultAsync(x => x.TuNam == Year && !x.IsDeleted);
        }
    }
}