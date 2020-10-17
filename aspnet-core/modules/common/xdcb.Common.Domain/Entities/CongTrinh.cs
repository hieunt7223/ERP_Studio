using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias;
using xdcb.Common.DanhMuc.LoaiCongTrinhs;
using xdcb.Common.DanhMuc.LoaiKhoans;
using xdcb.Common.DanhMuc.NghiQuyets;
using xdcb.Common.DanhMuc.NhomCongTrinhs;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class CongTrinh : BaseEntity
    {
        public Guid? ChuDauTuId { get; set; }

        public string MaCongTrinh { get; set; }

        public string TenCongTrinh { get; set; }

        public Guid? NhomCongTrinhId { get; set; }

        public string MaSoDuAn { get; set; }

        public Guid? LoaiKhoanId { get; set; }

        public Guid? CTMTQuocGiaId { get; set; }

        public Guid? LoaiCongTrinhId { get; set; }

        /// <summary>
        /// Diện tích xây dựng
        /// </summary>
        public double? DienTich { get; set; }

        /// <summary>
        /// Thời gian thực hiện từ ngày
        /// </summary>
        public DateTime? ThoiGianThucHienTuNgay { get; set; }

        /// <summary>
        /// Thời gian thực hiện đến ngày
        /// </summary>
        public DateTime? ThoiGianThucHienDenNgay { get; set; }

        /// <summary>
        /// Số quyết định đầu tư
        /// </summary>
        public string SoQuyetDinhDauTu { get; set; }

        /// <summary>
        /// Ngày quyết định
        /// </summary>
        public DateTime? NgayQuyetDinhDauTu { get; set; }

        /// <summary>
        /// Tổng mức đầu tư
        /// </summary>
        public decimal? TongMucDauTu { get; set; }

        /// <summary>
        /// Ngân sách tỉnh
        /// </summary>
        public decimal? NST { get; set; }

        /// <summary>
        /// Ngân sách trung ương
        /// </summary>
        public decimal? NSTW { get; set; }

        /// <summary>
        /// Nguồn vốn ODA
        /// </summary>
        public decimal? ODA { get; set; }

        #region FK
        public ChuDauTu ChuDauTu { get; set; }

        public NhomCongTrinh NhomCongTrinh { get; set; }

        public LoaiKhoan LoaiKhoan { get; set; }

        public ChuongTrinhMucTieuQuocGia ChuongTrinhMucTieuQuocGia { get; set; }

        public LoaiCongTrinh LoaiCongTrinh { get; set; }

        public NghiQuyet NghiQuyet { get; set; }

        public List<DiaDiemXayDung> DiaDiemXayDungs { get; set; }
        public List<NghiQuyetCongTrinh> NghiQuyetCongTrinhs { get; set; }
        #endregion
    }
}