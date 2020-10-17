using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietCoSoPhapLy : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public Guid? ThuVienVanBanId { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        /// <summary>
        /// Thư viện văn bản # null được lưu từ danh mục thư viện văn bản
        /// nếu = null thì được lưu theo hồ sơ công trình
        /// </summary>
        public string NoiDungJson { get; set; }

        protected HoSoCongTrinhChiTietCoSoPhapLy()
        {
        }

        public HoSoCongTrinhChiTietCoSoPhapLy(Guid id, Guid hoSoCongTrinhChiTietId, Guid? thuVienVanBanId) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            ThuVienVanBanId = thuVienVanBanId;
        }

        public HoSoCongTrinhChiTietCoSoPhapLy(Guid id, Guid hoSoCongTrinhChiTietId, string noiDungJson) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
            NoiDungJson = noiDungJson;
        }
    }
}