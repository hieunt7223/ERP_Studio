using System.Collections.Generic;

namespace Report.Models
{
    public class BaoCaoLuaChonNhaThau
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string tenCongTrinh { get; set; }
        public List<string> coSoPhapLys { get; set; }
        public List<string> thanhPhanHoSos { get; set; }
        public string tongMucDauTu { get; set; }
        public string tongMucDuToan { get; set; }
        public string chuDauTu { get; set; }
        public List<string> nguonVonDauTus { get; set; }
        public string thoiGianThucHien { get; set; }
        public string diaDiemThucHiens { get; set; }
        public string quyMoDauTu { get; set; }
        public string giaTriCongViecThucHien { get; set; }
        public string giaTriCongViecKhongApDung { get; set; }
        public string giaTriCongViecThuocKeHoach { get; set; }
        public string giaTriCongViecThuocKeHoachBangChu { get; set; }
        public string giaTriCongViecChuaDuDieuKien { get; set; }
        public string tongGiaTriCacPhanCongViec { get; set; }
        public string toChucThamDinh { get; set; }
        public List<ThamDinhCoSoPhapLy> thamDinhCanCuPhapLys { get; set; }
        public string yKienThamDinhCanCuPhapLy { get; set; }
        public List<CongViecGoiThau> congViecDaThucHiens { get; set; }
        public List<CongViecGoiThau> congViecKhongApDungs { get; set; }
        public List<ThamDinhCoSoPhapLy> congViecThuocKeHoachs { get; set; }
        public string yKienThamDinhVeNoiDungkeHoachLuaChon { get; set; }
        public List<CongViecGoiThau> congViecChuaDuDieuKiens { get; set; }
        public string yKienThamDinhVeTongGiaTri { get; set; }
        public List<GoiThauKienNghi> goiThauKienNghis { get; set; }
        public string tenChuyenVien { get; set; }
        public string noiDungTrinhVaKienNghi { get; set; }
    }

    public class ThamDinhCoSoPhapLy
    {
        public string noiDungKiemTra { get; set; }
        public string coKetQua { get; set; }
        public string khongCoKetQua { get; set; }
    }

    public class CongViecGoiThau
    {
        public string noiDungCongViec { get; set; }
        public string donViThucHien { get; set; }
        public string giaTriThucHien { get; set; }
    }

    public class GoiThauKienNghi
    {
        public string tenGoiThauCha { get; set; }
        public List<GoiThauCon> goiThauCons { get; set; }
    }

    public class GoiThauCon
    {
        public string tenGoiThau { get; set; }
        public string giaGoiThau { get; set; }
        public string tenHinhThuc { get; set; }
        public string tenPhuongThuc { get; set; }
        public string thoiGianBatDau { get; set; }
        public string loaiHopDong { get; set; }
        public string thoiGianThucHien { get; set; }
    }
}