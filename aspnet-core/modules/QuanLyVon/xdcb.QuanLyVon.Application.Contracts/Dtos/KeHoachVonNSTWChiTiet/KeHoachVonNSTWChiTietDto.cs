using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.QuanLyVon.KeHoachVonNSTWChiTiet.Dtos
{
    /// <summary>
    /// Generated Contracts Dto for Table : KeHoachVonNSTWChiTiet.
    /// </summary>
    public class KeHoachVonNSTWChiTietDto : FullAuditedEntityDto<Guid>
    {
        #region Generated By Column

        public Guid KeHoachVonNSTWId { get; set; }

        public Guid LoaiKhoanId { get; set; }

        public Guid CongTrinhId { get; set; }

        public Guid NhuCauKeHoachVonChiTietDauNamId { get; set; }

        public Guid NhuCauKeHoachVonChiTietDieuChinhId { get; set; }

        public decimal LuyKeVonTongCong { get; set; }

        public decimal LuyKeVonNamTruoc { get; set; }

        public decimal NhuCauKeHoachVonDauNam { get; set; }

        public decimal NhuCauKeHoachVonDieuChinh { get; set; }

        public decimal KeHoachVonDauNam { get; set; }

        public decimal KeHoachVonDauNamDuocDuyet { get; set; }

        public decimal DieuChinhTang { get; set; }

        public decimal DieuChinhGiam { get; set; }

        public decimal KeHoachVonDieuChinh { get; set; }

        public decimal KeHoachVonDieuChinhDuocDuyet { get; set; }

        public string GhiChuSoDauNam { get; set; }

        public string GhiChuUyBanDauNam { get; set; }

        public string GhiChuSoDieuChinh { get; set; }

        public string GhiChuUyBanDieuChinh { get; set; }

        public string StringKeHoachVonDauNam { get; set; }

        public string StringKeHoachVonDauNamDuocDuyet { get; set; }

        public string StringDieuChinhTang { get; set; }

        public string StringDieuChinhGiam { get; set; }

        public string StringKeHoachVonDieuChinh { get; set; }

        public string StringKeHoachVonDieuChinhDuocDuyet { get; set; }

        public bool IsSelectDieuChinh { get; set; }

        public bool IsDeleteDieuChinh { get; set; }

        #endregion

        #region Extra Property
        public string TenDanhMuc { get; set; }
        public string TenChuDauTu { get; set; }
        public Dictionary<string, decimal> Value { get; set; }
        public Guid KeHoachVonId { get; set; }
        public Guid ParentId { get; set; }
        public int OrderIndex { get; set; }
        public string STT { get; set; }
        public string TenLoaiCongTrinh { get; set; }
        public Guid LoaiCongTrinhId { get; set; }

        public string TenNhomCongTrinh { get; set; }
        public Guid NhomCongTrinhId { get; set; }
        public bool IsBold { get; set; }
        public string MaSoDuAn { get; set; }
        public string MaSoChuong { get; set; }
        public string MaChuongTrinh { get; set; }
        public string MaLoaiKhoan { get; set; }
        public string SoQuyetDinh { get; set; }
        public decimal TongMucDauTu { get; set; }
        public decimal MucDauTuNSTW { get; set; }
        public decimal TrungHanGiaiDoanTongCong { get; set; }
        public decimal TrungHanGiaiDoanNSTW { get; set; }
        public decimal TrungHanNamTongCong { get; set; }
        public decimal TrungHanNamNSTW { get; set; }
        public decimal KeHoachNamTruocTongCong { get; set; }
        public decimal KeHoachNamTruocNSTW { get; set; }
        public decimal GiaiNganNamTruocTongCong { get; set; }
        public decimal GiaiNganNamTruocNSTW { get; set; }
        public decimal TyLeGiaiNganNamTruocTongCong { get; set; }
        public decimal TyLeGiaiNganNamTruocNSTW { get; set; }
        #endregion
    }
}