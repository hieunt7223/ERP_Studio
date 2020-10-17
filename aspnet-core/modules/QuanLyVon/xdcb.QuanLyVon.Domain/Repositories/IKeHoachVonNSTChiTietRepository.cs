using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.KeHoachVonNSTChiTiets
{
    public interface IKeHoachVonNSTChiTietRepository : IBasicRepository<KeHoachVonNSTChiTiet, Guid>
    {
        Task<List<KeHoachVonNSTChiTiet>> GetDataLuyKeByNam(int nam);
    }
}
