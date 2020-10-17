using System.ComponentModel.DataAnnotations;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class CreateUpdateChuDauTuDto
    {
        [StringLength(16)]
        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.MaSoChuomg)]
        [Display(Prompt = PlaceholderChuDauTu.MaSoChuomg)]
        public string MaSoChuong { get; set; }

        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.TenChuong)]
        [StringLength(255)]
        [Display(Prompt = PlaceholderChuDauTu.TenChuong)]
        public string Ten { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.DiaChi)]
        [StringLength(255)]
        [Display(Prompt = PlaceholderChuDauTu.DiaChi)]
        public string DiaChi { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.SoDienThoai)]
        [StringLength(15)]
        [Display(Prompt = PlaceholderChuDauTu.SoDienThoai)]
        [DataType(DataType.PhoneNumber, ErrorMessage = Messages.MSG_Phone)]
        [RegularExpression(@"^([0-9]{9,11})$", ErrorMessage = Messages.MSG_Phone)]
        public string SoDienThoai { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.Email)]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = Messages.MSG_Email)]
        [Display(Prompt = PlaceholderChuDauTu.Email)]
        public string Email { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.NguoiDaiDien)]
        [StringLength(150)]
        [Display(Prompt = PlaceholderChuDauTu.NguoiDaiDien)]
        public string NguoiDaiDien { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.SDTNguoiDaiDien)]
        [StringLength(15)]
        [Display(Prompt = PlaceholderChuDauTu.SDTNguoiDaiDien)]
        [DataType(DataType.PhoneNumber, ErrorMessage = Messages.MSG_Phone)]
        [RegularExpression(@"^([0-9]{9,11})$", ErrorMessage = Messages.MSG_Phone)]
        public string SDTNguoiDaiDien { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.GhiChu)]
        [StringLength(500)]
        [Display(Prompt = PlaceholderChuDauTu.GhiChu)]
        public virtual string GhiChu { get; set; }

        [System.ComponentModel.DisplayName(CreateUpdateChuDauTu.NguoiDung)]
        [Display(Prompt = PlaceholderChuDauTu.DiaChi)]
        public string NguoiDung { get; set; }
    }
}