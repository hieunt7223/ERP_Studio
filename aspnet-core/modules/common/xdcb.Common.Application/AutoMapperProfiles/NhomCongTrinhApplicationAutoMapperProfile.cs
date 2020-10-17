using AutoMapper;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhs;

namespace xdcb.Common.DanhMuc
{
    public class NhomCongTrinhApplicationAutoMapperProfile : Profile
    {
        public NhomCongTrinhApplicationAutoMapperProfile()
        {
            CreateMap<NhomCongTrinh, NhomCongTrinhDto>();
            CreateMap<CreateUpdateNhomCongTrinhDto, NhomCongTrinh>();
            CreateMap<NhomCongTrinhDto, CreateUpdateNhomCongTrinhDto>();
        }
    }
}