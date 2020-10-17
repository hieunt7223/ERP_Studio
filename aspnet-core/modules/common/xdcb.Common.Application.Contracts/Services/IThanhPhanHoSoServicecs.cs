using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public interface IThanhPhanHoSoAppService :
        ICrudAppService<
            ThanhPhanHoSoDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateThanhPhanHoSoDto,
            CreateUpdateThanhPhanHoSoDto>
    {
        Task<PagedResultDto<ThanhPhanHoSoDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get list thành phần hồ sơ theo list ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSoByIds(List<Guid> ids);

        /// <summary>
        /// Kiểm tra xem có đang tồn tại trong thành phần hồ sơ không
        /// </summary>
        /// <param name="id">id của loại văn bản</param>
        /// <returns></returns>
        Task<bool> IsByThanhPhanHoSoAsync(Guid id);

        /// <summary>
        /// Get list thành phần hồ sơ
        /// </summary>
        /// <returns></returns>
        Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSosAsync();

        /// <summary>
        /// Get list thành phần hồ sơ theo loại văn bản id
        /// </summary>
        /// <param name="id">id của loại văn bản</param>
        /// <returns></returns>
        Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSoByLoaiVanBanIdAsync(Guid id);
    }
}