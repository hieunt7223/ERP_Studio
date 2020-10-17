using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public class LoaiKhoan : BaseEntity
    {
        #region Base properties

        public int LoaiLoaiKhoan { get; set; }
        public string MaSo { get; set; }

        public string TenLoaiKhoan { get; set; }
        public string GhiChu { get; set; }

        public Guid? LoaiKhoanChaID { get; set; }

        public List<CongTrinh> CongTrinhs { get; set; }

        #endregion Base properties
    }
}