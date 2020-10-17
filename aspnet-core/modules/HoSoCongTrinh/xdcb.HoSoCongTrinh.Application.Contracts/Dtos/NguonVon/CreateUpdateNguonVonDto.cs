using System;
using System.ComponentModel.DataAnnotations;
using xdcb.HoSoCongTrinh.Constants;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class CreateUpdateNguonVonDto
    {
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.TenNguonVon)]
        [Required (ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        public Guid NguonVonId { get; set; }

        /// <summary>
        /// Giá trị đề nghị
        /// </summary>
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriDeNghi)]
        public decimal GiaTriDeNghi { get; set; }

        /// <summary>
        /// Giá trị thẩm định   
        /// </summary>
        [Required(ErrorMessage = HoSoConstants.Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriThamDinh)]
        public decimal GiaTriThamDinh { get; set; }

        /// <summary>
        /// Giá trị nguồn vốn bằng chữ
        /// </summary>
        [System.ComponentModel.DisplayName(ViewTextConsts.NguonVonViewModel.GiaTriNguonVon)]
        public string GiaTriNguonVon { get; set; }
    }
}