using System.Collections.Generic;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public class LinhVucVanBan : BaseEntity
    {
        #region Base properties

        public LinhVucVanBan()
        {
            ThuVienVanBans = new HashSet<ThuVienVanBan>();
        }

        public string MaLinhVuc { get; set; }
        public string TenLinhVuc { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<ThuVienVanBan> ThuVienVanBans { get; set; }

        #endregion Base properties
    }
}