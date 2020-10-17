using System;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietNguonVonDto
    {
        public Guid? HoSoCongTrinhChiTietId { get; set; }

        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.TenNguonVon)]
        public Guid NguonVonId { get; set; }

        /// <summary>
        /// Tên nguồn vốn
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.TenNguonVon)]
        public string TenNguonVon { get; set; }

        /// <summary>
        /// Giá trị đề nghị
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriDeNghi)]
        public decimal GiaTriDeNghi { get; set; }

        /// <summary>
        /// Giá trị thẩm định
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriThamDinh)]
        public decimal GiaTriThamDinh { get; set; }

        /// <summary>
        /// Giá trị nguồn vốn bằng chữ
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriNguonVon)]
        public string GiaTriNguonVon { get; set; }
    }
}