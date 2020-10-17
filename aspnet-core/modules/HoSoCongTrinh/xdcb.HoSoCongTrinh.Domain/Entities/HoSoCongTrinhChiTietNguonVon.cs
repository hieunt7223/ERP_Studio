using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietNguonVon : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid NguonVonId { get; set; }

        /// <summary>
        /// Giá trị đề nghị
        /// </summary>
        public decimal GiaTriDeNghi { get; set; }

        /// <summary>
        /// Giá trị thẩm định
        /// </summary>
        public decimal GiaTriThamDinh { get; set; }

        /// <summary>
        /// Giá trị nguồn vốn bằng chữ
        /// </summary>
        public string GiaTriNguonVon { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietNguonVon()
        {
        }

        public HoSoCongTrinhChiTietNguonVon(Guid id, Guid hoSoCongTrinhChiTietId,
            Guid nguonVonId, decimal giaTriDeNghi, decimal giaTriThamDinh, string giaTriNguonVon) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            NguonVonId = nguonVonId;
            GiaTriDeNghi = giaTriDeNghi;
            GiaTriThamDinh = giaTriThamDinh;
            GiaTriNguonVon = giaTriNguonVon;
        }

        public HoSoCongTrinhChiTietNguonVon(Guid id, Guid hoSoCongTrinhChiTietId,
            Guid nguonVonId, string giaTriNguonVon) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            NguonVonId = nguonVonId;
            GiaTriNguonVon = giaTriNguonVon;
        }
    }
}