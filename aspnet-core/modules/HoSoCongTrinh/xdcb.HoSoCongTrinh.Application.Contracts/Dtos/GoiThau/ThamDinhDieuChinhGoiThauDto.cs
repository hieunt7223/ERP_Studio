using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThamDinhDieuChinhGoiThauDto
    {
        /// <summary>
        /// Danh sách gói thầu được phê duyệt
        /// </summary>
        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThauDuocPheDuyets { get; set; }

        /// <summary>
        /// Danh sách gói thầu đề nghị điều chỉnh
        /// </summary>
        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThauDeNghiDieuChinhs { get; set; }

        /// <summary>
        /// Nhận xét đánh giá cơ quan thẩm định
        /// </summary>
        public string DanhGiaCoQuanThamDinh { get; set; }

        /// <summary>
        /// Danh sách gói thầu được đề xuất
        /// </summary>
        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThauDeXuats { get; set; }

        /// <summary>
        /// Nội dung trình và kiến nghị
        /// </summary>
        public string NoiDungTrinhVaKienNghi { get; set; }
    }
}