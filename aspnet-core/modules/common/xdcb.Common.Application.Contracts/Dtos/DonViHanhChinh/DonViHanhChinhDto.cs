using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.DonViHanhChinhDtos
{
    public class DonViHanhChinhDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaDonViHanhChinh { get; set; }

        public string TenDonViHanhChinh { get; set; }

        public CapDonVi CapDonViHanhChinh { get; set; }

        public Guid? ParentId { get; set; }

        public string TenCapDonVi { get; set; }

        public string STT { get; set; }

        #endregion Base properties

        #region ExtraProperty
        public bool Selected { get; set; }
        #endregion
    }
}