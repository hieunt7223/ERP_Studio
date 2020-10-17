using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;

namespace xdcb.Common.DanhMuc.HinhThucHopDongs
{
    public interface IHinhThucHopDongAppService :
        ICrudAppService<
            HinhThucHopDongDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateHinhThucHopDongDto,
            CreateUpdateHinhThucHopDongDto>
    {
        Task<PagedResultDto<HinhThucHopDongDto>> SearchAsync(ConditionSearch condition);
        bool IsNameExist(string name, Guid id);

        /// <summary>
        /// Get danh sách theo danh sách ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<HinhThucHopDongDto>> GetListByIdsAsync(List<Guid> ids);
    }
}