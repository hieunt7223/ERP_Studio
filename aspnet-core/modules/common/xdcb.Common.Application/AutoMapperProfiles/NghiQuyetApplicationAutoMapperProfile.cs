using AutoMapper;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.Common.DanhMuc.NghiQuyets;

namespace xdcb.Common
{
    public class NghiQuyetApplicationAutoMapperProfile : Profile
    {
        public NghiQuyetApplicationAutoMapperProfile()
        {
            CreateMap<NghiQuyet, NghiQuyetDto>();
            CreateMap<CreateUpdateNghiQuyetDto, NghiQuyet>();
            CreateMap<NghiQuyetDto, CreateUpdateNghiQuyetDto>();
            CreateMap<NghiQuyetCongTrinh, NghiQuyetCongTrinhDto>();
        }
    }
}