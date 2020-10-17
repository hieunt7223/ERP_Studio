using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietDiaDiemRepository : IRepository<HoSoCongTrinhChiTietDiaDiem, Guid>
    {
        /// <summary>
        /// Get địa điểm xây dựng theo list hồ sơ công trinh chi tiêt id
        /// </summary>
        /// <param name="ids">danh sách hồ sơ công trình chi tiết ids</param>
        /// <returns>danh sách địa điểm</returns>
        Task<List<HoSoCongTrinhChiTietDiaDiem>> GetDiaDiemByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Update địa điểm HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Địa điểm HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> UpdateDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model);

        /// <summary>
        /// Insert địa điểm HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Địa điểm HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> InsertDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model);

        /// <summary>
        /// Delete địa điểm HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Địa điểm HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> DeleteDiaDiemXayDung(HoSoCongTrinhChiTietDiaDiem model);
    }
}