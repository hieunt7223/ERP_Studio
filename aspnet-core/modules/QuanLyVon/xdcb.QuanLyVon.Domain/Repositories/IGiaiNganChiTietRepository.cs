using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.GiaiNganChiTiets
{
    /// <summary>
    /// Generated Domain Repositories for Table : GiaiNganChiTiet.
    /// </summary>
    public interface IGiaiNganChiTietRepository : IBasicRepository<GiaiNganChiTiet, Guid>
    {
        Task<List<GiaiNganChiTiet>> GetDataIsNew(int nam, Guid chuDauTuId);
        Task<List<GiaiNganChiTiet>> GetDataDetailForTongHop(int nam, string tenkehoach, int? quyThang, bool? isKeHoachKeoDai, Guid congTrinhId);
    }

}
