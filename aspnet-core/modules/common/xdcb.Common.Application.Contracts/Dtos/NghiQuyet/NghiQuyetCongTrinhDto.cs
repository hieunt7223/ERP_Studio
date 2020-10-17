using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.Common.DanhMuc.NghiQuyetDtos
{
    public class NghiQuyetCongTrinhDto
    {
        /// <summary>
        /// Id Công trình
        /// </summary>
        public Guid CongTrinhId { get; set; }

        /// <summary>
        /// Id nghị quyết
        /// </summary>
        public Guid NghiQuyetId { get; set; }

        #region ExtraProperty
        public bool Selected { get; set; }
        #endregion
    }
}
