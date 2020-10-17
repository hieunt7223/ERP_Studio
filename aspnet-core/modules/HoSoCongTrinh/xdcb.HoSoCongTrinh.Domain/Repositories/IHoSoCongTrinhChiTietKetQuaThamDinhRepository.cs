using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietKetQuaThamDinhRepository : IRepository<HoSoCongTrinhChiTietKetQuaThamDinh, Guid>
    {
        /// <summary>
        /// Get list ket qua tham dinh theo list hồ sơ công trinh chi tiêt id
        /// </summary>
        /// <param name="ids">danh sách hồ sơ công trình chi tiết ids</param>
        /// <returns>danh sách địa điểm</returns>
        Task<List<HoSoCongTrinhChiTietKetQuaThamDinh>> GetKetQuaThamDinhByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Update Kết quả thẩm định HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Kết quả thẩm định HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> UpdateKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model);

        /// <summary>
        /// Insert Kết quả thẩm định HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Kết quả thẩm định HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> InsertKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model);

        /// <summary>
        /// Delete Kết quả thẩm định HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Kết quả thẩm định HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> DeleteKetQuaThamDinh(HoSoCongTrinhChiTietKetQuaThamDinh model);
    }
}