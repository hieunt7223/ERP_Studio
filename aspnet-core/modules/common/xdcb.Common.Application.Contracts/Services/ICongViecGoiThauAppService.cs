using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.CongViecGoiThauDtos;

namespace xdcb.Common.DanhMuc.CongViecGoiThaus
{
    public interface ICongViecGoiThauAppService :
        ICrudAppService<
            CongViecGoiThauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCongViecGoiThauDto,
            CreateUpdateCongViecGoiThauDto>
    {
        Task<List<CongViecGoiThauDto>> GetListByIds(List<Guid> ids);
    }
}