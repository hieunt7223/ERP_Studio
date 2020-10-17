using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using xdcb.HoSoCongTrinh.Dtos;

namespace xdcb.HoSoCongTrinh.Services
{
    public interface IHoSoCongTrinhChiTietAppService : IApplicationService
    {
        Task<List<ListHoSoCongTrinhChiTietViewModel>> GetHoSoCongTrinhChiTietsAsync(HoSoCongTrinhChiTietInput input);

        /// <summary>
        /// get data report loại hồ sơ 1
        /// </summary>
        /// <param name="id">id hồ sơ công trình</param>
        /// <param name="chiTietId">id hồ sơ công trình chi tiết</param>
        /// <returns></returns>
        Task<dynamic> GetDataDeXuatAsync(Guid id, Guid chiTietId);

        /// <summary>
        /// get data report loại hồ sơ 2
        /// </summary>
        /// <param name="id">id hồ sơ công trình</param>
        /// <param name="chiTietId">id hồ sơ công trình chi tiết</param>
        /// <returns></returns>
        Task<dynamic> GetDataDeXuatDieuChinhAsync(Guid id, Guid chiTietId);

        /// <summary>
        /// get data report loại hồ sơ 3
        /// </summary>
        /// <param name="id">id hồ sơ công trình</param>
        /// <param name="chiTietId">id hồ sơ công trình chi tiết</param>
        /// <returns></returns>
        Task<dynamic> GetDataReportAsync(Guid id, Guid chiTietId);

        /// <summary>
        /// get data report loại hồ sơ 4
        /// </summary>
        /// <param name="id">id hồ sơ công trình</param>
        /// <param name="chiTietId">id hồ sơ công trình chi tiết</param>
        /// <returns></returns>
        Task<dynamic> GetDataDieuChinhReportAsync(Guid id, Guid chiTietId);
    }
}