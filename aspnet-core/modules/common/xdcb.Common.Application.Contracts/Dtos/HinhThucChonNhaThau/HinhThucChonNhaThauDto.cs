using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos
{
    public class HinhThucChonNhaThauDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenHinhThucChonNhaThau { get; set; }

        #endregion Base properties
    }

    public class HinhThucChonNhaThauReport
    {
        [Description("Hình thức lựa chọn nhà thầu")]
        public string TenHinhThucChonNhaThau { get; set; }
    }
}
