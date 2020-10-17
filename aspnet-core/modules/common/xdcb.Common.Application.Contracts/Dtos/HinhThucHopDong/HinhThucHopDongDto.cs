using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.HinhThucHopDongDtos
{
    public class HinhThucHopDongDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenHinhThucHopDong { get; set; }

        #endregion Base properties
    }
}
