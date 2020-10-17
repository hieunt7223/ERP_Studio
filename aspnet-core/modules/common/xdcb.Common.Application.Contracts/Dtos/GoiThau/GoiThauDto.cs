using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.GoiThauDtos
{
    public class GoiThauDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// Tên gói thầu
        /// </summary>
        public string TenGoiThau { get; set; }

        /// <summary>
        /// Id loại gói thầu
        /// </summary>
        public Guid? GoiThauParentId { get; set; }
    }
}