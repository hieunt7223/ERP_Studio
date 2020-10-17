using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietKetQuaThamDinh : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid? FileId { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietKetQuaThamDinh()
        {
        }

        public HoSoCongTrinhChiTietKetQuaThamDinh(Guid id, Guid hoSoCongTrinhChiTietId, Guid? fileId) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            FileId = fileId;
        }
    }
}