﻿using System.Collections.Generic;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class BaoCaoDieuChinhChuTruongDauTu
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string tenCongTrinh { get; set; }
        public string toTrinhSo { get; set; }
        public string ngayTrinh { get; set; }
        public List<string> coSoPhapLys { get; set; }
        public List<string> thanhPhanHoSos { get; set; }
        public string donViChuTriThamDinh { get; set; }
        public string tenDonViPhoiHops { get; set; }
        public string hinhThucThamDinh { get; set; }
        public string nhomDuAn { get; set; }
        public string capQuyetDinhChuTruongDauTu { get; set; }
        public string capQuyetDinhDauTuDuAn { get; set; }
        public string tenChuDauTu { get; set; }
        public string diaDiems { get; set; }
        public string mucDauTuPheDuyet { get; set; }
        public string mucDauTuBoSung { get; set; }
        public List<string> nguonVons { get; set; }
        public string noiDungDieuChinh { get; set; }
        public string suCanThietDauTuDuAn { get; set; }
        public string suTuanThuQuyDinh { get; set; }
        public string suPhuHopMucTieuChienLuoc { get; set; }
        public string suPhuHopTieuChi { get; set; }
        public string cacNoiDungDauTu { get; set; }
        public string yKienDonViThamDinh { get; set; }
        public string noiDungTrinhVaKienNghi { get; set; }
    }
}