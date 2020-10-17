using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public interface INhomCongTrinhAppService :
        ICrudAppService<
            NhomCongTrinhDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateNhomCongTrinhDto,
            CreateUpdateNhomCongTrinhDto>
    {
        Task<PagedResultDto<NhomCongTrinhDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// Get danh sách nhóm công trình
        /// </summary>
        /// <returns></returns>
        Task<List<NhomCongTrinhDto>> GetNhomCongTrinhsAsync();
    }
}