using System.Collections.Generic;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public class LoaiVanBan : BaseEntity
    {
        #region Base properties

        public LoaiVanBan()
        {
            ThanhPhanHoSos = new HashSet<ThanhPhanHoSo>();
            ThuVienVanBans = new HashSet<ThuVienVanBan>();
        }

        public string MaLoaiVanBan { get; set; }
        public string TenLoaiVanBan { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<ThanhPhanHoSo> ThanhPhanHoSos { get; set; }
        public virtual ICollection<ThuVienVanBan> ThuVienVanBans { get; set; }

        #endregion Base properties
    }
}