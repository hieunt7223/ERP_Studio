using System;
using Volo.Abp.Domain.Entities;

namespace xdcb.HoSoCongTrinh.Entities
{
    /// <summary>
    /// View Hồ sơ công trình
    /// Left join table công trình và hồ sơ công trình
    /// </summary>
    public class vHoSoCongTrinh : Entity<Guid>
    {
        /// <summary>
        /// Tên công trình
        /// </summary>
        public string TenCongTrinh { get; set; }

        /// <summary>
        /// Mã công trình
        /// </summary>
        public string MaCongTrinh { get; set; }

        /// <summary>
        /// Id chủ đầu tư
        /// </summary>
        public Guid? ChuDauTuId { get; set; }

        /// <summary>
        /// Id mã loại khoản
        /// </summary>
        public Guid? LoaiKhoanId { get; set; }

        /// <summary>
        /// Id chương trình mục tiêu quốc gia
        /// </summary>
        public Guid? CTMTQuocGiaId { get; set; }

        /// <summary>
        /// Id Loại công trình
        /// </summary>
        public Guid? LoaiCongTrinhId { get; set; }

        /// <summary>
        /// Id nhóm công trình
        /// </summary>
        public Guid? NhomCongTrinhId { get; set; }

        /// <summary>
        /// Thời gian thực hiện công trình từ ngày
        /// </summary>
        public DateTime? ThoiGianThucHienTuNgay { get; set; }

        /// <summary>
        /// Thời gian thực hiện công trình đến ngày
        /// </summary>
        public DateTime? ThoiGianThucHienDenNgay { get; set; }

        /// <summary>
        /// Diện tích thực hiện công trình
        /// </summary>
        public double? DienTich { get; set; }

        /// <summary>
        /// Thực hiện sort theo ngày giờ chỉnh sửa cuối cùng
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        #region ho so cong trinh

        /// <summary>
        /// Id Hồ sơ công trình
        /// </summary>
        public Guid? HoSoCongTrinhId { get; set; }

        /// <summary>
        /// Id Loại hồ sơ
        /// </summary>
        public Guid? LoaiHoSoId { get; set; }

        /// <summary>
        /// Trạng thái hồ sơ
        /// </summary>
        public int? TrangThai { get; set; } = 0;

        /// <summary>
        /// Hạn xử lý
        /// </summary>
        public DateTime? HanXuLy { get; set; }

        /// <summary>
        /// Số lần điều chỉnh hồ sơ
        /// </summary>
        public int? SoLanDieuChinh { get; set; }

        public bool? IsChuDauTu { get; set; }

        #endregion ho so cong trinh
    }
}