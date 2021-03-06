﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace xdcb.QuanLyVon.NhuCauKeHoachVonChiTiets
{
    /// <summary>
    /// Generated Domain for Table : KeHoachTongNguon.
    /// </summary>
    public class NhuCauKeHoachVonChiTiet : BaseEntity
    {
        #region Generated By Column
        public Guid NhuCauKeHoachVonID { get; set; }
        public Guid CongTrinhID { get; set; }
        public decimal LuyKeKhoiLuongNamTruocNST { get; set; }
        public decimal LuyKeVonNamTruocNST { get; set; }
        public decimal NhuCauVonDauNamNST { get; set; }
        public decimal DieuChinhGiamNST { get; set; }
        public decimal DieuChinhTangNST { get; set; }
        public decimal NhuCauVonDieuChinhNST { get; set; }
        public string GhiChuDauNamNST { get; set; }
        public string GhiChuDieuChinhNST { get; set; }
        public string GhiChuChuyenVienDauNamNST { get; set; }
        public string GhiChuChuyenVienDieuChinhNST { get; set; }
        public bool IsSelectNST { get; set; }
        public decimal LuyKeKhoiLuongNamTruocNSTW { get; set; }
        public decimal LuyKeVonNamTruocNSTW { get; set; }
        public decimal NhuCauVonDauNamNSTW { get; set; }
        public decimal DieuChinhGiamNSTW { get; set; }
        public decimal DieuChinhTangNSTW { get; set; }
        public decimal NhuCauVonDieuChinhNSTW { get; set; }
        public string GhiChuDauNamNSTW { get; set; }
        public string GhiChuDieuChinhNSTW { get; set; }
        public string GhiChuChuyenVienDauNamNSTW { get; set; }
        public string GhiChuChuyenVienDieuChinhNSTW { get; set; }
        public bool IsSelectNSTW { get; set; }
        public decimal LuyKeKhoiLuongNamTruocODA { get; set; }
        public decimal LuyKeVonNamTruocODA { get; set; }
        public decimal NhuCauVonDauNamODA { get; set; }
        public decimal DieuChinhGiamODA { get; set; }
        public decimal DieuChinhTangODA { get; set; }
        public decimal NhuCauVonDieuChinhODA { get; set; }
        public string GhiChuDauNamODA { get; set; }
        public string GhiChuDieuChinhODA { get; set; }
        public string GhiChuChuyenVienDauNamODA { get; set; }
        public string GhiChuChuyenVienDieuChinhODA { get; set; }
        public bool IsSelectODA { get; set; }
        public bool IsSelectDieuChinh { get; set; }
        public bool IsDeleteDieuChinh { get; set; }
        public bool IsSelect { get; set; }
        #endregion
    }
}