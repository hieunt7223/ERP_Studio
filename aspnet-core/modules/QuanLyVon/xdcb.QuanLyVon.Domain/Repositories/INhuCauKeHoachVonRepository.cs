using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.NhuCauKeHoachVons
{
    /// <summary>
    /// Generated Domain Repositories for Table : NhuCauKeHoachVon.
    /// </summary>
    public interface INhuCauKeHoachVonRepository : IBasicRepository<NhuCauKeHoachVon, Guid>
    {
        Task<NhuCauKeHoachVon> GetHangNambyYearAsync(int Year);
    }
}