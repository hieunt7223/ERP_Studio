using System;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public class DoUuTien : BaseEntity
    {
        #region Base properties

        public int MaDoUuTien { get; set; }

        public string TenDoUuTien { get; set; }

        public int? ThuTuHienThi { get; set; }

        public string MoTa { get; set; }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        #endregion Base properties
    }
}