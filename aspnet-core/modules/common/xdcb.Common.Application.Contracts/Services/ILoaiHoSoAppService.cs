using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public interface ILoaiHoSoAppService : ICrudAppService<
            LoaiHoSoDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiHoSoDto,
            CreateUpdateLoaiHoSoDto>
    {
        /// <summary>
        /// get danh sach loai ho so
        /// </summary>
        /// <returns></returns>
        Task<List<LoaiHoSoDto>> GetLoaiHoSoDuocApDungAsync(bool apDung = true);

        Task<List<LoaiHoSoDto>> GetAllAsync();

        /// <summary>
        /// get loại hồ sơ by id
        /// </summary>
        /// <param name="loaiHoSoId"></param>
        /// <returns></returns>
        Task<LoaiHoSoDto> GetLoaiHoSoByIdAsync(Guid loaiHoSoId);

        /// <summary>
        /// Xóa loại hồ sơ theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LoaiHoSoDto> DeleteLoaiHoSoAsync(Guid id);

        /// <summary>
        /// xuất file
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ExportAsync();
    }
}