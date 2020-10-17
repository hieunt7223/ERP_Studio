using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.ChucVuDtos
{
    public class ChucVuDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaChucVu { get; set; }

        public string TenChucVu { get; set; }

        #endregion Base properties
    }
}