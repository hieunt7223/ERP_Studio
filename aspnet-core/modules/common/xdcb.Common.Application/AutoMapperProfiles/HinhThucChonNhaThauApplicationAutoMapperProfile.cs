using AutoMapper;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;
using xdcb.Common.DanhMuc.HinhThucChonNhaThaus;

namespace xdcb.Common.DanhMuc
{
    public class HinhThucChonNhaThauApplicationAutoMapperProfile : Profile
    {
        public HinhThucChonNhaThauApplicationAutoMapperProfile()
        {
            CreateMap<HinhThucChonNhaThau, HinhThucChonNhaThauDto>();
            CreateMap<CreateUpdateHinhThucChonNhaThauDto, HinhThucChonNhaThau>();
            CreateMap<HinhThucChonNhaThauDto, CreateUpdateHinhThucChonNhaThauDto>();
        }
    }
}
