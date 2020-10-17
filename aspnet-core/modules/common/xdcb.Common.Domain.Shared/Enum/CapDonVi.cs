using System.ComponentModel;
using xdcb.Common.Attributes;

namespace xdcb.Common
{
    public enum CapDonVi
    {
        [EnumDescription("Tỉnh")]
        Tinh,
        [EnumDescription("Thành phố trực thuộc trung ương")]
        ThanhPhoTrucThuocTrungUong,
        [EnumDescription("Thành phố")]
        ThanhPho,
        [EnumDescription("Quận")]
        Quan,
        [EnumDescription("Huyện")]
        Huyen,
        [EnumDescription("Thị xã")]
        ThiXa,
        [EnumDescription("Thị trấn")]
        ThiTran,
        [EnumDescription("Phường")]
        Phuong,
        [EnumDescription("Xã")]
        Xa
    }
}