using AutoMapper;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungs;

namespace xdcb.Common.DanhMuc
{
    public class NganhLinhVucSuDungApplicationAutoMapperProfile : Profile
    {
        public NganhLinhVucSuDungApplicationAutoMapperProfile()
        {
            CreateMap<NganhLinhVucSuDung, NganhLinhVucSuDungDto>();
            CreateMap<CreateUpdateNganhLinhVucSuDungDto, NganhLinhVucSuDung>();
            CreateMap<NganhLinhVucSuDungDto, CreateUpdateNganhLinhVucSuDungDto>();
        }
    }
}