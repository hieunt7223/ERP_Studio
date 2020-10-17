using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThaus
{
    public interface IHinhThucChonNhaThauAppService :
        ICrudAppService<
            HinhThucChonNhaThauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHinhThucChonNhaThauDto,
            CreateUpdateHinhThucChonNhaThauDto>
    {
        Task<PagedResultDto<HinhThucChonNhaThauDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Get danh sachs theo danh sách id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<HinhThucChonNhaThauDto>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// xuất file
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ExportAsync();
    }
}