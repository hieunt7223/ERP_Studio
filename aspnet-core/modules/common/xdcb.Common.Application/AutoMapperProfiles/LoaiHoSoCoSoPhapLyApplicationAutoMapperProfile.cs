using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;
using xdcb.Common.DanhMuc.LoaiHoSos;

namespace xdcb.Common
{
    public class LoaiHoSoCoSoPhapLyApplicationAutoMapperProfile : Profile
    {
        public LoaiHoSoCoSoPhapLyApplicationAutoMapperProfile()
        {
            CreateMap<LoaiHoSoCoSoPhapLy, LoaiHoSoCoSoPhapLyDto>();
            CreateMap<CreateUpdateLoaiHoSoCoSoPhapLyDto, LoaiHoSoCoSoPhapLy>();
            CreateMap<LoaiHoSoCoSoPhapLyDto, CreateUpdateLoaiHoSoCoSoPhapLyDto>();
        }
    }
}
