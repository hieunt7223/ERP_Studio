using System;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public class NguonVon : BaseEntity
    {
        #region Base properties

        public string MaNguonVon { get; set; }

        public string TenNguonVon { get; set; }
        public Guid? ParentId { get; set; }
        public string ThuTuHienThi { get; set; }

        #endregion Base properties
    }
}