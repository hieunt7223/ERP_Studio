using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;

namespace xdcb.FormServices.SDK
{
    public interface IDonViHanhChinhsApi
    {
        [Get("/api/app/donViHanhChinh/{id}")]
        Task<DonViHanhChinhDto> GetAsync(Guid id);

        [Get("/api/DonViHanhChinh/all")]
        Task<List<DonViHanhChinhDto>> GetAll();

        [Get("/api/app/donViHanhChinh")]
        Task<PagedResultDto<DonViHanhChinhDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
