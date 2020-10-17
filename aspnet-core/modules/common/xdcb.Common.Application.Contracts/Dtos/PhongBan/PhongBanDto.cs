using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.PhongBanDtos
{
    public class PhongBanDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public Guid ChuDauTuId { get; set; }

        public string MaPhongBan { get; set; }

        public string TenPhongBan { get; set; }

        public string ChucNangNhiemVu { get; set; }

        public string SoDienThoai { get; set; }

        #endregion Base properties
    }

    public class PhongBanReport
    {
        [Description(ViewTextConsts.Phongban.TenPhongBan)]
        public string TenPhongBan { get; set; }

        [Description(ViewTextConsts.Phongban.MaPhongBan)]
        public string MaPhongBan { get; set; }

        [Description(ViewTextConsts.Phongban.SoDienThoai)]
        public string SoDienThoai { get; set; }
    }
}