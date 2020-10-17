using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class BaoCaoDieuChinhLuaChonNhaThau
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string tenCongTrinh { get; set; }
        public List<string> coSoPhapLys { get; set; }
        public List<string> thanhPhanHoSos { get; set; }
        public List<GoiThauKienNghi> goiThauDuocPheDuyets { get; set; }
        public List<GoiThauKienNghi> goiThauDeNghiDieuChinhs { get; set; }
        public string nhanXetDanhGiaCoQuanThamDinh { get; set; }
        public List<GoiThauKienNghi> goiThauDeXuats { get; set; }
        public string tenChuyenVien { get; set; }
        public string noiDungTrinhVaKienNghi { get; set; }
    }
}