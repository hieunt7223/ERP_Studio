using xdcb.HoSoCongTrinh.Attributes;

namespace xdcb.HoSoCongTrinh.Enums
{
    public enum LoaiCongViecEnums
    {
        /// <summary>
        /// Loại hồ sơ 3
        /// </summary>
        [EnumDescription("Phần công việc đã thực hiện")]
        CONGVIEC_DUOC_THUCHIEN = 1,

        /// <summary>
        /// Loại hồ sơ 3
        /// </summary>
        [EnumDescription("Phần công việc không áp dụng được một trong các hình thức lựa chọn nhà thầu")]
        CONGVIEC_KHONG_APDUNG = 2,

        /// <summary>
        /// Loại hồ sơ 3
        /// </summary>
        [EnumDescription("Phần công việc thuộc kế hoạch lựa chọn nhà thầu")]
        CONGVIEC_LUACHON_NHATHAU = 3,

        /// <summary>
        /// Loại hồ sơ 4
        /// </summary>
        [EnumDescription("Kế hoạch nhà thầu đã được phê duyệt")]
        GOITHAU_DUOC_PHEDUYET = 4,

        /// <summary>
        /// Loại hồ sơ 4
        /// </summary>
        [EnumDescription("Kế hoạch đấu thầu đề nghị điều chỉnh")]
        GOITHAU_DENGHI_DIEUCHINH = 5,

        /// <summary>
        /// Loại hồ sơ 4
        /// </summary>
        [EnumDescription("Gói thầu đề xuất")]
        GOITHAU_DEXUAT = 6,

        /// <summary>
        /// Loại hồ sơ 3
        /// </summary>
        [EnumDescription("Gói thầu kiến nghị")]
        GOITHAU_KIENNGHI = 7,

        /// <summary>
        /// phần công việc chưa đủ điều kiện lập kế hoạch lựa chọn nhà thầu Loại hồ sơ 3
        /// </summary>
        [EnumDescription("Phần công việc chưa đủ điều kiện lập kế hoạch lựa chọn nhà thầu")]
        CONGVIEC_CHUADUDIEUKIEN_LUACHON_NHATHAU = 8,
    }
}