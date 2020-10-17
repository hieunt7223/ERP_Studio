using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinh : FullAuditedAggregateRoot<Guid>, IExtraProperties
    {
        public Guid CongTrinhId { get; set; }

        public Guid LoaiHoSoId { get; set; }

        public Guid ChuDauTuId { get; set; }

        public TrangThaiEnums TrangThai { get; set; }

        public DateTime HanXuLy { get; set; }

        public int SoLanDieuChinh { get; set; }

        /// <summary>
        /// Check chủ đầu tư hay chuyên viên insert
        /// </summary>
        public bool IsChuDauTu { get; set; }

        public List<HoSoCongTrinhChiTiet> HoSoCongTrinhChiTiets { get; protected set; }

        public int OrderIndex { get; set; }
        public Guid TenantId { get; set; }

        protected HoSoCongTrinh()
        {
        }

        public HoSoCongTrinh(Guid id, Guid congTrinhId, Guid loaiHoSoId, Guid chuDauTuId, TrangThaiEnums trangThai,
            DateTime hanXuLy, int soLanDieuChinh, bool isChuDauTu) : base(id)
        {
            CongTrinhId = congTrinhId;
            LoaiHoSoId = loaiHoSoId;
            ChuDauTuId = chuDauTuId;
            TrangThai = trangThai;
            HanXuLy = hanXuLy;
            SoLanDieuChinh = soLanDieuChinh;
            IsChuDauTu = isChuDauTu;
            HoSoCongTrinhChiTiets = new List<HoSoCongTrinhChiTiet>();
        }

        public void InitializeNullCollections()
        {
            HoSoCongTrinhChiTiets ??= new List<HoSoCongTrinhChiTiet>();
        }
    }
}