using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietThanhPhanHoSoFile : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietThanhPhanHoSoId { get; set; }

        public Guid? FileId { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTietThanhPhanHoSo HoSoCongTrinhChiTietThanhPhanHoSo { get; set; }

        protected HoSoCongTrinhChiTietThanhPhanHoSoFile()
        {
        }

        public HoSoCongTrinhChiTietThanhPhanHoSoFile(Guid id, Guid hoSoCongTrinhChiTietThanhPhanHoSoId, Guid? fileId) : base(id)
        {
            HoSoCongTrinhChiTietThanhPhanHoSoId = hoSoCongTrinhChiTietThanhPhanHoSoId;
            FileId = fileId;
        }
    }
}