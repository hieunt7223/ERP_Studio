using AutoMapper;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;
using xdcb.Common.DanhMuc.LinhVucVanBans;

namespace xdcb.Common.DanhMuc
{
    public class LinhVucVanBanApplicationAutoMapperProfile : Profile
    {
        public LinhVucVanBanApplicationAutoMapperProfile()
        {
            CreateMap<LinhVucVanBan, LinhVucVanBanDto>();
            CreateMap<CreateUpdateLinhVucVanBanDto, LinhVucVanBan>();
            CreateMap<LinhVucVanBanDto, CreateUpdateLinhVucVanBanDto>();
        }
    }
}
