using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using xdcb.Common.Attributes;
using xdcb.Common.Localization;

namespace xdcb.Common
{
    public enum MaDoUuTien
    {
        [EnumDescription("Ưu tiên 1")]
        Uutien1 = 0,
        [EnumDescription("Ưu tiên 2")]
        Uutien2 = 1,
        [EnumDescription("Dãn tiến độ")]
        DanTienDo = 2,
        [EnumDescription("Chưa xác định")]
        ChuaXacDinh = 3
    }
}