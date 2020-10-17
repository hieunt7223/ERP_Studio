using System;

namespace xdcb.FormServices.Shared
{
    public class TableName
    {
        #region Cấu hình
        public const string ADConfigColumnsTableName = "ADConfigColumns";
        public const string ADConfigValuesTableName = "ADConfigValues";
        #endregion

        #region Nghiệp vụ
        public const string KeHoachTongNguonVonHieuTableName = "KeHoachTongNguonVonHieu";
        public const string KeHoachTongNguonVonChungHieuTableName = "KeHoachTongNguonVonChungHieu";
        #endregion

        #region Danh muc
        public const string ChiTieuBaoCaoHieusTableName = "ChiTieuBaoCaoHieus";
        #endregion

        #region Constants of Property Names

        #endregion
    }

    public class Customs
    {
        public const String cstDataSource = "GGDataSource";
        public const String cstDataMember = "GGDataMember";
        public const String cstFieldGroup = "GGFieldGroup";
        public const String cstFieldRelation = "GGFieldRelation";
    }

    public class ToolbarName
    {
        public const String ToolbarAction = "Action";
        public const String ToolbarExtra = "Extra";

        public const String ToolbarButtonHome = "Home";
        public const String ToolbarButtonNew = "New";
        public const String ToolbarButtonEdit = "Edit";
        public const String ToolbarButtonDelete = "Delete";
        public const String ToolbarButtonCancel = "Cancel";
        public const String ToolbarButtonSave = "Save";
        public const String ToolbarButtonDuplicate = "Duplicate";
        public const String ToolbarButtonCopy = "Copy";
        public const String ToolbarButtonComplete = "Complete";
    }

    public class FormatValue
    {
        public const string N3 = "{0:n3}";
        public const string N2 = "{0:n2}";
        public const string N1 = "{0:n1}";
        public const string N0 = "{0:n0}";
        public const string DateTime = "dd/MM/yyyy";
    }

    public class TemplateExel
    {
        public const string kehoachtongnguondaunam = "kehoachtongnguondaunam.xlsx";
        public const string kehoachtongnguondieuchinh = "kehoachtongnguondieuchinh.xlsx";

        public const string KeHoachVonTheoNghiQuyet_DauNam = "KeHoachVonTheoNghiQuyet_DauNam.xlsx";
        public const string KeHoachVonTheoNghiQuyet_DieuChinh = "KeHoachVonTheoNghiQuyet_DieuChinh.xlsx";

        public const string KeHoachVonTheoNganSachTinh_DauNam = "KeHoachVonTheoNganSachTinh_DauNam.xlsx";
        public const string KeHoachVonTheoNganSachTinh_DieuChinh = "KeHoachVonTheoNganSachTinh_DieuChinh.xlsx";

        public const string KeHoachVonTheoNganSachTrungUong_DauNam = "KeHoachVonTheoNganSachTrungUong_DauNam.xlsx";
        public const string KeHoachVonTheoNganSachTrungUong_DieuChinh = "KeHoachVonTheoNganSachTrungUong_DieuChinh.xlsx";

        public const string NhuCauKeHoachVonHangNam_DauNam = "NhuCauKeHoachVonHangNam_DauNam.xlsx";
        public const string NhuCauKeHoachVonHangNam_DieuChinh = "NhuCauKeHoachVonHangNam_DieuChinh.xlsx";

        public const string NhuCauKeHoachVonTrungHan_DauNam = "NhuCauKeHoachVonTrungHan_DauNam.xlsx";
        public const string NhuCauKeHoachVonTrungHan_DieuChinh = "NhuCauKeHoachVonTrungHan_DieuChinh.xlsx";
    }

    public class ControlCustomTypeName
    {
        public const string GGLabel = "xdcb.FormServices.Component.GGLabel";
    }

    public class TemplateDesignGrid
    {
        public const string BandedGrid_NhuCauVonDauNamHangNam = "BandedGrid_NhuCauVonDauNamHangNam.xml";
        public const string BandedGrid_NhuCauVonDieuChinhHangNam = "BandedGrid_NhuCauVonDieuChinhHangNam.xml";
        public const string BandedGrid_NhuCauVonDauNamTrungHan = "BandedGrid_NhuCauVonDauNamTrungHan.xml";
        public const string BandedGrid_NhuCauVonDieuChinhTrungHan = "BandedGrid_NhuCauVonDieuChinhTrungHan.xml";


        public const string GridView_TongNhuCauVonDonVi = "GridView_TongNhuCauVonDonVi.xml";

        public const string GridView_DanhSachCongTrinh = "GridView_DanhSachCongTrinh.xml";
        public const string GridView_CongTrinh_DiaDiemXayDung = "GridView_CongTrinh_DiaDiemXayDung.xml";

        public const string GridView_KeHoachTongNguon_DinhKemFile = "GridView_KeHoachTongNguon_DinhKemFile.xml";

        public const string GridView_KeHoachVonTheoNghiQuyet = "GridView_KeHoachVonTheoNghiQuyet.xml";
        public const string GridView_KeHoachVonTheoNghiQuyet_DinhKemFile = "GridView_KeHoachVonTheoNghiQuyet_DinhKemFile.xml";

        public const string GridView_DanhSachNghiQuyet = "GridView_DanhSachNghiQuyet.xml";
        public const string GridView_NghiQuyet_NghiQuyetCongTrinh = "GridView_NghiQuyet_NghiQuyetCongTrinh.xml";

        public const string GridView_KeHoachVonTheoNganSachTrungUong = "GridView_KeHoachVonTheoNganSachTrungUong.xml";
        public const string GridView_KeHoachVonTheoNganSachTrungUong_DinhKemFile = "GridView_KeHoachVonTheoNganSachTrungUong_DinhKemFile.xml";



        public const string GridView_KeHoachVonTheoNganSachTinh = "GridView_KeHoachVonTheoNganSachTinh.xml";
        public const string GridView_KeHoachVonTheoNganSachTinh_DinhKemFile = "GridView_KeHoachVonTheoNganSachTinh_DinhKemFile.xml";

        public const string GridView_TongHopGiaiNgan = "GridView_TongHopGiaiNgan.xml";
    }

    public class TemplateDesignTreeList
    {
        public const string TreeList_DonViHanhChinh = "TreeList_DonViHanhChinh.xml";

        public const string TreeList_KeHoachVonNghiQuyet_DauNam = "TreeList_KeHoachVonNghiQuyet_DauNam.xml";

        public const string TreeList_KeHoachVonNghiQuyet_DieuChinh = "TreeList_KeHoachVonNghiQuyet_DieuChinh.xml";

        public const string TreeList_KeHoachVonNghiQuyetHangNamDieuChinh = "TreeList_KeHoachVonNghiQuyetHangNamDieuChinh.xml";

        public const string TreeList_KeHoachVonNghiQuyet_NguonVon = "TreeList_KeHoachVonNghiQuyet_NguonVon.xml";

        public const string TreeList_KeHoachVonNganSachTinh_NguonVon = "TreeList_KeHoachVonNganSachTinh_NguonVon.xml";

        public const string TreeList_KeHoachVonNganSachTinh_DauNam = "TreeList_KeHoachVonNganSachTinh_DauNam.xml";

        public const string TreeList_KeHoachVonNganSachTinh_DieuChinh = "TreeList_KeHoachVonNganSachTinh_DieuChinh.xml";

        public const string TreeList_KeHoachVonNganSachTinhHangNamDieuChinh = "TreeList_KeHoachVonNganSachTinhHangNamDieuChinh.xml";

        public const string TreeList_CongTrinh = "TreeList_CongTrinh.xml";

        public const string TreeList_KeHoachVonNganSachTrungUong_DauNam = "TreeList_KeHoachVonNganSachTrungUong_DauNam.xml";

        public const string TreeList_KeHoachVonNganSachTrungUong_DieuChinh = "TreeList_KeHoachVonNganSachTrungUong_DieuChinh.xml";

        public const string TreeList_UI_CongTrinh = "TreeList_UI_CongTrinh.xml";

        public const string TreeList_UI_NguonVon = "TreeList_UI_NguonVon.xml";


        public const string TreeList_DanhSachLoaiKhoan = "TreeList_DanhSachLoaiKhoan.xml";

        public const string TreeList_DanhSachNguonVon = "TreeList_DanhSachNguonVon.xml";

        public const string TreeList_DanhSachChuongTrinhMucTieuQuocGia = "TreeList_DanhSachChuongTrinhMucTieuQuocGia.xml";

        public const string TreeList_GiaiNgan_NST = "TreeList_GiaiNgan_NST.xml";
        public const string TreeList_GiaiNgan_NSTW = "TreeList_GiaiNgan_NSTW.xml";
        public const string TreeList_GiaiNgan_ODA = "TreeList_GiaiNgan_ODA.xml";

    }

    public class pathUploadFile
    {
        public const string pathPost = "/api/app/document";
        public const string pathGetList = "/api/app/documentStore/filesInfoByIds";
        public const string pathDownload = "/api/app/documentStore/download";
    }
}
