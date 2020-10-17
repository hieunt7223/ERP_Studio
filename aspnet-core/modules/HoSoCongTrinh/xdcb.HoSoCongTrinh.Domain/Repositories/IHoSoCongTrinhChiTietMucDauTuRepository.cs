using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh.Repositories
{
    public interface IHoSoCongTrinhChiTietMucDauTuRepository : IRepository<HoSoCongTrinhChiTietMucDauTu, Guid>
    {
        /// <summary>
        /// Get danh sách tổng mức đầu tư theo danh sách hồ sơ công trình chi tiết id
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<HoSoCongTrinhChiTietMucDauTu>> GetTongMucDauTuByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Update mức đầu tư HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Mức đầu tư HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> UpdateMucDauTu(HoSoCongTrinhChiTietMucDauTu model);

        /// <summary>
        /// Insert mức đầu tư HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Mức đầu tư HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> InsertMucDauTu(HoSoCongTrinhChiTietMucDauTu model);

        /// <summary>
        /// Delete mức đầu tư HSCT Chi tiết
        /// </summary>
        /// <param name="model">model Mức đầu tư HSCT Chi tiết</param>
        /// <returns>True</returns>
        Task<bool> DeleteMucDauTu(HoSoCongTrinhChiTietMucDauTu model);
    }
}