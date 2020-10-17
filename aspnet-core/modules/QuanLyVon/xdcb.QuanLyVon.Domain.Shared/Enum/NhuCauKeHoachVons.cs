using xdcb.QuanLyVon.Attributes;

namespace xdcb.QuanLyVon.NhuCauKeHoachVons
{
    public enum LoaiKeHoach
    {
        [EnumDescription("Đầu năm")]
        DAU_NAM,

        [EnumDescription("Điều chỉnh")]
        DIEU_CHINH,
    }

    public enum TenKeHoach
    {
        [EnumDescription("Hằng năm")]
        HANG_NAM,

        [EnumDescription("Trung hạn")]
        TRUNG_HAN,
    }

    public enum TrangThai
    {
        [EnumDescription("Đang soạn")]
        DANG_SOAN,

        [EnumDescription("Đã gửi")]
        DA_GUI,

        [EnumDescription("Đã chốt báo cáo")]
        DA_CHOT,
    }
}
