using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietLoaiGoiThau : FullAuditedEntity<Guid>, IExtraProperties
    {
        public string TenLoaiGoiThau { get; set; }

        public string MoTa { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public List<HoSoCongTrinhChiTietGoiThau> HoSoCongTrinhChiTietGoiThaus { get; set; }

        protected HoSoCongTrinhChiTietLoaiGoiThau()
        {
        }

        public HoSoCongTrinhChiTietLoaiGoiThau(Guid id, string tenLoaiGoiThau, string moTa) : base(id)
        {
            TenLoaiGoiThau = tenLoaiGoiThau;
            MoTa = moTa;
        }
    }
}