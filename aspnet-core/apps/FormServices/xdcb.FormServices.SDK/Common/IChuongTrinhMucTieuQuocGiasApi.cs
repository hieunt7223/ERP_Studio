using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;

namespace xdcb.FormServices.SDK
{
    public interface IChuongTrinhMucTieuQuocGiasApi
    {
        [Get("/api/app/chuongTrinhMucTieuQuocGia/{id}")]
        Task<ChuongTrinhMucTieuQuocGiaDto> GetAsync(Guid id);

        [Get("/api/ChuongTrinhMucTieuQuocGia/all")]
        Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetAll();

        [Get("/api/app/chuongTrinhMucTieuQuocGia/search")]
        Task<List<ChuongTrinhMucTieuQuocGiaDto>> SearchAsync(string keyword);

        [Post("/api/app/chuongTrinhMucTieuQuocGia")]
        Task<ChuongTrinhMucTieuQuocGiaDto> CreateAsync(CreateUpdateChuongTrinhMucTieuQuocGiaDto input);

        [Put("/api/app/chuongTrinhMucTieuQuocGia/{id}")]
        Task<ChuongTrinhMucTieuQuocGiaDto> UpdateAsync(Guid id, CreateUpdateChuongTrinhMucTieuQuocGiaDto input);

        [Delete("/api/app/chuongTrinhMucTieuQuocGia/{id}")]
        Task DeleteAsync(Guid id);
    }
}
