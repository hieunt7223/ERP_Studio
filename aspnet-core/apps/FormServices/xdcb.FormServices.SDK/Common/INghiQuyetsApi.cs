using Refit;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common;
using xdcb.Common.DanhMuc.NghiQuyetDtos;

namespace xdcb.FormServices.SDK
{
    public interface INghiQuyetsApi
    {
        [Get("/api/app/nghiQuyet/search")]
        Task<PagedResultDto<NghiQuyetDto>> SearchAsync(ConditionSearch condition);
        [Get("/api/app/nghiQuyet/{id}")]
        Task<NghiQuyetDto> GetAsync(Guid id);
        [Post("/api/app/nghiQuyet")]
        Task<NghiQuyetDto> Create([Body] CreateUpdateNghiQuyetDto info);

        [Put("/api/app/nghiQuyet/{id}")]
        Task<NghiQuyetDto> Update(Guid Id, [Body] CreateUpdateNghiQuyetDto info);

        [Delete("/api/app/nghiQuyet/{id}")]
        Task<NghiQuyetDto> Delete(Guid Id);

        [Post("/api/NghiQuyet/NghiQuyetCongTrinh")]
        Task<NghiQuyetDto> CreateNghiQuyetCongTrinh([Body] CreateUpdateNghiQuyetCongTrinhDto info);

        [Delete("/api/NghiQuyet/NghiQuyetCongTrinh")]
        Task<NghiQuyetDto> DeleteNghiQuyetCongTrinh(Guid Id);
    }
}
