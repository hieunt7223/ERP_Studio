using AutoMapper;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;

namespace xdcb.Common.DanhMuc
{
    public class LoaiCongTrinhApplicationAutoMapperProfile : Profile
    {
        public LoaiCongTrinhApplicationAutoMapperProfile()
        {
            CreateMap<LoaiCongTrinh, LoaiCongTrinhDto>();
            CreateMap<CreateUpdateLoaiCongTrinhDto, LoaiCongTrinh>();
            CreateMap<LoaiCongTrinhDto, CreateUpdateLoaiCongTrinhDto>();
        }
    }
}