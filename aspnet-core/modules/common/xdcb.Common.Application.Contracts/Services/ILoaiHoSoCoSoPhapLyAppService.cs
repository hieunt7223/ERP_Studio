using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public interface ILoaiHoSoCoSoPhapLyAppService :
        ICrudAppService<
            LoaiHoSoCoSoPhapLyDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiHoSoCoSoPhapLyDto,
            CreateUpdateLoaiHoSoCoSoPhapLyDto>
    {
    }
}
