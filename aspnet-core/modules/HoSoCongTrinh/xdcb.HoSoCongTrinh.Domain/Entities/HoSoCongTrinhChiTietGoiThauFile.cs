using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietGoiThauFile : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietGoiThauId { get; set; }

        public Guid FileId { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTietGoiThau HoSoCongTrinhChiTietGoiThau { get; set; }

        protected HoSoCongTrinhChiTietGoiThauFile()
        {
        }

        public HoSoCongTrinhChiTietGoiThauFile(Guid id, Guid hoSoCongTrinhChiTietGoiThauId, Guid fileId) : base(id)
        {
            HoSoCongTrinhChiTietGoiThauId = hoSoCongTrinhChiTietGoiThauId;
            FileId = fileId;
        }
    }
}