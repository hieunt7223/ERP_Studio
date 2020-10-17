using System;
using Volo.Abp.Domain.Entities.Auditing;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTietCongViec : FullAuditedEntity<Guid>, IExtraProperties
    {
        /// <summary>
        /// FK
        /// </summary>
        public Guid HoSoCongTrinhChiTietId { get; set; }

        /// <summary>
        /// Get từ danh mục công việc gói thầu
        /// </summary>
        public Guid? CongViecGoiThauId { get; set; }

        /// <summary>
        /// get từ danh mục chủ đầu tư
        /// </summary>
        public Guid? DonViThucHienId { get; set; }

        /// <summary>
        /// đơn vị thực hiện
        /// </summary>
        public string DonViThucHien { get; set; }

        /// <summary>
        /// Giá trị thực hiện
        /// </summary>
        public decimal GiaTriThucHien { get; set; }

        /// <summary>
        /// có tuân thủ phù hợp
        /// </summary>
        public bool IsTuanThuPhuHop { get; set; }

        public LoaiCongViecEnums LoaiCongViec { get; set; }

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinhChiTiet HoSoCongTrinhChiTiet { get; set; }

        protected HoSoCongTrinhChiTietCongViec()
        {
        }

        public HoSoCongTrinhChiTietCongViec(Guid id, Guid hoSoCongTrinhChiTietId) : base(id)
        {
            HoSoCongTrinhChiTietId = hoSoCongTrinhChiTietId;
        }
    }
}