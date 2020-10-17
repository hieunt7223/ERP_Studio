using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietCoSoPhapLyRepository : IRepository<HoSoCongTrinhChiTietCoSoPhapLy, Guid>
    {
        /// <summary>
        /// Get list cơ sở pháp lý theo list hồ sơ công trinh chi tiêt id
        /// </summary>
        /// <param name="ids">danh sách hồ sơ công trình chi tiết ids</param>
        /// <returns>danh sách địa điểm</returns>
        Task<List<HoSoCongTrinhChiTietCoSoPhapLy>> GetCoSoPhapLyByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Update Cơ sở pháp lý HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Cơ sở pháp lý HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> UpdateCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model);

        /// <summary>
        /// Insert Cơ sở pháp lý HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Cơ sở pháp lý HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> InsertCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model);

        /// <summary>
        /// Delete Cơ sở pháp lý HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Cơ sở pháp lý HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> DeleteCoSoPhapLy(HoSoCongTrinhChiTietCoSoPhapLy model);
    }
}