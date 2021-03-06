using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.QuanLyVon.KeHoachTongNguonChiTiets
{
    /// <summary>
    /// Generated Domain for Table : KeHoachTongNguon.
    /// </summary>
    public class KeHoachTongNguonChiTiet : BaseEntity
    {
        #region Generated By Column

        public Guid KeHoachTongNguonId { get; set; }

        public Guid NguonVonId { get; set; }

        public Guid NguonVonChaId { get; set; }

        public string TenNguonVon { get; set; }

        public decimal KeHoachDauNamTruoc { get; set; }

        public decimal KeHoachBoSungNamTruoc { get; set; }

        public decimal KeHoachDauNam { get; set; }

        public decimal KeHoachDauNamDuocDuyet { get; set; }

        public decimal DieuChinhTang { get; set; }

        public decimal DieuChinhGiam { get; set; }

        public decimal KeHoachBoSung { get; set; }
        public decimal KeHoachBoSungDuocDuyet { get; set; }

        public string GhiChuSoDauNam { get; set; }

        public string GhiChuUyBanDauNam { get; set; }

        public string GhiChuSoDieuChinh { get; set; }

        public string GhiChuUyBanDieuChinh { get; set; }

        public bool IsSelectDieuChinh { get; set; }

        public bool IsDeleteDieuChinh { get; set; }

        #endregion
    }
}