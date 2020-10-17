using AutoMapper;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;

namespace xdcb.Common.DanhMuc
{
    public class ThanhPhanHoSoApplicationAutoMapperProfile : Profile
    {
        public ThanhPhanHoSoApplicationAutoMapperProfile()
        {
            CreateMap<ThanhPhanHoSo, ThanhPhanHoSoDto>();
            CreateMap<CreateUpdateThanhPhanHoSoDto, ThanhPhanHoSo>();
            CreateMap<ThanhPhanHoSoDto, CreateUpdateThanhPhanHoSoDto>();
        }
    }
}
