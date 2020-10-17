using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThongTinChiTietViewModel
    {
        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        /// <summary>
        /// Mục tiêu đầu tư
        /// </summary>
        public string MucTieuDauTu { get; set; }

        /// <summary>
        /// Tổng mức đầu tư đã phê duyệt - loại điều chỉnh
        /// </summary>
        public decimal MucDauTuPheDuyet { get; set; }

        /// <summary>
        /// Tổng mức đầu tư bổ sung - loại điều chỉnh
        /// </summary>
        public decimal MucDauTuBoSung { get; set; }

        /// <summary>
        /// Nội dung và quy mô đầu tư đã phê duyệt - loại điều chỉnh
        /// </summary>
        public string NoiDungQuyMoDauTuPheDuyet { get; set; }

        /// <summary>
        /// Nội dung và quy mô đầu tư đề xuất điều chỉnh, bổ sung - loại điều chỉnh
        /// </summary>
        public string NoiDungQuyMoDauTuDeXuatDieuChinh { get; set; }

        /// <summary>
        /// Tổng mức đầu tư loại hồ sơ 3,4
        /// </summary>
        public decimal TongMucDauTu { get; set; }

        /// <summary>
        /// Tổng mức dự toán được duyệt loại hồ sơ 3,4
        /// </summary>
        public decimal MucDuToanDuocDuyet { get; set; }

        public NganhLinhVucDto NganhLinhVucSuDung { get; set; }

        public List<DiaDiemThucHienViewModel> DiaDiemThucHiens { get; set; } = new List<DiaDiemThucHienViewModel>();

        public List<TongMucDauTuViewModel> TongMucDauTus { get; set; } = new List<TongMucDauTuViewModel>();

        /// <summary>
        /// Danh sách nguồn vốn
        /// </summary>
        public List<HoSoCongTrinhChiTietNguonVonDto> NguonVons { get; set; } = new List<HoSoCongTrinhChiTietNguonVonDto>();
    }
}