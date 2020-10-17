using AutoMapper;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common
{
    public class CongTrinhApplicationAutoMapperProfile : Profile
    {
        public CongTrinhApplicationAutoMapperProfile()
        {
            CreateMap<CongTrinh, CongTrinhDto>();
            CreateMap<CreateUpdateCongTrinhDto, CongTrinh>();
            CreateMap<DiaDiemXayDung, DiaDiemXayDungDto>();
        }
    }
}