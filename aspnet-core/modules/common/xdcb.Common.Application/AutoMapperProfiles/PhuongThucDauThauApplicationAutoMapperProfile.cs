using AutoMapper;
using xdcb.Common.DanhMuc.PhuongThucDauThauDtos;
using xdcb.Common.DanhMuc.PhuongThucDauThaus;

namespace xdcb.Common.DanhMuc
{
    public class PhuongThucDauThauApplicationAutoMapperProfile : Profile
    {
        public PhuongThucDauThauApplicationAutoMapperProfile()
        {
            CreateMap<PhuongThucDauThau, PhuongThucDauThauDto>();
            CreateMap<CreateUpdatePhuongThucDauThauDto, PhuongThucDauThau>();
            CreateMap<PhuongThucDauThauDto, CreateUpdatePhuongThucDauThauDto>();
        }
    }
}