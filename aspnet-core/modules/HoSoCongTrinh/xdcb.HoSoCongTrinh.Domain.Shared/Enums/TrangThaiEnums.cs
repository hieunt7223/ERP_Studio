using xdcb.HoSoCongTrinh.Attributes;

namespace xdcb.HoSoCongTrinh.Enums
{
    public enum TrangThaiEnums
    {
        [EnumDescription("Đang soạn")]
        DANG_SOAN = 1,
        [EnumDescription("Đang xử lý")]
        DANG_XU_LY = 2,
        [EnumDescription("Yêu cầu chỉnh sửa")]
        YEU_CAU_CHINH_SUA = 3,
        [EnumDescription("Hoàn thành")]
        HOAN_THANH = 4,
    }
}