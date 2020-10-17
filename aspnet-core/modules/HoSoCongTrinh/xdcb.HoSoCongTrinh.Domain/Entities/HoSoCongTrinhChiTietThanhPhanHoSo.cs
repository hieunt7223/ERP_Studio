using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietThanhPhanHoSo : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid ThanhPhanHoSoId { get; set; }

        public bool IsBatBuoc { get; set; }

        public string SoKyHieu { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public Guid? DonViBanHanhId { get; set; }

        public string TrichYeu { get; set; }

        public List<HoSoCongTrinhChiTietThanhPhanHoSoFile> HoSoCongTrinhChiTietThanhPhanHoSoFiles { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietThanhPhanHoSo()
        {
        }

        public HoSoCongTrinhChiTietThanhPhanHoSo(Guid id, Guid hoSoCongTrinhChiTietId, Guid thanhPhanHoSoId) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            ThanhPhanHoSoId = thanhPhanHoSoId;
            HoSoCongTrinhChiTietThanhPhanHoSoFiles = new List<HoSoCongTrinhChiTietThanhPhanHoSoFile>();
        }

        public void InitializeNullCollections()
        {
            HoSoCongTrinhChiTietThanhPhanHoSoFiles ??= new List<HoSoCongTrinhChiTietThanhPhanHoSoFile>();
        }
    }
}