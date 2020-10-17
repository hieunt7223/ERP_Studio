using AutoMapper;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.GoiThaus;

namespace xdcb.Common.DanhMuc
{
    public class GoiThauApplicationAutoMapperProfile : Profile
    {
        public GoiThauApplicationAutoMapperProfile()
        {
            CreateMap<GoiThau, GoiThauDto>();
            CreateMap<CreateUpdateGoiThauDto, GoiThau>();
            CreateMap<GoiThauDto, CreateUpdateGoiThauDto>();
        }
    }
}