using AutoMapper;
using Volo.Abp.AutoMapper;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.LoaiHoSos;

namespace xdcb.Common.DanhMuc
{
    public class LoaiHoSoApplicationAutoMapperProfile : Profile
    {
        public LoaiHoSoApplicationAutoMapperProfile()
        {
            CreateMap<LoaiHoSo, LoaiHoSoDto>();
            CreateMap<CreateUpdateLoaiHoSoDto, LoaiHoSo>()
                .Ignore(p => p.LoaiHoSoThanhPhanHoSos)
                .Ignore(p => p.LoaiHoSoCoSoPhapLys)
                .AfterMap((src, dest) => dest.InitializeNullCollections());
        }
    }
}