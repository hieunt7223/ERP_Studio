using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.DoUuTienDtos;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public interface IDoUuTienAppService :
        ICrudAppService<
            DoUuTienDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDoUuTienDto,
            CreateUpdateDoUuTienDto>
    {
        Task<PagedResultDto<DoUuTienDto>> SearchAsync(ConditionSearch condition);

        /// <summary>
        /// get key, value của enum độ ưu tiên
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetMaDoUuTiens();
    }
}