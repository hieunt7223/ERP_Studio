using System;
using System.ComponentModel;

namespace xdcb.Common.DanhMuc.LoaiHoSoDtos
{
    public class CoSoPhapLyDto
    {
        [DisplayName(ViewTextConsts.Common.STT)]
        public int Stt { get; set; }

        /// <summary>
        /// Id ho so cong trinh chi tiet co so phap ly
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id Thư viện văn bản
        /// </summary>
        public Guid? ThuVienVanBanId { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.TrichYeu)]
        public string TrichYeu { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.SoKyHieu)]
        public string SoKyHieu { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.NgayBanHanh)]
        public string NgayBanHanh { get; set; }

        [DisplayName(ViewTextConsts.ThuVienVanBan.LoaiVanBan)]
        public string LoaiVanBan { get; set; }
    }
}