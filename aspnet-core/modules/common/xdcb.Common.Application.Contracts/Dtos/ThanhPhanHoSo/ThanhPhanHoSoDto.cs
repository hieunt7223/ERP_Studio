using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSoDtos
{
    public class ThanhPhanHoSoDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenThanhPhanHoSo { get; set; }
        public Guid? LoaiVanBanId { get; set; }

        public string LoaiVanBan { get; set; }

        public bool IsBatBuoc { get; set; }

        #endregion Base properties
    }
}
