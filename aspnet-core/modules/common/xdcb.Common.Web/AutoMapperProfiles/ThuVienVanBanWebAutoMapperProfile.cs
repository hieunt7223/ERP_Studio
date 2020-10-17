using AutoMapper;
using Volo.Abp.Identity;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.DanhMuc.DoUuTienDtos;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.DanhMuc.KhoanChiDtos;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using static xdcb.Common.DanhMuc.DoUuTiens.EditModalModel;
using static xdcb.Common.DanhMuc.GoiThaus.CreateModalModel;
using static xdcb.Common.DanhMuc.GoiThaus.EditModalModel;

namespace xdcb.Common.DanhMuc
{
    internal class ThuVienVanBanWebAutoMapperProfile : Profile
    {
        public ThuVienVanBanWebAutoMapperProfile()
        {
            // thư viện văn bản
            CreateMap<ThuVienVanBans.CreateModalModel.ThuVienVanBanViewModel, CreateUpdateThuVienVanBanDto>();
            CreateMap<ThuVienVanBans.EditModalModel.ThuVienVanBanViewModel, CreateUpdateThuVienVanBanDto>();
            CreateMap<ThuVienVanBanDto, ThuVienVanBans.EditModalModel.ThuVienVanBanViewModel>();

            // chương trình mục tiêu quốc gia
            CreateMap<ChuongTrinhMucTieuQuocGias.CreateModalModel.ChuongTrinhMucTieuQuocGiaViewModel, CreateUpdateChuongTrinhMucTieuQuocGiaDto>();
            CreateMap<ChuongTrinhMucTieuQuocGias.EditModalModel.ChuongTrinhMucTieuQuocGiaViewModel, CreateUpdateChuongTrinhMucTieuQuocGiaDto>();
            CreateMap<ChuongTrinhMucTieuQuocGiaDto, ChuongTrinhMucTieuQuocGias.EditModalModel.ChuongTrinhMucTieuQuocGiaViewModel>();

            // loại khoản
            CreateMap<LoaiKhoans.CreateModalModel.LoaiKhoanViewModel, CreateUpdateLoaiKhoanDto>();
            CreateMap<LoaiKhoans.EditModalModel.LoaiKhoanViewModel, CreateUpdateLoaiKhoanDto>();
            CreateMap<LoaiKhoanDto, LoaiKhoans.EditModalModel.LoaiKhoanViewModel>();

            // nguồn vốn
            CreateMap<NguonVons.CreateModalModel.NguonVonViewModel, CreateUpdateNguonVonDto>();
            CreateMap<NguonVons.EditModalModel.NguonVonViewModel, CreateUpdateNguonVonDto>();
            CreateMap<NguonVonDto, NguonVons.EditModalModel.NguonVonViewModel>();

            // thành phần hồ sơ
            CreateMap<ThanhPhanHoSos.CreateModalModel.ThanhPhanHoSoViewModel, CreateUpdateThanhPhanHoSoDto>();
            CreateMap<ThanhPhanHoSos.EditModalModel.ThanhPhanHoSoViewModel, CreateUpdateThanhPhanHoSoDto>();
            CreateMap<ThanhPhanHoSoDto, ThanhPhanHoSos.EditModalModel.ThanhPhanHoSoViewModel>();

            // loại công trình
            CreateMap<LoaiCongTrinhDto, CreateUpdateLoaiCongTrinhPageModel>();

            // loại văn bản
            CreateMap<LoaiVanBanDto, CreateUpdateLoaiVanBanPageModel>();

            // độ ưu tiên
            CreateMap<DoUuTienDto, CreateUpdateDoUuTienPageModel>();

            // lĩnh vực văn bản
            CreateMap<LinhVucVanBanDto, CreateUpdateLinhVucVanBanPageModel>();

            // nhóm công trình
            CreateMap<NhomCongTrinhDto, CreateUpdateNhomCongTrinhPageModel>();

            // Khoản chi
            CreateMap<KhoanChiDto, CreateUpdateKhoanChiPageModel>();

            // chủ đầu tư
            CreateMap<ChuDauTuDto, CreateUpdateChuDauTuPageModel>();

            // đơn vị hành chính
            CreateMap<DonViHanhChinhs.CreateModalModel.DonViHanhChinhViewModel, CreateUpdateDonViHanhChinhDto>();
            CreateMap<DonViHanhChinhs.EditModalModel.DonViHanhChinhViewModel, CreateUpdateDonViHanhChinhDto>();
            CreateMap<DonViHanhChinhDto, DonViHanhChinhs.EditModalModel.DonViHanhChinhViewModel>();

            // công trình
            CreateMap<CongTrinhs.CreateModalModel.CongTrinhViewModel, CreateUpdateCongTrinhDto>();
            CreateMap<CongTrinhs.EditModalModel.CongTrinhViewModel, CreateUpdateCongTrinhDto>();
            CreateMap<CongTrinhDto, CongTrinhs.EditModalModel.CongTrinhViewModel>();
            CreateMap<CongTrinhDto, CongTrinhs.DetailModalModel.CongTrinhViewModel>();

            // Loai ho so
            CreateMap<LoaiHoSoDto, CreateUpdateLoaiHoSoDto>();

            // Gói thầu
            CreateMap<GoiThauViewModel, CreateUpdateGoiThauDto>();
            CreateMap<GoiThauDto, GoiThauEditViewModel>();
            CreateMap<GoiThauEditViewModel, CreateUpdateGoiThauDto>();
        }
    }
}