using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common;
using xdcb.Common.DanhMuc.ChuDauTuDtos;

namespace xdcb.FormServices.SDK
{
    public interface IChuDauTusApi
    {
        [Get("/api/app/chuDauTu/{id}")]
        Task<ChuDauTuDto> GetAsync(Guid id);

        [Get("/api/app/chuDauTu/chuDauTuList")]
        Task<List<ChuDauTuDto>> GetAll();

        [Get("/api/app/chuDauTu")]
        Task<PagedResultDto<ChuDauTuDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
