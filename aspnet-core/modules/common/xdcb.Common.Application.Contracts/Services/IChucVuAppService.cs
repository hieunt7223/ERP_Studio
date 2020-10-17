using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ChucVuDtos;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public interface IChucVuAppService :
        ICrudAppService<
            ChucVuDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChucVuDto,
            CreateUpdateChucVuDto>
    {
        Task<PagedResultDto<ChucVuDto>> SearchAsync(ConditionSearch condition);
    }
}