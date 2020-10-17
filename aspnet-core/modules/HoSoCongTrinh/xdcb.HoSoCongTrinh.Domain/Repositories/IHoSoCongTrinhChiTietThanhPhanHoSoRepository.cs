using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietThanhPhanHoSoRepository : IRepository<HoSoCongTrinhChiTietThanhPhanHoSo, Guid>
    {
        /// <summary>
        /// Get thanh phan ho so theo list hồ sơ công trinh chi tiêt id
        /// </summary>
        /// <param name="ids">danh sách hồ sơ công trình chi tiết ids</param>
        /// <returns>danh sách địa điểm</returns>
        Task<List<HoSoCongTrinhChiTietThanhPhanHoSo>> GetThanhPhanHoSosByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Update Thành phần hồ sơ HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Thành phần hồ sơ HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> UpdateThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model);

        /// <summary>
        /// Insert Thành phần hồ sơ HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Thành phần hồ sơ HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> InsertThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model);

        /// <summary>
        /// Delete Thành phần hồ sơ HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Thành phần hồ sơ HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> DeleteThanhPhanHoSo(HoSoCongTrinhChiTietThanhPhanHoSo model);
    }
}