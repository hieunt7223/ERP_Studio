using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.NghiQuyetDtos;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public interface INghiQuyetAppService :
        ICrudAppService<
            NghiQuyetDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNghiQuyetDto,
            CreateUpdateNghiQuyetDto>
    {
        Task<PagedResultDto<NghiQuyetDto>> SearchAsync(ConditionSearch condition);
        Task DeleleNghiQuyetCongTrinhByNghiQuyetId(Guid id);
        Task<NghiQuyetDto> SaveNghiQuyetCongTrinh(CreateUpdateNghiQuyetCongTrinhDto info);
    }
}