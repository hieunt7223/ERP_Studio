using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public interface IThanhPhanHoSoRepository : IBasicRepository<ThanhPhanHoSo, Guid>
    {
        Task<PagedResultDto<ThanhPhanHoSo>> SearchAsync(ConditionSearch condition);

        Task<PagedResultDto<ThanhPhanHoSo>> GetThanhPhanHoSoList(PagedAndSortedResultRequestDto input);

        /// <summary>
        /// Get list thanh phần hồ sơ theo list ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<ThanhPhanHoSo>> GetThanhPhanHoSoByIds(List<Guid> ids);

        /// <summary>
        /// Kiểm tra xem có đang tồn tại trong thành phần hồ sơ không
        /// </summary>
        /// <param name="id">id của loại văn bản</param>
        /// <returns></returns>
        Task<ThanhPhanHoSo> IsByThanhPhanHoSoAsync(Guid id);

        /// <summary>
        /// Get list thành phần hồ sơ
        /// </summary>
        /// <returns></returns>
        Task<List<ThanhPhanHoSo>> GetThanhPhanHoSosAsync();

        /// <summary>
        /// Get list thành phần hồ sơ theo loại văn bản id
        /// </summary>
        /// <param name="id">id của loại văn bản</param>
        /// <returns></returns>
        Task<List<ThanhPhanHoSo>> GetThanhPhanHoSoByLoaiVanBanIdAsync(Guid id);
    }
}