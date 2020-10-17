using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhDtos
{
    public class LoaiCongTrinhDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaLoaiCongTrinh { get; set; }
        public string TenLoaiCongTrinh { get; set; }
        public string MoTa { get; set; }

        #endregion Base properties
    }

    public class LoaiCongTrinhReportDto
    {
        [Description(ViewTextConsts.LoaiCongTrinh.MaLoaiCongTrinh)]
        public string MaLoaiCongTrinh { get; set; }

        [Description(ViewTextConsts.LoaiCongTrinh.TenLoaiCongTrinh)]
        public string TenLoaiCongTrinh { get; set; }

        [Description(ViewTextConsts.LoaiCongTrinh.MoTa)]
        public string MoTa { get; set; }
    }
}