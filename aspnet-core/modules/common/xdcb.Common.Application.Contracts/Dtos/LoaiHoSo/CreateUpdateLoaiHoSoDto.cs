using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.LoaiHoSoDtos
{
    public class CreateUpdateLoaiHoSoDto
    {
        /// <summary>
        /// Tên loại hồ sơ
        /// </summary>
        [Required(ErrorMessage = Messages.MSG_Requied)]
        [System.ComponentModel.DisplayName(LoaiHoSo.TenHoSo)]
        [Display(Prompt = PlaceholderLoaiHoSo.TenHoSo)]
        public string TenLoaiHoSo { get; set; }

        [System.ComponentModel.DisplayName(LoaiHoSo.DieuChinh)]
        public bool IsDieuChinh { get; set; }

        /// <summary>
        /// Được áp dụng
        /// </summary>
        [System.ComponentModel.DisplayName(LoaiHoSo.ApDung)]
        public bool IsTrangThai { get; set; }

        [System.ComponentModel.DisplayName("")]
        public int? ThoiGianXuLyQuyDinhNhomA { get; set; }

        [System.ComponentModel.DisplayName("")]
        public int? ThoiGianXuLyQuyDinhNhomB { get; set; }

        [System.ComponentModel.DisplayName("")]
        public int? ThoiGianXuLyQuyDinhNhomC { get; set; }

        /// <summary>
        /// Danh sách thành phần hồ sơ
        /// </summary>
        public List<CreateUpdateLoaiHoSoThanhPhanHoSoDto> ThanhPhanHoSos { get; set; }

        /// <summary>
        /// Danh sách cơ sở pháp lý
        /// </summary>
        public List<CreateUpdateLoaiHoSoCoSoPhapLyDto> CoSoPhapLys { get; set; }
    }
}