using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.HangMucCongTrinhDtos;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public interface IHangMucCongTrinhAppService :
        ICrudAppService<
            HangMucCongTrinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHangMucCongTrinhDto,
            CreateUpdateHangMucCongTrinhDto>
    {
        Task<PagedResultDto<HangMucCongTrinhDto>> SearchAsync(ConditionSearch condition);
    }
}