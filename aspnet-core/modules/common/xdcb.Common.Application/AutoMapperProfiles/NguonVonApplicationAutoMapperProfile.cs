using AutoMapper;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.DanhMuc.NguonVons;

namespace xdcb.Common
{
    public class NguonVonApplicationAutoMapperProfile : Profile
    {
        public NguonVonApplicationAutoMapperProfile()
        {
            CreateMap<NguonVon, NguonVonDto>();
            CreateMap<CreateUpdateNguonVonDto, NguonVon>();
            CreateMap<NguonVonDto, CreateUpdateNguonVonDto>();
        }
    }
}