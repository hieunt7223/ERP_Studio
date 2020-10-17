using AutoMapper;
using xdcb.Common.DanhMuc.HangMucCongTrinhDtos;
using xdcb.Common.DanhMuc.HangMucCongTrinhs;

namespace xdcb.Common.DanhMuc
{
    public class HangMucCongTrinhApplicationAutoMapperProfile : Profile
    {
        public HangMucCongTrinhApplicationAutoMapperProfile()
        {
            CreateMap<HangMucCongTrinh, HangMucCongTrinhDto>();
            CreateMap<CreateUpdateHangMucCongTrinhDto, HangMucCongTrinh>();
            CreateMap<HangMucCongTrinhDto, CreateUpdateHangMucCongTrinhDto>();
        }
    }
}