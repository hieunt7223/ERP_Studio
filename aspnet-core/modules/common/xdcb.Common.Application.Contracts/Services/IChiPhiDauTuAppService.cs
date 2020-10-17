using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ChiPhiDauTuDtos;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public interface IChiPhiDauTuAppService :
        ICrudAppService<
            ChiPhiDauTuDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChiPhiDauTuDto,
            CreateUpdateChiPhiDauTuDto>
    {
        Task<PagedResultDto<ChiPhiDauTuDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Get danh sách chi phí đầu tư theo ids
        /// </summary>
        /// <param name="ids">danh sách ids</param>
        /// <returns></returns>
        Task<List<ChiPhiDauTuDto>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Get danh sách chi phí đầu tư không bao gồm ids
        /// </summary>
        /// <param name="ids">danh sách ids</param>
        /// <returns></returns>
        Task<List<ChiPhiDauTuDto>> GetListExcludeIdsAsync(List<Guid> ids);

        /// <summary>
        /// Get danh sách chi phí đầu tư
        /// </summary>
        /// <returns></returns>
        Task<List<ChiPhiDauTuDto>> GetChiPhisAsync();

        Task<dynamic> ReportAsync();
    }
}