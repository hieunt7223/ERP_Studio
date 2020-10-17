using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace xdcb.Common.DanhMuc.ThuVienVanBanDtos
{
    public class CreateUpdateThuVienVanBanDto
    {
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [StringLength(50)]
        [DisplayName(ViewTextConsts.ThuVienVanBan.SoKyHieu)]
        public string SoKyHieu { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.LinhVucVanBan)]
        public Guid? LinhVucVanBanId { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.LoaiVanBan)]
        public Guid LoaiVanBanId { get; set; }

        [StringLength(500)]
        [DisplayName(ViewTextConsts.ThuVienVanBan.TrichYeu)]
        public string TrichYeu { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.CapBanHanh)]
        public CapBanHanh CapBanHanh { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [DisplayName(ViewTextConsts.ThuVienVanBan.DonViBanHanh)]
        public Guid DonViBanHanhId { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.NgayBanHanh)]
        public DateTime NgayBanHanh { get; set; }
    }
}