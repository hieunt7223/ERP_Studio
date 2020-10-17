using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.LoaiHoSoChiPhiDauTuDtos;
using xdcb.Common.DanhMuc.LoaiHoSos;

namespace xdcb.Common
{
    public class LoaiHoSoChiPhiDauTuApplicationAutoMapperProfile : Profile
    {
        public LoaiHoSoChiPhiDauTuApplicationAutoMapperProfile()
        {
            CreateMap<LoaiHoSoChiPhiDauTu, LoaiHoSoChiPhiDauTuDto>();
            CreateMap<CreateUpdateLoaiHoSoChiPhiDauTuDto, LoaiHoSoChiPhiDauTu>();
            CreateMap<LoaiHoSoChiPhiDauTuDto, CreateUpdateLoaiHoSoChiPhiDauTuDto>();
        }
    }
}
