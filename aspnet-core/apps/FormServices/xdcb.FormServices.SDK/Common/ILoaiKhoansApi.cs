using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;

namespace xdcb.FormServices.SDK
{
    public interface ILoaiKhoansApi
    {
        [Get("/api/LoaiKhoan/all")]
        Task<List<LoaiKhoanDto>> GetAll();

        [Get("/api/app/loaiKhoan/{id}")]
        Task<LoaiKhoanDto> GetAsync(Guid id);

        [Delete("/api/app/loaiKhoan/{id}")]
        Task<LoaiKhoanDto> DeleteAsync(Guid id);

        [Put("/api/app/loaiKhoan/{id}")]
        Task<LoaiKhoanDto> UpdateAsync(Guid id, [Body] CreateUpdateLoaiKhoanDto info);

        [Get("/api/app/loaiKhoan/search")]
        Task<List<LoaiKhoanDto>> SearchAsync(ConditionSearch condition);

        [Post("/api/app/loaiKhoan")]
        Task<LoaiKhoanDto> Create([Body] CreateUpdateLoaiKhoanDto info);
    }
}
