using System;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.Common.DanhMuc.LoaiVanBans;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public class ThanhPhanHoSo : BaseEntity
    {
        #region Base properties

        public string TenThanhPhanHoSo { get; set; }
        public Guid? LoaiVanBanId { get; set; }

        public LoaiVanBan LoaiVanBan { get; set; }

        public List<LoaiHoSoThanhPhanHoSo> LoaiHoSoThanhPhanHoSos { get; set; }

        #endregion Base properties
    }
}