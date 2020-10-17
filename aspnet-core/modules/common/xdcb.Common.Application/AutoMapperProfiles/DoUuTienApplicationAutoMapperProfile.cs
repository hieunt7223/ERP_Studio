using AutoMapper;
using xdcb.Common.DanhMuc.DoUuTienDtos;
using xdcb.Common.DanhMuc.DoUuTiens;

namespace xdcb.Common.DanhMuc
{
    public class DoUuTienApplicationAutoMapperProfile : Profile
    {
        public DoUuTienApplicationAutoMapperProfile()
        {
            CreateMap<DoUuTien, DoUuTienDto>();
            CreateMap<CreateUpdateDoUuTienDto, DoUuTien>();
            CreateMap<DoUuTienDto, CreateUpdateDoUuTienDto>();
        }
    }
}