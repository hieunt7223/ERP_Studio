using System;
using xdcb.Common.DanhMuc.ChuDauTus;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public class PhongBan : BaseEntity
    {
        #region Base properties

        public Guid ChuDauTuId { get; set; }

        public string MaPhongBan { get; set; }

        public string TenPhongBan { get; set; }

        public string ChucNangNhiemVu { get; set; }

        public string SoDienThoai { get; set; }

        public ChuDauTu ChuDauTu { get; set; }

        #endregion Base properties
    }
}