using AutoMapper;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;
using xdcb.Common.DanhMuc.DonViBanHanhs;

namespace xdcb.Common.DanhMuc
{
    public class DonViBanHanhApplicationAutoMapperProfile : Profile
    {
        public DonViBanHanhApplicationAutoMapperProfile()
        {
            CreateMap<DonViBanHanh, DonViBanHanhDto>();
            CreateMap<CreateUpdateDonViBanHanhDto, DonViBanHanh>();
            CreateMap<DonViBanHanhDto, CreateUpdateDonViBanHanhDto>();
        }
    }
}