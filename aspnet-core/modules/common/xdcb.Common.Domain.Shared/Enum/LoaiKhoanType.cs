using System.ComponentModel;
using xdcb.Common.Attributes;

namespace xdcb.Common
{
    public enum LoaiKhoanType
    {
        [EnumDescription("Loại")]
        Loai = 1,
        [EnumDescription("Khoản")]
        Khoan = 2,
    }
}