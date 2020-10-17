using AutoMapper;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;

namespace xdcb.Common
{
    public class ChuongTrinhMucTieuQuocGiaApplicationAutoMapperProfile : Profile
    {
        public ChuongTrinhMucTieuQuocGiaApplicationAutoMapperProfile()
        {
            CreateMap<ChuongTrinhMucTieuQuocGia, ChuongTrinhMucTieuQuocGiaDto>();
            CreateMap<CreateUpdateChuongTrinhMucTieuQuocGiaDto, ChuongTrinhMucTieuQuocGia>();
            CreateMap<ChuongTrinhMucTieuQuocGiaDto, CreateUpdateChuongTrinhMucTieuQuocGiaDto>();
        }
    }
}