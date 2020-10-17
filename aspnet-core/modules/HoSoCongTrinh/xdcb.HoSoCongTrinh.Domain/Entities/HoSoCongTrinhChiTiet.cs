using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using xdcb.HoSoCongTrinh.Enums;

namespace xdcb.HoSoCongTrinh.Entities
{
    public class HoSoCongTrinhChiTiet : FullAuditedEntity<Guid>, IExtraProperties
    {
        public Guid HoSoCongTrinhId { get; set; }

        public int SoLanDieuChinh { get; set; }

        public string SuCanThietDauTu { get; set; }

        public string QuyMoDauTu { get; set; }

        public string NguonVonDauTu { get; set; }

        public string MucTieuDauTu { get; set; }

        public TrangThaiEnums TrangThai { get; set; }

        public DateTime? HanXuLy { get; set; }

        public bool IsChuDauTu { get; set; }

        #region BaoCaoDeXuatChuTruongDauTu

        /// <summary>
        /// Id Ngành lĩnh vực sử dụng
        /// </summary>
        public Guid? NganhLinhVucSuDungId { get; set; }

        /// <summary>
        /// Id Đơn vị chủ trì thẩm định
        /// </summary>
        public Guid? DonViChuTriThamDinhId { get; set; }

        /// <summary>
        /// List Json List<guid> đơn vị chủ trì thẩm định
        /// </summary>
        public string DonViPhoiHopThamDinhs { get; set; }

        /// <summary>
        /// Cấp quyết định chủ trương đầu tư
        /// </summary>

        public Guid? CapQuyetDinhChuTruongDauTu { get; set; }


        /// <summary>
        /// Cấp quyết định đầu tư dự án
        /// </summary>

        public Guid? CapQuyetDinhDauTuDuAn { get; set; }

        /// <summary>
        /// Hình thức thẩm định
        /// </summary>
        public HinhThucThamDinhEnum HinhThucThamDinh { get; set; }


        /// <summary>
        /// Tổng hợp ý kiến thẩm định của đơn vị phối hợp
        /// </summary>
        public string YKienThamDinhDonViPhoiHop { get; set; }


        /// <summary>
        /// Sự cần thiết đầu tư dự án
        /// </summary>
        public string SuCanThietDauTuDuAn { get; set; }


        /// <summary>
        /// Sự tuân thủ các quy định của pháp luật trong nội dung hồ sơ trình thẩm định
        /// </summary>
        public string SuTuanThuQuyDinh { get; set; }

        /// <summary>
        /// Sử phù hợp với các mục tiêu chiến lược
        /// </summary>
        public string SuPhuHopMucTieuChienLuoc { get; set; }


        /// <summary>
        /// Sử phù hợp với các tiêu chí phân loại
        /// </summary>
        public string SuPhuHopMucTieuPhanLoai { get; set; }

        /// <summary>
        /// Các nội dung đầu tư
        /// </summary>
        public string NoiDungDauTu { get; set; }

        /// <summary>
        /// Ý kiến của đơn vị thẩm định
        /// </summary>
        public string YKienCuaDonViThamDinh { get; set; }

        /// <summary>
        /// Nội dung trình và nghị của phòng tham mưu
        /// </summary>
        public string NoiDungTrinhVaKienNghi { get; set; }

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
        /// Nội dung và quy mô đầu tư đề xuất điều chỉnh, bổ sung - loại điều chỉnh
        /// </summary>
        public string NoiDungQuyMoDauTuDeXuatDieuChinh { get; set; }

        #endregion

        #region tham dinh lựa chọn nhà thầu

        /// <summary>
        /// Tổng mức đầu tư
        /// </summary>
        public decimal TongMucDauTu { get; set; }

        /// <summary>
        /// Tổng mức dự toán được duyệt
        /// </summary>
        public decimal TongMucDuToanDuocDuyet { get; set; }

        /// <summary>
        /// ý kiến thẩm định về căn cứ pháp lý
        /// </summary>
        public string YKienThamDinhCanCuPhapLy { get; set; }

        /// <summary>
        /// Ý kiến thẩm định về nội dung kế hoạch lựa chọn nhà thầu
        /// </summary>
        public string YKienThamDinhNoiDungKeHoach { get; set; }

        /// <summary>
        /// Ý kiến thẩm định về tổng giá trị của các phần công việc
        /// </summary>
        public string YKienThamDinhGiaTriCongViec { get; set; }

        /// <summary>
        /// Tổng hợp kết quả thẩm định về căn cứ pháp lý 
        /// List<Json<KetQuaThamDinhPhapLyDto>>
        /// </summary>
        public string KetQuaThamDinhCanCuPhapLys { get; set; }

        /// <summary>
        /// Đánh giá của cơ quan thẩm định loại 4
        /// </summary>
        public string DanhGiaCoQuanThamDinh { get; set; }
        #endregion

        public int OrderIndex { get; set; }

        public Guid TenantId { get; set; }

        public HoSoCongTrinh HoSoCongTrinh { get; set; }

        public List<HoSoCongTrinhChiTietDiaDiem> HoSoCongTrinhChiTietDiaDiems { get; set; }

        public List<HoSoCongTrinhChiTietMucDauTu> HoSoCongTrinhChiTietMucDauTus { get; set; }

        public List<HoSoCongTrinhChiTietThanhPhanHoSo> HoSoCongTrinhChiTietThanhPhanHoSos { get; set; }

        public List<HoSoCongTrinhChiTietCoSoPhapLy> HoSoCongTrinhChiTietCoSoPhapLys { get; set; }

        public List<HoSoCongTrinhChiTietKetQuaThamDinh> HoSoCongTrinhChiTietKetQuaThamDinhs { get; set; }

        public List<HoSoCongTrinhChiTietNoiDungYeuCau> HoSoCongTrinhChiTietNoiDungYeuCaus { get; set; }

        public List<HoSoCongTrinhChiTietGoiThau> HoSoCongTrinhChiTietGoiThaus { get; set; }

        public List<HoSoCongTrinhChiTietCongViec> HoSoCongTrinhChiTietCongViecs { get; set; }

        /// <summary>
        /// Danh sách nguồn vốn
        /// </summary>
        public List<HoSoCongTrinhChiTietNguonVon> HoSoCongTrinhChiTietNguonVons { get; set; }

        protected HoSoCongTrinhChiTiet()
        {
        }

        public HoSoCongTrinhChiTiet(Guid id,
            Guid hoSoCongTrinhId,
            int soLanDieuChinh, string suCanThietDauTu,
            string quyMoDauTu, string nguonVonDauTu,
            TrangThaiEnums trangThai, DateTime? hanXuLy, bool isChuDauTu) : base(id)
        {
            HoSoCongTrinhId = hoSoCongTrinhId;
            SoLanDieuChinh = soLanDieuChinh;
            SuCanThietDauTu = suCanThietDauTu ?? throw new ArgumentNullException(nameof(suCanThietDauTu));
            QuyMoDauTu = quyMoDauTu ?? throw new ArgumentNullException(nameof(quyMoDauTu));
            NguonVonDauTu = nguonVonDauTu ?? throw new ArgumentNullException(nameof(nguonVonDauTu));
            TrangThai = trangThai;
            HanXuLy = hanXuLy;
            IsChuDauTu = isChuDauTu;
            HoSoCongTrinhChiTietDiaDiems = new List<HoSoCongTrinhChiTietDiaDiem>();
            HoSoCongTrinhChiTietMucDauTus = new List<HoSoCongTrinhChiTietMucDauTu>();
            HoSoCongTrinhChiTietThanhPhanHoSos = new List<HoSoCongTrinhChiTietThanhPhanHoSo>();
            HoSoCongTrinhChiTietCoSoPhapLys = new List<HoSoCongTrinhChiTietCoSoPhapLy>();
            HoSoCongTrinhChiTietKetQuaThamDinhs = new List<HoSoCongTrinhChiTietKetQuaThamDinh>();
            HoSoCongTrinhChiTietNoiDungYeuCaus = new List<HoSoCongTrinhChiTietNoiDungYeuCau>();
            HoSoCongTrinhChiTietGoiThaus = new List<HoSoCongTrinhChiTietGoiThau>();
            HoSoCongTrinhChiTietNguonVons = new List<HoSoCongTrinhChiTietNguonVon>();
            HoSoCongTrinhChiTietCongViecs = new List<HoSoCongTrinhChiTietCongViec>();
        }

        public void InitializeNullCollections()
        {
            HoSoCongTrinhChiTietDiaDiems ??= new List<HoSoCongTrinhChiTietDiaDiem>();
            HoSoCongTrinhChiTietMucDauTus ??= new List<HoSoCongTrinhChiTietMucDauTu>();
            HoSoCongTrinhChiTietThanhPhanHoSos ??= new List<HoSoCongTrinhChiTietThanhPhanHoSo>();
            HoSoCongTrinhChiTietCoSoPhapLys ??= new List<HoSoCongTrinhChiTietCoSoPhapLy>();
            HoSoCongTrinhChiTietKetQuaThamDinhs ??= new List<HoSoCongTrinhChiTietKetQuaThamDinh>();
            HoSoCongTrinhChiTietNoiDungYeuCaus ??= new List<HoSoCongTrinhChiTietNoiDungYeuCau>();
            HoSoCongTrinhChiTietGoiThaus ??= new List<HoSoCongTrinhChiTietGoiThau>();
            HoSoCongTrinhChiTietNguonVons ??= new List<HoSoCongTrinhChiTietNguonVon>();
            HoSoCongTrinhChiTietCongViecs ??= new List<HoSoCongTrinhChiTietCongViec>();
        }
    }
}