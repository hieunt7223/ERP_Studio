using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhs;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public class ChuongTrinhMucTieuQuocGia : BaseEntity
    {
        #region Base properties

        public string MaChuongTrinhMucTieuQuocGia { get; set; }

        public string TenChuongTrinhMucTieuQuocGia { get; set; }
        public Guid? ParentId { get; set; }

        public List<CongTrinh> CongTrinhs { get; set; }

        #endregion Base properties
    }
}