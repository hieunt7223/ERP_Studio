using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public interface ILoaiHoSoThanhPhanHoSoAppService :
        ICrudAppService<
            LoaiHoSoThanhPhanHoSoDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiHoSoThanhPhanHoSoDto,
            CreateUpdateLoaiHoSoThanhPhanHoSoDto>
    {
    }
}
