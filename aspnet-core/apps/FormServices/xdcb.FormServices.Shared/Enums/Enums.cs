using System.ComponentModel;

namespace xdcb.FormServices.Shared
{
    #region ConfigSystem
    public enum Status
    {
        Alive,
        Delete
    }

    public enum ModuleType
    {
        Studio,
        Form
    }

    public enum ModuleName
    {
        [EnumDescription("Cấu hình cột trên lưới")]
        ConfigColumn,

        [EnumDescription("Generate Entity")]
        GenerateEntity,

        [EnumDescription("Import dữ liệu")]
        ImportData,

        [EnumDescription("Thiết kế báo cáo")]
        DesignReport,

        [EnumDescription("Thiết kế Grid View")]
        DesignGridView,

        [EnumDescription("Thiết kế Tree List")]
        DesignTreeList,

        [EnumDescription("Thiết kế giao diện")]
        DesignForm,

        [EnumDescription("Thiết kế chức năng")]
        DesignModule,

        [EnumDescription("Danh mục công trình")]
        CongTrinh,

        [EnumDescription("Kế hoạch tổng nguồn")]
        KeHoachTongNguon,

        [EnumDescription("Nhu cầu vốn đơn vị")]
        NhuCauVonDonVi,

        [EnumDescription("Nhu cầu vốn hằng năm")]
        NhuCauVonHangNam,

        [EnumDescription("Nhu cầu vốn trung hạn")]
        NhuCauVonTrungHan,

        [EnumDescription("Tổng hợp nhu cầu vốn đơn vị")]
        TongHopNhuCauVonDonVi,

        [EnumDescription("Tổng hợp nhu cầu vốn trung hạn")]
        TongHopNhuCauVonTrungHan,

        [EnumDescription("Tổng hợp nhu cầu vốn hằng năm")]
        TongHopNhuCauVonHangNam,

        [EnumDescription("Kế hoạch vốn theo nghị quyết")]
        KHVTheoNghiQuyet,

        [EnumDescription("Danh mục nghị quyết")]
        NghiQuyet,
        [EnumDescription("Kế hoạch vốn theo ngân sách tỉnh")]
        KHVTheoNganSachTinh,

        [EnumDescription("Kế hoạch vốn theo ngân sách trung ương")]
        KHVTheoNganSachTrungUong,

        [EnumDescription("Danh mục loại khoản")]
        LoaiKhoan,

        [EnumDescription("Danh mục nguồn vốn")]
        NguonVon,

        [EnumDescription("Chương trình mục tiêu quốc gia")]
        ChuongTrinhMucTieuQuocGia,

        [EnumDescription("Tổng hợp giải ngân")]
        TongHopGiaiNgan,
    }

    public enum TemplateFolder
    {
        KeHoachTongNguon
    }

    public enum ADConfigValueColumn
    {
        ADConfigKeyValue,
        ADConfigText,
        ADConfigKeyGroup
    }

    public enum ButtonAction
    {
        btnNew,
        btnNewByUI,
        btnNewNomal,
        btnSave,
        btnCancel,
        btnDelete,
        btnEdit,
        btnView,
        btnTrinh
    }

    public enum ConfigColumnFunctionCode
    {
        Module,
        Report
    }

    #endregion

    public enum ComboBaseControl
    {
        [EnumDescription("Khóa")]
        Key,

        [EnumDescription("Thông tin")]
        Value
    }
    public enum CreateDesignGrid
    {
        [EnumDescription("GridView_")]
        NewGridView,

        [EnumDescription("BandedGrid_")]
        NewBanded
    }

    public enum CreateDesignTree
    {
        [EnumDescription("TreeList_")]
        NewTreeList,
    }

    public enum UserLogin
    {
        [EnumDescription("chuyenvien")]
        chuyenvien,

        [EnumDescription("truongphong")]
        truongphong,
    }

    public enum PasswordLogin
    {
        [EnumDescription("abc123")]
        matkhau

    }
    #region Column Table
    public enum KeHoachTongNguonColumn
    {
        [EnumDescription("Năm")]
        Nam,

        [EnumDescription("Ngày quyết định")]
        NgayQuyetDinh,

        [EnumDescription("Ngày quyết định đầu năm")]
        NgayQuyetDinhDauNam,

        [EnumDescription("Ngày quyết định chỉnh sửa")]
        NgayQuyetDinhDieuChinh,

        [EnumDescription("Số quyết định")]
        SoQuyetDinh,

        [EnumDescription("Số quyết định đầu năm")]
        SoQuyetDinhDauNam,

        [EnumDescription("Số quyết định chỉnh sửa")]
        SoQuyetDinhDieuChinh,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNam,

        [EnumDescription("Kế hoạch đầu năm được duyệt")]
        KeHoachDauNamDuocDuyet,

        [EnumDescription("Kế hoạch sau bổ sung")]
        KeHoachSauBoSung,

        [EnumDescription("Kế hoạch được duyệt sau bổ sung")]
        KeHoachSauBoSungDuocDuyet,

        [EnumDescription("Trạng thái đầu năm")]
        TrangThaiDauNam,

        [EnumDescription("Trạng thái điều chỉnh")]
        TrangThaiDieuChinh,

        [EnumDescription("Đính kèm file")]
        DinhKemFile,

        [EnumDescription("Ghi chú đầu năm")]
        GhiChuDauNam,

        [EnumDescription("Ghi chú chỉnh sửa")]
        GhiChuDieuChinh,

        [EnumDescription("Loại kế hoạch")]
        LoaiKeHoach,

        [EnumDescription("Trạng thái")]
        TrangThai,

        [EnumDescription("Ghi chú")]
        GhiChu
    }
    public enum KeHoachTongNguonChiTietsColumn
    {
        [EnumDescription("ID Nguồn Vốn")]
        NguonVonId,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNamTruoc,

        [EnumDescription("Kế hoạch đầu năm được duyệt")]
        KeHoachDauNamDuocDuyet,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNam,

        [EnumDescription("Kế hoạch sau bổ sung năm")]
        KeHoachBoSungNamTruoc,

        [EnumDescription("Kế hoạch sau bổ sung")]
        KeHoachBoSung,

        [EnumDescription("Kế hoạch được duyệt sau bổ sung")]
        KeHoachBoSungDuocDuyet,

        [EnumDescription("Ghi chú UB")]
        GhiChuUyBanDauNam,

        [EnumDescription("Ghi chú Sở")]
        GhiChuSoDauNam,

        [EnumDescription("Ghi chú UB")]
        GhiChuUyBanDieuChinh,

        [EnumDescription("Ghi chú Sở")]
        GhiChuSoDieuChinh,

        [EnumDescription("Điều chỉnh tăng")]
        DieuChinhTang,

        [EnumDescription("Điều chỉnh giảm")]
        DieuChinhGiam,

        [EnumDescription("Nguồn vốn")]
        TenNguonVon,

        ID,
        NguonVonChaId,
    }
    public enum AttachedFileColumn
    {
        [EnumDescription("Thông tin file")]
        FileName,

        [EnumDescription("Xóa file")]
        ButtonDelete,
    }
    public enum CongTrinhColumn
    {
        [EnumDescription("ID công trình")]
        Id,

        [EnumDescription("Mã Công trình")]
        MaCongTrinh,

        [EnumDescription("Tên Công trình")]
        TenCongTrinh,
    }
    public enum ChuDauTuColumn
    {
        [EnumDescription("ID chủ đầu tư")]
        Id,

        [EnumDescription("Mã chương")]
        MaSoChuong,

        [EnumDescription("Tên chủ đầu tư")]
        Ten,
    }
    public enum NhuCauKeHoachVonColumn
    {
        [EnumDescription("STT")]
        STT,

        [EnumDescription("Năm kế hoạch")]
        Nam,

        [EnumDescription("Tên kế hoạch")]
        TenKeHoach,

        [EnumDescription("Loại kế hoạch")]
        LoaiKeHoach,

        [EnumDescription("Số đơn vị báo cáo")]
        CountChuDauTu,

        [EnumDescription("Tổng nhu cầu")]
        TongNhuCau,
    }
    public enum NhomCongTrinhColumn
    {
        [EnumDescription("ID công trình")]
        Id,

        [EnumDescription("Mã nhóm công trình")]
        MaNhomCongTrinh,

        [EnumDescription("Tên nhóm công trình")]
        TenNhomCongTrinh,
    }
    public enum LoaiKhoanColumn
    {
        [EnumDescription("ID loại-khoản")]
        Id,

        [EnumDescription("Mã số")]
        MaSo,

        [EnumDescription("Tên loại_khoản")]
        TenLoaiKhoan,

        [EnumDescription("Loại loại_khoản")]
        LoaiLoaiKhoan,

        [EnumDescription("Ghi chú")]
        GhiChu,

        [EnumDescription("Id cha")]
        LoaiKhoanChaID,
    }
    public enum ChuongTrinhMucTieuQuocGiaColumn
    {
        [EnumDescription("ID CTMT Quốc gia")]
        Id,

        [EnumDescription("Mã CTMT Quốc gia")]
        MaChuongTrinhMucTieuQuocGia,

        [EnumDescription("Tên CTMT Quốc gia")]
        TenChuongTrinhMucTieuQuocGia,
    }
    public enum LoaiCongTrinhColumn
    {
        [EnumDescription("ID loại công trình")]
        Id,

        [EnumDescription("Mã loại công trình")]
        MaLoaiCongTrinh,

        [EnumDescription("Tên loại công trình")]
        TenLoaiCongTrinh,
    }
    public enum DonViHanhChinhColumn
    {
        [EnumDescription("ID đơn vị hành chính")]
        Id,

        [EnumDescription("Mã đơn vị hành chính")]
        MaDonViHanhChinh,

        [EnumDescription("Tên đơn vị hành chính")]
        TenDonViHanhChinh,

        [EnumDescription("Đơn vị hành chính cha")]
        ParentId,

        [EnumDescription("Chọn")]
        Selected
    }
    public enum DiaDiemXayDungColumn
    {
        [EnumDescription("Công trình")]
        CongTrinhId,

        [EnumDescription("Đơn vị hành chính")]
        DonViHanhChinhId,

        [EnumDescription("Ghi chú")]
        GhiChu,

        [EnumDescription("Xóa dòng")]
        ButtonDelete
    }
    public enum KeHoachVonNQColumn
    {
        [EnumDescription("Năm")]
        Nam,

        [EnumDescription("Ngày quyết định")]
        NgayQuyetDinh,

        [EnumDescription("Ngày ban hành đầu năm")]
        NgayBanHanhDauNam,

        [EnumDescription("Ngày ban hành điều chỉnh")]
        NgayBanHanhDieuChinh,

        [EnumDescription("Số quyết định")]
        SoQuyetDinh,

        [EnumDescription("Số quyết định đầu năm")]
        SoQuyetDinhDauNam,

        [EnumDescription("Số quyết định chỉnh sửa")]
        SoQuyetDinhDieuChinh,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNam,

        [EnumDescription("Kế hoạch đầu năm được duyệt")]
        KeHoachDauNamDuocDuyet,

        [EnumDescription("Kế hoạch sau bổ sung")]
        KeHoachSauBoSung,

        [EnumDescription("Kế hoạch được duyệt sau bổ sung")]
        KeHoachSauBoSungDuocDuyet,

        [EnumDescription("Trạng thái đầu năm")]
        TrangThaiDauNam,

        [EnumDescription("Trạng thái điều chỉnh")]
        TrangThaiDieuChinh,

        [EnumDescription("Đính kèm file")]
        DinhKemFile,

        [EnumDescription("Ghi chú đầu năm")]
        GhiChuDauNam,

        [EnumDescription("Ghi chú chỉnh sửa")]
        GhiChuDieuChinh,

        [EnumDescription("Loại kế hoạch")]
        LoaiKeHoach,

        [EnumDescription("Trạng thái")]
        TrangThai,

        [EnumDescription("Ghi chú")]
        GhiChu
    }

    public enum KeHoachVonNSTColumn
    {
        [EnumDescription("Năm")]
        Nam,

        [EnumDescription("Ngày quyết định")]
        NgayQuyetDinh,

        [EnumDescription("Ngày ban hành đầu năm")]
        NgayBanHanhDauNam,

        [EnumDescription("Ngày ban hành điều chỉnh")]
        NgayBanHanhDieuChinh,

        [EnumDescription("Số quyết định")]
        SoQuyetDinh,

        [EnumDescription("Số quyết định đầu năm")]
        SoQuyetDinhDauNam,

        [EnumDescription("Số quyết định chỉnh sửa")]
        SoQuyetDinhDieuChinh,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNam,

        [EnumDescription("Kế hoạch đầu năm được duyệt")]
        KeHoachDauNamDuocDuyet,

        [EnumDescription("Kế hoạch sau bổ sung")]
        KeHoachSauBoSung,

        [EnumDescription("Kế hoạch được duyệt sau bổ sung")]
        KeHoachSauBoSungDuocDuyet,

        [EnumDescription("Trạng thái đầu năm")]
        TrangThaiDauNam,

        [EnumDescription("Trạng thái điều chỉnh")]
        TrangThaiDieuChinh,

        [EnumDescription("Đính kèm file")]
        DinhKemFile,

        [EnumDescription("Ghi chú đầu năm")]
        GhiChuDauNam,

        [EnumDescription("Ghi chú chỉnh sửa")]
        GhiChuDieuChinh,

        [EnumDescription("Loại kế hoạch")]
        LoaiKeHoach,

        [EnumDescription("Trạng thái")]
        TrangThai,

        [EnumDescription("Ghi chú")]
        GhiChu
    }

    public enum KeHoachVonNSTChiTietColumn
    {
        [EnumDescription("Dự kiến kế hoạch vốn năm ")]
        KeHoachVonDauNam,

        [EnumDescription("Kế hoạch vốn năm ")]
        KeHoachVonDauNamDuocDuyet,

        [EnumDescription("Lũy kế bố trí vốn đến năm ")]
        LuyKeVonNamTruoc,

        LuyKeVonTongCong,

        TenDanhMuc,


        CongTrinhId,

        TenChuDauTu,

        DieuChinhTang,

        DieuChinhGiam,

        KeHoachVonDieuChinh,

        KeHoachVonDieuChinhDuocDuyet
    }

    public enum KeHoachVonNQChiTietColumn
    {
        [EnumDescription("Dự kiến kế hoạch vốn năm ")]
        KeHoachVonDauNam,

        [EnumDescription("Kế hoạch vốn năm ")]
        KeHoachVonDauNamDuocDuyet,

        [EnumDescription("Lũy kế bố trí vốn đến năm ")]
        LuyKeVonNamTruoc,

        LuyKeVonTongCong,

        TenDanhMuc,

        NghiQuyetId,

        CongTrinhId,

        TenChuDauTu,

        DieuChinhTang,

        DieuChinhGiam,

        KeHoachVonDieuChinh,

        KeHoachVonDieuChinhDuocDuyet
    }

    public enum NguonVonColumn
    {
        [EnumDescription("ID Nguồn vốn ")]
        Id,

        [EnumDescription("Nguồn vốn cha")]
        ParentId,

        [EnumDescription("Chọn")]
        Selected
    }

    public enum NghiQuyetCongTrinhColumn
    {
        [EnumDescription("ID công trình")]
        CongTrinhId,

        [EnumDescription("Tên công trình")]
        TenCongTrinh,

        [EnumDescription("Chọn")]
        Selected
    }

    public enum KeHoachVonNSTWColumn
    {
        [EnumDescription("Năm")]
        Nam,

        [EnumDescription("Ngày quyết định")]
        NgayQuyetDinh,

        [EnumDescription("Ngày ban hành đầu năm")]
        NgayBanHanhDauNam,

        [EnumDescription("Ngày ban hành điều chỉnh")]
        NgayBanHanhDieuChinh,

        [EnumDescription("Số quyết định")]
        SoQuyetDinh,

        [EnumDescription("Số quyết định đầu năm")]
        SoQuyetDinhDauNam,

        [EnumDescription("Số quyết định chỉnh sửa")]
        SoQuyetDinhDieuChinh,

        [EnumDescription("Kế hoạch đầu năm")]
        KeHoachDauNam,

        [EnumDescription("Kế hoạch đầu năm được duyệt")]
        KeHoachDauNamDuocDuyet,

        [EnumDescription("Kế hoạch sau bổ sung")]
        KeHoachSauBoSung,

        [EnumDescription("Kế hoạch được duyệt sau bổ sung")]
        KeHoachSauBoSungDuocDuyet,

        [EnumDescription("Trạng thái đầu năm")]
        TrangThaiDauNam,

        [EnumDescription("Trạng thái điều chỉnh")]
        TrangThaiDieuChinh,

        [EnumDescription("Đính kèm file")]
        DinhKemFile,

        [EnumDescription("Ghi chú đầu năm")]
        GhiChuDauNam,

        [EnumDescription("Ghi chú chỉnh sửa")]
        GhiChuDieuChinh,

        [EnumDescription("Loại kế hoạch")]
        LoaiKeHoach,

        [EnumDescription("Trạng thái")]
        TrangThai,

        [EnumDescription("Ghi chú")]
        GhiChu
    }

    public enum KeHoachVonNSTWChiTietColumn
    {
        [EnumDescription("Dự kiến kế hoạch vốn năm ")]
        KeHoachVonDauNam,

        [EnumDescription("Kế hoạch vốn năm ")]
        KeHoachVonDauNamDuocDuyet,

        [EnumDescription("Lũy kế bố trí vốn đến năm ")]
        LuyKeVonNamTruoc,

        LuyKeVonTongCong,

        TenDanhMuc,

        LoaiKhoanId,

        CongTrinhId,

        TenChuDauTu,

        DieuChinhTang,

        DieuChinhGiam,

        KeHoachVonDieuChinh,

        KeHoachVonDieuChinhDuocDuyet
    }
    #endregion

    #region von
    public enum TrangThaiKeHoachTongNguon
    {
        [EnumDescription("Đang soạn")]
        DANG_SOAN,

        [EnumDescription("Đã trình")]
        DA_TRINH,

        [EnumDescription("Yêu cầu chỉnh sửa")]
        YEU_CAU_CHINH_SUA,

        [EnumDescription("Đã duyệt")]
        DUYET,

        [EnumDescription("Hoàn thành")]
        HOAN_THANH
    }
    public enum LoaiKeHoachTongNguon
    {
        [EnumDescription("Đầu năm")]
        DAU_NAM,

        [EnumDescription("Điều chỉnh")]
        DIEU_CHINH,
    }

    public enum KeHoachNhuCauVon
    {
        [EnumDescription("Nhu cầu vốn hằng năm")]
        HANG_NAM,

        [EnumDescription("Nhu cầu vốn trung hạn")]
        TRUNG_HAN,
    }

    public enum LoaiKeHoachNhuCauVon
    {
        [EnumDescription("Đầu năm")]
        DAU_NAM,

        [EnumDescription("Điều chỉnh")]
        DIEU_CHINH,
    }

    public enum TrangThaiKeHoachNhuCauVon
    {
        [EnumDescription("Đang soạn")]
        DANG_SOAN,

        [EnumDescription("Đã gửi")]
        DA_GUI,

        [EnumDescription("Đã chốt báo cáo")]
        DA_CHOT,
    }

    public enum TrangThaiKeHoachVon
    {
        [EnumDescription("Đang soạn")]
        DANG_SOAN,

        [EnumDescription("Đã trình")]
        DA_TRINH,

        [EnumDescription("Yêu cầu chỉnh sửa")]
        YEU_CAU_CHINH_SUA,

        [EnumDescription("Đã duyệt")]
        DUYET,

        [EnumDescription("Hoàn thành")]
        HOAN_THANH
    }
    public enum LoaiKeHoachVon
    {
        [EnumDescription("Đầu năm")]
        DAU_NAM,

        [EnumDescription("Điều chỉnh")]
        DIEU_CHINH,
    }

    public enum LoaiKeHoachGiaiNgan
    {
        [EnumDescription("Báo cáo trong năm")]
        TRONG_NAM,

        [EnumDescription("Kế hoạch kéo dài")]
        KEO_DAI
    }

    public enum TenKeHoachGiaiNgan
    {
        [EnumDescription("Năm")]
        NAM,

        [EnumDescription("Quý")]
        QUY,

        [EnumDescription("Tháng")]
        THANG
    }
    #endregion
}
