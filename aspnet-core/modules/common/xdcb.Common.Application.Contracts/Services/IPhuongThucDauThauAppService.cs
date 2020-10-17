using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.PhuongThucDauThauDtos;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public interface IPhuongThucDauThauAppService :
        ICrudAppService<
            PhuongThucDauThauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePhuongThucDauThauDto,
            CreateUpdatePhuongThucDauThauDto>
    {
        Task<PagedResultDto<PhuongThucDauThauDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Get danh sachs theo danh ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<PhuongThucDauThauDto>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// xuất file
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ExportAsync();
    }
}