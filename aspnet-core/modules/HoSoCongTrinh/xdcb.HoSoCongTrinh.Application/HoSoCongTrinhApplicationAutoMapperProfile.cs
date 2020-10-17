using AutoMapper;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Entities;

namespace xdcb.HoSoCongTrinh
{
    public class HoSoCongTrinhApplicationAutoMapperProfile : Profile
    {
        public HoSoCongTrinhApplicationAutoMapperProfile()
        {
            // Yêu cầu chỉnh sửa
            CreateMap<HoSoCongTrinhChiTietNoiDungYeuCau, HoSoCongTrinhChiTietNoiDungYeuCauDto>();
            CreateMap<CreateUpdateHoSoCongTrinhChiTietNoiDungYeuCauDto, HoSoCongTrinhChiTietNoiDungYeuCau>(MemberList.Source);
            // Hồ sơ công trình
            CreateMap<Entities.HoSoCongTrinh, HoSoCongTrinhDto>();
            CreateMap<CreateUpdateHoSoCongTrinhDto, Entities.HoSoCongTrinh>(MemberList.Source)
                .AfterMap((src, dest) => dest.InitializeNullCollections());
            CreateMap<HoSoCongTrinhChiTiet, HoSoCongTrinhChiTietDto>();
            CreateMap<CreateUpdateHoSoCongTrinhChiTietDto, HoSoCongTrinhChiTiet>(MemberList.Source)
                .ForMember(prop => prop.DonViChuTriThamDinhId, dto => dto.MapFrom(s => s.YKienThamDinh.DonViChuTriThamDinh.Id))
                .ForMember(prop => prop.HinhThucThamDinh, dto => dto.MapFrom(s => s.YKienThamDinh.HinhThucThamDinh))
                .ForMember(prop => prop.CapQuyetDinhChuTruongDauTu, dto => dto.MapFrom(s => s.YKienThamDinh.CapQuyetDinhChuTruong.Id))
                .ForMember(prop => prop.CapQuyetDinhDauTuDuAn, dto => dto.MapFrom(s => s.YKienThamDinh.CapQuyetDinhDauTuDuAn.Id))
                .ForMember(prop => prop.YKienThamDinhDonViPhoiHop, dto => dto.MapFrom(s => s.YKienThamDinh.YKienThamDinhDonViPhoiHop))
                .ForMember(prop => prop.SuCanThietDauTuDuAn, dto => dto.MapFrom(s => s.YKienThamDinh.SuCanThietDauTuDuAn))
                .ForMember(prop => prop.SuTuanThuQuyDinh, dto => dto.MapFrom(s => s.YKienThamDinh.SuTuanThuQuyDinh))
                .ForMember(prop => prop.SuPhuHopMucTieuChienLuoc, dto => dto.MapFrom(s => s.YKienThamDinh.SuPhuHopMucTieuChienLuoc))
                .ForMember(prop => prop.SuPhuHopMucTieuPhanLoai, dto => dto.MapFrom(s => s.YKienThamDinh.SuPhuHopMucTieuPhanLoai))
                .ForMember(prop => prop.NoiDungDauTu, dto => dto.MapFrom(s => s.YKienThamDinh.NoiDungDauTu))
                .ForMember(prop => prop.YKienCuaDonViThamDinh, dto => dto.MapFrom(s => s.YKienThamDinh.YKienCuaDonViThamDinh))
                .ForMember(prop => prop.NoiDungTrinhVaKienNghi, dto => dto.MapFrom(s => s.YKienThamDinh.NoiDungTrinhVaKienNghi))
                .ForMember(prop => prop.TongMucDuToanDuocDuyet, dto => dto.MapFrom(s => s.MucDuToanDuocDuyet))
                .AfterMap((src, dest) => dest.InitializeNullCollections());
            // Địa điểm xây dựng
            CreateMap<HoSoCongTrinhChiTietDiaDiem, HoSoCongTrinhChiTietDiaDiemXayDungDto>();
            CreateMap<CreateUpdateDiaDiemXayDungDto, HoSoCongTrinhChiTietDiaDiem>(MemberList.Source);
            // Tổng mức đầu tư
            CreateMap<HoSoCongTrinhChiTietMucDauTu, HoSoCongTrinhChiTietMucDauTuDto>();
            CreateMap<CreateUpdateMucDauTuDto, HoSoCongTrinhChiTietMucDauTu>(MemberList.Source);
            // Cơ sở pháp lý
            CreateMap<HoSoCongTrinhChiTietCoSoPhapLy, HoSoCongTrinhChiTietCoSoPhapLyDto>();
            CreateMap<CreateUpdateCoSoPhapLyDto, HoSoCongTrinhChiTietCoSoPhapLy>(MemberList.Source);
            // Kết quả thẩm định
            CreateMap<HoSoCongTrinhChiTietKetQuaThamDinh, HoSoCongTrinhChiTietKetQuaThamDinhDto>();
            CreateMap<CreateUpdateKetQuaThamDinhDto, HoSoCongTrinhChiTietKetQuaThamDinh>(MemberList.Source);
            // Thành phần hồ sơ
            CreateMap<HoSoCongTrinhChiTietThanhPhanHoSo, HoSoCongTrinhChiTietThanhPhanHoSoDto>();
            CreateMap<CreateUpdateThanhPhanHoSoDto, HoSoCongTrinhChiTietThanhPhanHoSo>(MemberList.Source)
                .AfterMap((src, dest) => dest.InitializeNullCollections());
            // Thành phần hồ sơ file
            CreateMap<HoSoCongTrinhChiTietThanhPhanHoSoFile, HoSoCongTrinhChiTietThanhPhanHoSoFileDto>();
            CreateMap<CreateUpdateThanhPhanHoSoFileDto, HoSoCongTrinhChiTietThanhPhanHoSoFile>(MemberList.Source);

            // Danh sách gói thầu kiến nghị
            CreateMap<HoSoCongTrinhChiTietGoiThau, HoSoCongTrinhChiTietGoiThauDto>();
        }
    }
}