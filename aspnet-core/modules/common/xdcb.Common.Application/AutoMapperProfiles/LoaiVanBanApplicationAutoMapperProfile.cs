using AutoMapper;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.DanhMuc.LoaiVanBans;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;

namespace xdcb.Common.DanhMuc
{
    public class LoaiVanBanApplicationAutoMapperProfile : Profile
    {
        public LoaiVanBanApplicationAutoMapperProfile()
        {
            CreateMap<LoaiVanBan, LoaiVanBanDto>();
            CreateMap<CreateUpdateLoaiVanBanDto, LoaiVanBan>();
            CreateMap<LoaiVanBanDto, CreateUpdateLoaiVanBanDto>();
        }
    }
}