using AutoMapper;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.DanhMuc.DonViHanhChinhs;

namespace xdcb.Common.DanhMuc
{
    public class DonViHanhChinhApplicationAutoMapperProfile : Profile
    {
        public DonViHanhChinhApplicationAutoMapperProfile()
        {
            CreateMap<DonViHanhChinh, DonViHanhChinhDto>();
            CreateMap<CreateUpdateDonViHanhChinhDto, DonViHanhChinh>();
            CreateMap<DonViHanhChinhDto, CreateUpdateDonViHanhChinhDto>();
        }
    }
}