using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public interface ILoaiVanBanAppService :
        ICrudAppService<
            LoaiVanBanDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiVanBanDto,
            CreateUpdateLoaiVanBanDto>
    {
        Task<PagedResultDto<LoaiVanBanDto>> SearchAsync(ConditionSearch condition);

        Task<IList<LoaiVanBanDto>> GetLoaiVanBanListAsync();
       
    }
}