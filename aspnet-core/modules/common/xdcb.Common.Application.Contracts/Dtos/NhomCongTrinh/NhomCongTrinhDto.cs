using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.NhomCongTrinhDtos
{
    public class NhomCongTrinhDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaNhomCongTrinh { get; set; }
        public string TenNhomCongTrinh { get; set; }
        public string MoTa { get; set; }

        #endregion Base properties
    }
}