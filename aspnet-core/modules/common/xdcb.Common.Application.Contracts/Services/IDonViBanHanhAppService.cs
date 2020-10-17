using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;

namespace xdcb.Common.DanhMuc.DonViBanHanhs
{
    public interface IDonViBanHanhAppService :
        ICrudAppService<
            DonViBanHanhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDonViBanHanhDto,
            CreateUpdateDonViBanHanhDto>
    {
        Task<List<DonViBanHanhDto>> GetListByIds(List<Guid> ids);

        Task<List<DonViBanHanhDto>> GetDonViBanHanhsAsync();

        Task<PagedResultDto<DonViBanHanhDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Export excel Đơn vị ban hành
        /// </summary>
        /// <returns></returns>
        Task<dynamic> ReportAsync();
    }
}