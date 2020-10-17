using AutoMapper;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.LoaiGoiThaus;

namespace xdcb.Common.DanhMuc
{
    public class LoaiGoiThauApplicationAutoMapperProfile : Profile
    {
        public LoaiGoiThauApplicationAutoMapperProfile()
        {
            CreateMap<LoaiGoiThau, LoaiGoiThauDto>();
            CreateMap<CreateUpdateLoaiGoiThauDto, LoaiGoiThau>();
            CreateMap<LoaiGoiThauDto, CreateUpdateLoaiGoiThauDto>();
        }
    }
}