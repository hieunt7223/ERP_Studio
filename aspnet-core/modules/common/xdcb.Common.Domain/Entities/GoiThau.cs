using System;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public class GoiThau : BaseEntity
    {
        /// <summary>
        /// Tên gói thầu
        /// </summary>
        public string TenGoiThau { get; set; }

        /// <summary>
        /// Id loại gói thầu
        /// </summary>
        public Guid LoaiGoiThauId { get; set; }

        /// <summary>
        /// Id gói thầu cha
        /// </summary>
        public Guid? GoiThauParentId { get; set; }
    }
}