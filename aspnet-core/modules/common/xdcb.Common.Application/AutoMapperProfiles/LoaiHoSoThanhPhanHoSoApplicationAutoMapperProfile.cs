using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;

namespace xdcb.Common
{
    public class LoaiHoSoThanhPhanHoSoApplicationAutoMapperProfile : Profile
    {
        public LoaiHoSoThanhPhanHoSoApplicationAutoMapperProfile()
        {
            CreateMap<LoaiHoSoThanhPhanHoSo, LoaiHoSoThanhPhanHoSoDto>();
            CreateMap<CreateUpdateLoaiHoSoThanhPhanHoSoDto, LoaiHoSoThanhPhanHoSo>();
            CreateMap<LoaiHoSoThanhPhanHoSoDto, CreateUpdateLoaiHoSoThanhPhanHoSoDto>();
        }
    }
}
