using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public interface ILinhVucVanBanAppService :
        ICrudAppService<
            LinhVucVanBanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLinhVucVanBanDto,
            CreateUpdateLinhVucVanBanDto>
    {
        Task<PagedResultDto<LinhVucVanBanDto>> SearchAsync(ConditionSearch condition);
        Task<IList<LinhVucVanBanDto>> GetLinhVucVanBanListAsync();
    }
}