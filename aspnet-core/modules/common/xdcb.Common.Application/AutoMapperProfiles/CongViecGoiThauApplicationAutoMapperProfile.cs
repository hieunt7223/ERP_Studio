using AutoMapper;
using xdcb.Common.DanhMuc.CongViecGoiThauDtos;
using xdcb.Common.DanhMuc.CongViecGoiThaus;

namespace xdcb.Common.DanhMuc
{
    public class CongViecGoiThauApplicationAutoMapperProfile : Profile
    {
        public CongViecGoiThauApplicationAutoMapperProfile()
        {
            CreateMap<CongViecGoiThau, CongViecGoiThauDto>();
            CreateMap<CreateUpdateCongViecGoiThauDto, CongViecGoiThau>();
            CreateMap<CongViecGoiThauDto, CreateUpdateCongViecGoiThauDto>();
        }
    }
}