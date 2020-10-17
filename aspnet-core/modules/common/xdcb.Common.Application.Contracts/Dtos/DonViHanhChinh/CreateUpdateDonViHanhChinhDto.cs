using System;
using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.DonViHanhChinhDtos
{
    public class CreateUpdateDonViHanhChinhDto
    {
        [System.ComponentModel.DisplayName(DonViHanhChinh.MaDonViHanhChinh)]
        [StringLength(10)]
        public string MaDonViHanhChinh { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(DonViHanhChinh.TenDonViHanhChinh)]
        [StringLength(255)]
        public string TenDonViHanhChinh { get; set; }

        [System.ComponentModel.DisplayName(DonViHanhChinh.CapDonViHanhChinh)]
        public CapDonVi CapDonViHanhChinh { get; set; }

        [System.ComponentModel.DisplayName(DonViHanhChinh.ThuocCapDonViHanhChinh)]
        public Guid? ParentId { get; set; }
    }
}