using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.KeHoachVonNQChiTiets
{
    /// <summary>
    /// Generated Domain Repositories for Table : KeHoachVonNQChiTiet.
    /// </summary>
    public interface IKeHoachVonNQChiTietRepository : IBasicRepository<KeHoachVonNQChiTiet, Guid>
    {
        Task<List<KeHoachVonNQChiTiet>> GetDataLuyKeByNam(int nam);
    }
}
