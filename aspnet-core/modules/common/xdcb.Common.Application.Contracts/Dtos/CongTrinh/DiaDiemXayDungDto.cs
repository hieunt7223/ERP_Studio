using System;

namespace xdcb.Common.DanhMuc.CongTrinhDtos
{
    public class DiaDiemXayDungDto
    {
        /// <summary>
        /// Id Công trình
        /// </summary>
        public Guid CongTrinhId { get; set; }

        /// <summary>
        /// Id đơn vị hành chính
        /// </summary>
        public Guid DonViHanhChinhId { get; set; }

        /// <summary>
        /// Ghi chú địa điểm
        /// </summary>
        public string GhiChu { get; set; }

        #region
        public string ButtonDelete { get; set; }
        #endregion
    }
}