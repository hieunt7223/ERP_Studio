using System;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhChiTietInput
    {
        /// <summary>
        /// Trường hợp thêm mới thì Id hồ sơ công trình là null
        /// </summary>
        public Guid? HoSoCongTrinhId { get; set; }

        /// <summary>
        /// Id Công trình
        /// </summary>
        public Guid CongTrinhId { get; set; }

        /// <summary>
        /// Id loại hồ sơ 
        /// </summary>
        public Guid? LoaiHoSoId { get; set; }

        /// <summary>
        /// Id chủ đầu tư, nếu = null thì trạng thái hồ sơ tạo mới là đang xử lý
        /// # null thì trạng thái hồ sơ là đang soạn
        /// </summary>
        public Guid? ChuDauTuId { get; set; }
    }
}