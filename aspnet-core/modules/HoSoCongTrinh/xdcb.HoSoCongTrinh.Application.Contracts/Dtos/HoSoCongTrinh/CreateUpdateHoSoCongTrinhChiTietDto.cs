using System;
using System.Collections.Generic;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateHoSoCongTrinhChiTietDto
    {
        public Guid Id { get; set; }
        public Guid HoSoCongTrinhId { get; set; }

        public int SoLanDieuChinh { get; set; }

        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        public TrangThaiEnums TrangThai { get; set; }

        public DateTime HanXuLy { get; set; }

        /// <summary>
        /// Mục tiêu đầu tư
        /// </summary>
        public string MucTieuDauTu { get; set; }

        /// <summary>
        /// Ngành lĩnh vực sử dụng id
        /// </summary>
        public Guid? NganhLinhVucSuDungId { get; set; }

        /// <summary>
        /// Tổng mức đầu tư đã phê duyệt - loại điều chỉnh
        /// </summary>
        public decimal MucDauTuPheDuyet { get; set; }

        /// <summary>
        /// Tổng mức đầu tư bổ sung - loại điều chỉnh
        /// </summary>
        public decimal MucDauTuBoSung { get; set; }

        /// <summary>
        /// Nội dung và quy mô đầu tư đã phê duyệt - loại điều chỉnh
        /// </summary>
        public string NoiDungQuyMoDauTuPheDuyet { get; set; }

        /// <summary>
        /// Tổng mức đầu tư loại hồ sơ 3,4
        /// </summary>
        public decimal TongMucDauTu { get; set; }

        /// <summary>
        /// Tổng mức dự toán được duyệt loại hồ sơ 3,4
        /// </summary>
        public decimal MucDuToanDuocDuyet { get; set; }

        /// <summary>
        /// Nội dung và quy mô đầu tư đề xuất điều chỉnh, bổ sung - loại điều chỉnh
        /// </summary>
        public string NoiDungQuyMoDauTuDeXuatDieuChinh { get; set; }

        public ThamDinhDto YKienThamDinh { get; set; }

        /// <summary>
        /// Địa điểm xây dựng
        /// </summary>
        public List<CreateUpdateDiaDiemXayDungDto> DiaDiemXayDungs { get; set; }

        /// <summary>
        /// Nguồn vốn
        /// </summary>
        public List<CreateUpdateNguonVonDto> NguonVons { get; set; }

        /// <summary>
        /// Cơ sở pháp lý hồ sơ công trình
        /// </summary>
        public List<CreateUpdateCoSoPhapLyDto> CoSoPhapLys { get; set; }

        /// <summary>
        /// Thành phần hồ
        /// </summary>
        public List<CreateUpdateThanhPhanHoSoDto> ThanhPhanHoSos { get; set; }

        /// <summary>
        /// Kết quả thẩm định
        /// </summary>
        public List<CreateUpdateKetQuaThamDinhDto> KetQuaThamDinhs { get; set; }

        /// <summary>
        /// tab thẩm định gói thầu
        /// </summary>
        public ThamDinhGoiThauDto ThamDinhGoiThau { get; set; }

        /// <summary>
        /// tab thẩm định điều chỉnh gói thầu
        /// </summary>
        public ThamDinhDieuChinhGoiThauDto ThamDinhDieuChinhGoiThau { get; set; }
    }
}