using System;

namespace xdcb.Common.DanhMuc.GoiThauDtos
{
    public class CreateUpdateGoiThauDto
    {
        /// <summary>
        /// Tên gói thầu
        /// </summary>
        public string TenGoiThau { get; set; }

        /// <summary>
        /// Id Loại gói thầu
        /// </summary>
        public Guid? GoiThauParentId { get; set; }
    }
}