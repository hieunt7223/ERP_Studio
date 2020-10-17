using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhDtos
{
    public class HangMucCongTrinhDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaHangMuc { get; set; }
        public string TenHangMuc { get; set; }
        public string MoTa { get; set; }

        #endregion Base properties
    }
}