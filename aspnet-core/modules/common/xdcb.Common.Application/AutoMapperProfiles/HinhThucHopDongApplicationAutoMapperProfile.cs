using AutoMapper;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;
using xdcb.Common.DanhMuc.HinhThucHopDongs;

namespace xdcb.Common.DanhMuc
{
    public class HinhThucHopDongApplicationAutoMapperProfile : Profile
    {
        public HinhThucHopDongApplicationAutoMapperProfile()
        {
            CreateMap<HinhThucHopDong, HinhThucHopDongDto>();
            CreateMap<CreateUpdateHinhThucHopDongDto, HinhThucHopDong>();
            CreateMap<HinhThucHopDongDto, CreateUpdateHinhThucHopDongDto>();
        }
    }
}
