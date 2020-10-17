using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiVanBanDtos
{
    public class LoaiVanBanDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaLoaiVanBan { get; set; }
        public string TenLoaiVanBan { get; set; }
        public string MoTa { get; set; }

        #endregion Base properties
    }
}