using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos;

namespace xdcb.Common.DanhMuc.NganhLinhVucSuDungs
{
    public interface INganhLinhVucSuDungAppService :
        ICrudAppService<
            NganhLinhVucSuDungDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNganhLinhVucSuDungDto,
            CreateUpdateNganhLinhVucSuDungDto>
    {
        Task<List<NganhLinhVucSuDungDto>> GetListByIds(List<Guid> ids);

        Task<PagedResultDto<NganhLinhVucSuDungDto>> SearchAsync(ConditionSearch condition);
    }
}