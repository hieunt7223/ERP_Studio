using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.NguonVonDtos
{
    public class CreateUpdateNguonVonDto
    {
        [StringLength(16)]
        [DisplayName(ViewTextConsts.NguonVon.MaNguonVon)]
        public string MaNguonVon { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(255)]
        [DisplayName(ViewTextConsts.NguonVon.TenNguonVon)]
        public string TenNguonVon { get; set; }

        [DisplayName(ViewTextConsts.NguonVon.MaNguonVonMe)]
        public Guid? ParentId { get; set; }

        [StringLength(20)]
        [DisplayName(ViewTextConsts.NguonVon.ThuTuHienThi)]
        public string ThuTuHienThi { get; set; }
    }
}