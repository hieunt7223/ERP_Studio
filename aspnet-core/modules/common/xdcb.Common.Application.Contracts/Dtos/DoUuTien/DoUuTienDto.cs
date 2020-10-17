using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.DoUuTienDtos
{
    public class DoUuTienDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public MaDoUuTien MaDoUuTien { get; set; }

        public string TenDoUuTien { get; set; }

        public int? ThuTuHienThi { get; set; }

        public string MoTa { get; set; }

        #endregion Base properties
    }
}