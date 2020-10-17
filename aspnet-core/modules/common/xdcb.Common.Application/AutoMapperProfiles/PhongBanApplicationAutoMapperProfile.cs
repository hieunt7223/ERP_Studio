using AutoMapper;
using xdcb.Common.DanhMuc.PhongBanDtos;
using xdcb.Common.DanhMuc.PhongBans;

namespace xdcb.Common.DanhMuc
{
    public class PhongBanApplicationAutoMapperProfile : Profile
    {
        public PhongBanApplicationAutoMapperProfile()
        {
            CreateMap<PhongBan, PhongBanDto>();
            CreateMap<CreateUpdatePhongBanDto, PhongBan>();
            CreateMap<PhongBanDto, CreateUpdatePhongBanDto>();
        }
    }
}