using AutoMapper;
using xdcb.Common.DanhMuc.ChiPhiDauTuDtos;
using xdcb.Common.DanhMuc.ChiPhiDauTus;

namespace xdcb.Common
{
    public class ChiPhiDauTuApplicationAutoMapperProfile : Profile
    {
        public ChiPhiDauTuApplicationAutoMapperProfile()
        {
            CreateMap<ChiPhiDauTu, ChiPhiDauTuDto>();
            CreateMap<CreateUpdateChiPhiDauTuDto, ChiPhiDauTu>();
            CreateMap<ChiPhiDauTuDto, CreateUpdateChiPhiDauTuDto>();
        }
    }
}