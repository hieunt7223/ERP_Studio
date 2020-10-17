using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietNoiDungYeuCau : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public string NoiDung { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietNoiDungYeuCau()
        {
        }

        public HoSoCongTrinhChiTietNoiDungYeuCau(Guid id, Guid hoSoCongTrinhChiTietId, string noiDung) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            NoiDung = noiDung ?? throw new ArgumentNullException(nameof(noiDung));
        }
    }
}