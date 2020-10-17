using AutoMapper;
using xdcb.Common.DanhMuc.KhoanChiDtos;
using xdcb.Common.DanhMuc.KhoanChis;

namespace xdcb.Common.DanhMuc
{
    public class KhoanChiApplicationAutoMapperProfile : Profile
    {
        public KhoanChiApplicationAutoMapperProfile()
        {
            CreateMap<KhoanChi, KhoanChiDto>();
            CreateMap<CreateUpdateKhoanChiDto, KhoanChi>();
            CreateMap<KhoanChiDto, CreateUpdateKhoanChiDto>();
        }
    }
}
