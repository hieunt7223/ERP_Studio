using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.PhongBanDtos;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public interface IPhongBanAppService :
        ICrudAppService<
            PhongBanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePhongBanDto,
            CreateUpdatePhongBanDto>
    {
        Task<PagedResultDto<PhongBanDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// xuất file
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ExportAsync();
    }
}