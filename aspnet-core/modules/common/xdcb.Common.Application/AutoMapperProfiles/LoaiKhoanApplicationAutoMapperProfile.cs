using AutoMapper;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.LoaiKhoans;

namespace xdcb.Common
{
    public class LoaiKhoanApplicationAutoMapperProfile : Profile
    {
        public LoaiKhoanApplicationAutoMapperProfile()
        {
            CreateMap<LoaiKhoan, LoaiKhoanDto>();
            CreateMap<CreateUpdateLoaiKhoanDto, LoaiKhoan>();
            CreateMap<LoaiKhoanDto, CreateUpdateLoaiKhoanDto>();
        }
    }
}