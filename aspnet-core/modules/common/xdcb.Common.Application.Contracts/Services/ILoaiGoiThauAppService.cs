using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.GoiThauDtos;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public interface ILoaiGoiThauAppService :
        ICrudAppService<
            LoaiGoiThauDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiGoiThauDto,
            CreateUpdateLoaiGoiThauDto>
    {
        Task<List<LoaiGoiThauDto>> GetListByIds(List<Guid> ids);
    }
}