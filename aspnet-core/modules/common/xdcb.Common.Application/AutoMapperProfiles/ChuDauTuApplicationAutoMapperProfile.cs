using AutoMapper;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuDauTus;

namespace xdcb.Common
{
    public class ChuDauTuApplicationAutoMapperProfile : Profile
    {
        public ChuDauTuApplicationAutoMapperProfile()
        {
            CreateMap<ChuDauTu, ChuDauTuDto>();
            CreateMap<CreateUpdateChuDauTuDto, ChuDauTu>();
            CreateMap<ChuDauTuDto, CreateUpdateChuDauTuDto>();
        }
    }
}