using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietDiaDiem : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid DonViHanhChinhId { get; set; }

        public string GhiChu { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietDiaDiem()
        {
        }

        public HoSoCongTrinhChiTietDiaDiem(Guid id, Guid hoSoCongTrinhChiTietId, Guid donViHanhChinhId, string ghiChu) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            DonViHanhChinhId = donViHanhChinhId;
            GhiChu = ghiChu;
        }
    }
}