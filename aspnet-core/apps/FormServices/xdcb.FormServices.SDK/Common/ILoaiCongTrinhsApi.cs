using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;

namespace xdcb.FormServices.SDK
{
    public interface ILoaiCongTrinhsApi
    {
        [Get("/api/app/loaiCongTrinh/{id}")]
        Task<LoaiCongTrinhDto> GetAsync(Guid id);

        [Get("/api/app/loaiCongTrinh/loaiCongTrinhs")]
        Task<List<LoaiCongTrinhDto>> GetAll();
    }
}
