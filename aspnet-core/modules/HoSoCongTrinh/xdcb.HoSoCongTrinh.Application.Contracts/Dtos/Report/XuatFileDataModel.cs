using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class XuatFileDataModel
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public DeXuatChuTruongDauTuDataModel deXuatChuTruongDauTu { get; set; }
        public DieuChinhChuTruongDauTuDataModel dieuChinhChuTruongDauTu { get; set; }
    }

    public class DeXuatChuTruongDauTuDataModel
    {
        public string tenCongTrinh { get; set; }
        public string toTrinhSo { get; set; }
        public string ngayTrinh { get; set; }
        public List<string> coSoPhapLy { get; set; }
        public List<string> thanhPhanHoSo { get; set; }
        public string donViChuTriThamDinh { get; set; }
        public string tenDonViPhoiHop { get; set; }
        public string hinhThucThamDinh { get; set; }
        public string nhomDuAn { get; set; }
        public string capQuyetDinhChuTruongDauTu { get; set; }
        public string capQuyetDinhDauTuDuAn { get; set; }
        public string tenChuDauTu { get; set; }
        public string diaDiem { get; set; }
        public string duKienTongMucDauTu { get; set; }
        public List<string> nguonVonDauTu { get; set; }
        public string linhVucSuDung { get; set; }
        public string thoiGianThucHien { get; set; }
        public string yKienDonViPhoiHop { get; set; }
        public string suCanThietDauTuDuAn { get; set; }
        public string suTuanThuQuyDinhPhapLuat { get; set; }
        public string suPhuHopMucTieuChienLuoc { get; set; }
        public string suPhuHopTieuChiPhanLoai { get; set; }
        public string cacNoiDungDauTu { get; set; }
        public string yKienDonViThamDinh { get; set; }
        public string mucTieuDauTu { get; set; }
        public string quyMoVaHinhThucDauTu { get; set; }
        public string tenChuyenVien { get; set; }
        public string noiDungTrinhVaKienNghi { get; set; }
    }

    public class DieuChinhChuTruongDauTuDataModel : DeXuatChuTruongDauTuDataModel
    {
        public string mucDauTuPheDuyet { get; set; }
        public string mucDauTuBoSung { get; set; }
        public string quyMoDauTuPheDuyet { get; set; }
        public string quyMoDauTuDeXuatDieuChinh { get; set; }
    }
}