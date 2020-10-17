using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.LoaiHoSoChiPhiDauTuDtos;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public interface ILoaiHoSoChiPhiDauTuAppService :
        ICrudAppService<
            LoaiHoSoChiPhiDauTuDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLoaiHoSoChiPhiDauTuDto,
            CreateUpdateLoaiHoSoChiPhiDauTuDto>
    {
    }
}