using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.KhoanChiDtos
{
    public class KhoanChiDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaKhoanChi { get; set; }
        public string TenKhoanChi { get; set; }
        public string GhiChu { get; set; }

        #endregion Base properties
    }
}
