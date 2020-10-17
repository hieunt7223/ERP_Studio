using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.KhoanChiDtos;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public interface IKhoanChiAppService :
        ICrudAppService<
            KhoanChiDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateKhoanChiDto,
            CreateUpdateKhoanChiDto>
    {
        Task<PagedResultDto<KhoanChiDto>> SearchAsync(ConditionSearch condition);
    }
}