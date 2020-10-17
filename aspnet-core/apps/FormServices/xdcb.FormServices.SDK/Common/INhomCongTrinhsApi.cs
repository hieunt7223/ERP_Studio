using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;

namespace xdcb.FormServices.SDK
{
    public interface INhomCongTrinhsApi
    {
        [Get("/api/app/nhomCongTrinh/{id}")]
        Task<NhomCongTrinhDto> GetAsync(Guid id);

        [Get("/api/app/nhomCongTrinh/nhomCongTrinhs")]
        Task<List<NhomCongTrinhDto>> GetAll();

        [Get("/api/app/nhomCongTrinh")]
        Task<PagedResultDto<NhomCongTrinhDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
