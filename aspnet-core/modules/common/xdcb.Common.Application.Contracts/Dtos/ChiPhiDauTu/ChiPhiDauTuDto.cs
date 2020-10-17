using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.ChiPhiDauTuDtos
{
    public class ChiPhiDauTuDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string TenChiPhi { get; set; }

        public string LoaiChiPhi { get; set; }

        #endregion Base properties
    }

    public class ChiPhiDauTuReportDto
    {
        [Description(ViewTextConsts.ChiPhiDauTu.TenChiPhi)]
        public string TenChiPhi { get; set; }

        [Description(ViewTextConsts.ChiPhiDauTu.LoaiChiPhi)]
        public string LoaiChiPhi { get; set; }
    }
}