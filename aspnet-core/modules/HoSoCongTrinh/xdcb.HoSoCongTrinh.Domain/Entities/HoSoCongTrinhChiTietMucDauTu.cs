using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietMucDauTu : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid ChiPhiDauTuId { get; set; }

        public decimal SoTien { get; set; }

        public decimal SoTienThamDinh { get; set; }

        public bool IsBatBuoc { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietMucDauTu()
        {
        }

        public HoSoCongTrinhChiTietMucDauTu(Guid id, Guid hoSoCongTrinhChiTietId, Guid chiPhiDauTuId, decimal soTien, decimal soTienThamDinh, bool isBatBuoc) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            ChiPhiDauTuId = chiPhiDauTuId;
            SoTien = soTien;
            SoTienThamDinh = soTienThamDinh;
            IsBatBuoc = isBatBuoc;
        }
    }
}