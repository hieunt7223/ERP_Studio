using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.PhongBans;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class ChuDauTu : BaseEntity
    {
        #region Base properties

        public string MaSoChuong { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SDTNguoiDaiDien { get; set; }
        public string NguoiDung { get; set; }

        public ICollection<PhongBan> PhongBans { get; set; }

        public List<CongTrinh> CongTrinhs { get; set; }

        #endregion Base properties
    }
}