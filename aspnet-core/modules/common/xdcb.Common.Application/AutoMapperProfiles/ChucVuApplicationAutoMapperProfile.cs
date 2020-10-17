using AutoMapper;
using xdcb.Common.DanhMuc.ChucVuDtos;
using xdcb.Common.DanhMuc.ChucVus;

namespace xdcb.Common
{
    public class ChucVuApplicationAutoMapperProfile : Profile
    {
        public ChucVuApplicationAutoMapperProfile()
        {
            CreateMap<ChucVu, ChucVuDto>();
            CreateMap<CreateUpdateChucVuDto, ChucVu>();
            CreateMap<ChucVuDto, CreateUpdateChucVuDto>();
        }
    }
}