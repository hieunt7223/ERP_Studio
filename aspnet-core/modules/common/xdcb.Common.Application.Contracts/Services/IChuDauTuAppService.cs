using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ChuDauTuDtos;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public interface IChuDauTuAppService :
        ICrudAppService<
            ChuDauTuDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChuDauTuDto,
            CreateUpdateChuDauTuDto>
    {
        Task<PagedResultDto<ChuDauTuDto>> SearchAsync(ConditionSearch condition);

        Task<IList<ChuDauTuDto>> GetChuDauTuListAsync();

        Task<Guid?> CheckChuDauTuAsync(Guid id);

        Task<List<ChuDauTuDto>> GetListByIdsAsync(List<Guid> ids);
    }
}