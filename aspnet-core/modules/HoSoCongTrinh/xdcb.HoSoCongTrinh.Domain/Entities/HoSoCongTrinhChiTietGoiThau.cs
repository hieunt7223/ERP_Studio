using System;
using Volo.Abp.Domain.Entities.Auditing;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietGoiThau : FullAuditedEntity<Guid>, IExtraProperties
    {
        /// <summary>
        /// FK
        /// </summary>
        public Guid HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// get từ danh mục gói thầu
        /// </summary>
        public Guid? GoiThauId { get; set; }

        /// <summary>
        /// Giá gói thầu
        /// </summary>
        public decimal? GiaGoiThau { get; set; }

        public Guid? HinhThucLuaChonNhaThauId { get; set; }

        public Guid? PhuongThucLuaChonNhaThauId { get; set; }

        public string ThoiGianBatDau { get; set; }

        public Guid? LoaiHopDongId { get; set; }

        public string ThoiGianThucHien { get; set; }

        /// <summary>
        /// Kế hoạch nhà thầu được phê duyệt
        /// Kế hoạch nhà thầu được điều chỉnh
        /// </summary>
        public LoaiCongViecEnums LoaiKeHoach { get; set; }

        /// <summary>
        /// group gói thầu theo parent id
        /// </summary>
        public Guid? GoiThauParentId { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietGoiThau()
        {
        }

        public HoSoCongTrinhChiTietGoiThau(Guid id, Guid hoSoCongTrinhChiTietId, Guid goiThauId, decimal? giaGoiThau,
            Guid? hinhThucLuaChonNhaThauId, Guid? phuongThucLuaChonNhaThauId, Guid? loaiHopDongId,
            string thoiGianBatDau, string thoiGianThucHien) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            GoiThauId = goiThauId;
            GiaGoiThau = giaGoiThau;
            HinhThucLuaChonNhaThauId = hinhThucLuaChonNhaThauId;
            PhuongThucLuaChonNhaThauId = phuongThucLuaChonNhaThauId;
            LoaiHopDongId = loaiHopDongId;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianThucHien = thoiGianThucHien;
        }
    }
}