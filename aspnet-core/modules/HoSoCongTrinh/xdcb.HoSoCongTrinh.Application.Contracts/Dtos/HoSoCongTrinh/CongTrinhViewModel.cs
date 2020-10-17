using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CongTrinhViewModel
    {
        /// <summary>
        /// Id Công trình
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Mã công trình
        /// </summary>
        public string MaCongTrinh { get; set; }

        /// <summary>
        /// Tên công trình
        /// </summary>
        public string Ten { get; set; }

        /// <summary>
        /// Id Loại khoản
        /// </summary>
        public Guid? LoaiKhoanId { get; set; }

        /// <summary>
        /// Mã Loại khoản
        /// </summary>
        public string MaLoaiKhoan { get; set; }

        /// <summary>
        /// Id chương trình mục tiêu quốc gia
        /// </summary>
        public Guid? CTMTQuocGiaId { get; set; }

        /// <summary>
        /// Ma Chương trình mục tiêu quốc gia
        /// </summary>
        public string MaChuongTrinhMucTieuQuocGia { get; set; }

        /// <summary>
        /// Id nhóm công trình
        /// </summary>
        public Guid? NhomCongTrinhId { get; set; }

        /// <summary>
        /// Nhóm công trình
        /// </summary>
        public string NhomCongTrinh { get; set; }

        /// <summary>
        /// Id Loại công trình
        /// </summary>
        public Guid? LoaiCongTrinhId { get; set; }

        /// <summary>
        /// Tên loại công trình
        /// </summary>
        public string LoaiCongTrinh { get; set; }

        /// <summary>
        /// Thời gian thực hiện từ ngày
        /// </summary>
        public string ThoiGianThucHienTuNgay { get; set; }

        /// <summary>
        /// Thời gian thực hiện đến ngày
        /// </summary>
        public string ThoiGianThucHienDenNgay { get; set; }

        /// <summary>
        /// Diện tích
        /// </summary>
        public double? DienTich { get; set; }
    }
}