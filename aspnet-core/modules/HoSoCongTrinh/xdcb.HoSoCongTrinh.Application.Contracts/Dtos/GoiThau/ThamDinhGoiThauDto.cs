using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThamDinhGoiThauDto
    {
        /// <summary>
        /// Tổng hợp kết quả thẩm định về căn cứ pháp lý
        /// </summary>
        public List<KetQuaThamDinhPhapLyDto> CanCuPhapLys { get; set; }

        /// <summary>
        /// Ý kiến thẩm định về căn cứ pháp lý
        /// </summary>
        public string YKienThamDinhCanCuPhapLy { get; set; }

        /// <summary>
        /// Danh sách phần công việc đã thực hiện
        /// </summary>
        public List<CongViecThucHienDto> CongViecThucHiens { get; set; }

        /// <summary>
        /// Danh sách phần công việc không áp dụng được một trong các hình thức lựa chọn nhà thầu
        /// </summary>
        public List<CongViecKhongApDungDto> CongViecKhongApDungs { get; set; }

        /// <summary>
        /// Danh sách phần công việc thuộc kế hoạch lựa chọn nhà thầu
        /// </summary>
        public List<CongViecThuocKeHoachDto> CongViecThuocKeHoachs { get; set; }

        /// <summary>
        /// Danh sách phần công việc chưa đủ điều kiện lập kế hoạch lựa chọn nhà thầu
        /// </summary>
        public List<CongViecChuaDuDieuKienLapKeHoachDto> CongViecChuaDuDieuKienLapKeHoachs { get; set; }

        /// <summary>
        /// Y kiến thẩm định về nội dung kế hoạch lựa chọn nhà thầu
        /// </summary>
        public string YKienThamDinhNoiDungKeHoach { get; set; }

        /// <summary>
        /// Ý kiến thẩm định về tổng giá trị của các công việc được thực hiện
        /// </summary>
        public string YKienThamDinhGiaTriCongViec { get; set; }

        /// <summary>
        /// Danh sách gói thầu kiến nghị
        /// </summary>
        public List<HoSoCongTrinhChiTietGoiThauDto> GoiThauThamDinhs { get; set; }

        /// <summary>
        /// Nội dung trình và kiến nghị
        /// </summary>
        public string NoiDungTrinhVaKienNghi { get; set; }
    }
}