using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public class PhuongThucDauThauDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenPhuongThucDauThau { get; set; }

        #endregion Base properties
    }

    public class PhuongThucLuaChonReport
    {
        [Description("Phương thức lựa chọn nhà thầu")]
        public string TenPhuongThucChonNhaThau { get; set; }
    }
}