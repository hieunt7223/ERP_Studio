using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common.DanhMuc
{
    public class ThuVienVanBanApplicationAutoMapperProfile : Profile
    {
        public ThuVienVanBanApplicationAutoMapperProfile()
        {
            CreateMap<ThuVienVanBan, ThuVienVanBanDto>()
                .ForMember(dest => dest.Files,
                            opt => opt.MapFrom(src => src.FileCuaThuVienVanBans));
            CreateMap<CreateUpdateThuVienVanBanDto, ThuVienVanBan>();
            CreateMap<ThuVienVanBanDto, CreateUpdateThuVienVanBanDto>();
        }
    }
}
