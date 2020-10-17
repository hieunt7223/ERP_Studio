using System.Collections.Generic;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class ThamDinhDto
    {
        /// <summary>
        /// Đơn vị chủ trì thẩm định
        /// </summary>
        public CapQuyetDinhThamDinhDto DonViChuTriThamDinh { get; set; }

        /// <summary>
        /// Đơn vị phối hợp thẩm định
        /// </summary>
        public List<CapQuyetDinhThamDinhDto> DonViPhoiHopThamDinhs { get; set; }

        /// <summary>
        /// Hình thức thẩm định
        /// </summary>
        public HinhThucThamDinhEnum HinhThucThamDinh { get; set; }

        /// <summary>
        /// Cấp quyết định chủ trương đầu tư dự án
        /// </summary>
        public CapQuyetDinhThamDinhDto CapQuyetDinhChuTruong { get; set; }

        /// <summary>
        /// Cấp quyết định đầu tư dự án
        /// </summary>
        public CapQuyetDinhThamDinhDto CapQuyetDinhDauTuDuAn { get; set; }

        /// <summary>
        /// Ý kiến của đơn vị phối hợp
        /// </summary>
        public string YKienThamDinhDonViPhoiHop { get; set; }

        #region ý kiến của đơn vị thẩm định

        /// <summary>
        /// Sự cần thiết đầu tư dự án
        /// </summary>
        public string SuCanThietDauTuDuAn { get; set; }

        /// <summary>
        /// Sự tuân thủ các quy định của pháp luật trong nội dung hồ sơ trình thẩm định
        /// </summary>
        public string SuTuanThuQuyDinh { get; set; }

        /// <summary>
        /// Sự phù hợp với các mục tiêu chiến lược
        /// </summary>
        public string SuPhuHopMucTieuChienLuoc { get; set; }

        /// <summary>
        /// Sự phù hợp với tiêu chí phân loại dự án nhóm A, nhóm B và nhóm C
        /// </summary>
        public string SuPhuHopMucTieuPhanLoai { get; set; }

        /// <summary>
        /// Các nội dung đầu tư
        /// </summary>
        public string NoiDungDauTu { get; set; }

        /// <summary>
        /// Ý kiến của đơn vị thẩm định
        /// </summary>
        public string YKienCuaDonViThamDinh { get; set; }

        #endregion ý kiến của đơn vị thẩm định

        /// <summary>
        /// Nội dung trình và kiến nghị của phòng/đơn vị tham mưu
        /// </summary>
        public string NoiDungTrinhVaKienNghi { get; set; }
    }
}