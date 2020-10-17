using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiKhoanDtos
{
    public class LoaiDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenLoaiKhoan { get; set; }

        #endregion Base properties
    }
}