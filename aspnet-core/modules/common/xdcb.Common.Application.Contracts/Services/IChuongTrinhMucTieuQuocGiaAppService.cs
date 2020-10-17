using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public interface IChuongTrinhMucTieuQuocGiaAppService :
        ICrudAppService<
            ChuongTrinhMucTieuQuocGiaDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChuongTrinhMucTieuQuocGiaDto,
            CreateUpdateChuongTrinhMucTieuQuocGiaDto>
    {
        Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetAllAsync();

        Task<List<ChuongTrinhMucTieuQuocGiaDto>> SearchAsync(string keyword);

        Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetMaChuongTrinhQuocGia();

        /// <summary>
        /// Get danh sách mã chương trình mục tiêu quốc gia con
        /// </summary>
        /// <returns></returns>
        Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetMaConChuongTrinhsAsync();
    }
}