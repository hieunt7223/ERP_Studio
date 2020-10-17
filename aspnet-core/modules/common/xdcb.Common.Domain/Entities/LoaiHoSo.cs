using System;
using System.Collections.Generic;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSo : BaseEntity
    {
        public string TenLoaiHoSo { get; set; }

        /// <summary>
        /// Là loại hồ sơ điều chỉnh
        /// </summary>
        public bool IsDieuChinh { get; set; }

        /// <summary>
        /// được áp dụng
        /// </summary>
        public bool IsTrangThai { get; set; }

        /// <summary>
        /// Lưu danh sách biểu mẫu hồ sơ theo type json, xml
        /// </summary>
        public string BieuMau { get; set; }

        /// <summary>
        /// Thời gian xử lý quy định của nhóm A
        /// </summary>
        public int? ThoiGianXuLyQuyDinhNhomA { get; set; }

        /// <summary>
        /// Thời gian xử lý quy định của nhóm B
        /// </summary>
        public int? ThoiGianXuLyQuyDinhNhomB { get; set; }

        /// <summary>
        /// Thời gian xử lý quy định của nhóm C
        /// </summary>
        public int? ThoiGianXuLyQuyDinhNhomC { get; set; }

        /// <summary>
        /// BaoCaoDeXuatChuTruongDauTu
        /// BaoCaoDieuChinhChuTruongDauTu
        /// ThamDinhKeHoachLuaChonNhaThau
        /// ThamDinhDieuChinhKeHoachLuaChonNhaThau
        /// </summary>
        public string TenViewLoaiHoSo { get; set; }

        public List<LoaiHoSoChiPhiDauTu> LoaiHoSoChiPhiDauTus { get; set; }

        public List<LoaiHoSoThanhPhanHoSo> LoaiHoSoThanhPhanHoSos { get; set; }

        public List<LoaiHoSoCoSoPhapLy> LoaiHoSoCoSoPhapLys { get; set; }

        protected LoaiHoSo()
        {
        }

        public LoaiHoSo(string tenLoaiHoSo, bool isDieuChinh,
            bool isTrangThai, string bieuMau,
            int? thoiGianXuLyQuyDinhNhomA,
            int? thoiGianXuLyQuyDinhNhomB,
            int? thoiGianXuLyQuyDinhNhomC
            )
        {
            TenLoaiHoSo = tenLoaiHoSo;
            IsDieuChinh = isDieuChinh;
            IsTrangThai = isTrangThai;
            BieuMau = bieuMau;
            ThoiGianXuLyQuyDinhNhomA = thoiGianXuLyQuyDinhNhomA;
            ThoiGianXuLyQuyDinhNhomB = thoiGianXuLyQuyDinhNhomB;
            ThoiGianXuLyQuyDinhNhomC = thoiGianXuLyQuyDinhNhomC;
            LoaiHoSoChiPhiDauTus = new List<LoaiHoSoChiPhiDauTu>();
            LoaiHoSoThanhPhanHoSos = new List<LoaiHoSoThanhPhanHoSo>();
            LoaiHoSoCoSoPhapLys = new List<LoaiHoSoCoSoPhapLy>();
        }

        public void InitializeNullCollections()
        {
            LoaiHoSoChiPhiDauTus ??= new List<LoaiHoSoChiPhiDauTu>();
            LoaiHoSoThanhPhanHoSos ??= new List<LoaiHoSoThanhPhanHoSo>();
            LoaiHoSoCoSoPhapLys ??= new List<LoaiHoSoCoSoPhapLy>();
        }
    }
}