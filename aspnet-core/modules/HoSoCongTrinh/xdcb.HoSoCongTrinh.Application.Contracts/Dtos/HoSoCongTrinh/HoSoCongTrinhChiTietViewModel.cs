using System;
using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietViewModel
    {
        /// <summary>
        /// Id Hồ sơ công trình chi tiết
        /// </summary>
        public Guid HoSoCongTrinhChiTietId { get; set; }

        public int SoLanDieuChinhChiTiet { get; set; }

        public DateTime HanXuLyChiTiet { get; set; }

        /// <summary>
        /// đánh dấu loại hồ sơ được expand
        /// </summary>
        public bool Expand { get; set; } = false;

        public int TrangThaiChiTiet { get; set; }

        /// <summary>
        /// BaoCaoDeXuatChuTruongDauTu
        /// BaoCaoDieuChinhChuTruongDauTu
        /// ThamDinhKeHoachLuaChonNhaThau
        /// ThamDinhDieuChinhKeHoachLuaChonNhaThau
        /// </summary>
        public string TenViewLoaiHoSo { get; set; }

        public TrangThaiXuLyViewModel TrangThaiXuLy { get; set; }

        public ThongTinChiTietViewModel ThongTinChiTiet { get; set; }

        public List<ThanhPhanHoSoViewModel> ThanhPhanHoSos { get; set; } = new List<ThanhPhanHoSoViewModel>();

        public List<CoSoPhapLyViewModel> CoSoPhapLys { get; set; } = new List<CoSoPhapLyViewModel>();

        public ThamDinhDto YKienThamDinh { get; set; }

        /// <summary>
        /// Tab gói thầu thẩm định loại hồ sơ 3
        /// </summary>
        public ThamDinhGoiThauDto ThamDinhGoiThau { get; set; }

        /// <summary>
        /// Tab gói thầu thẩm định điều chỉnh loại hồ sơ 4
        /// </summary>
        public ThamDinhDieuChinhGoiThauDto ThamDinhDieuChinhGoiThau { get; set; }

        public List<KetQuaThamDinhViewModel> KetQuaThamDinhs { get; set; } = new List<KetQuaThamDinhViewModel>();
    }
}