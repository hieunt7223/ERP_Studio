using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.ThuVienVanBans;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBans
{
    public class FileCuaThuVienVanBan : BaseEntity
    {
        #region Base properties

        public Guid ThuVienVanBanId { get; set; }
        public Guid FileId { get; set; }

        public virtual ThuVienVanBan ThuVienVanBan { get; set; }

        #endregion Base properties
    }
}
