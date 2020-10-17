using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LoaiKhoanDtos
{
    public class LoaiKhoanDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public int LoaiLoaiKhoan { get; set; }
        public string MaSo { get; set; }

        public string TenLoaiKhoan { get; set; }
        public string GhiChu { get; set; }

        public string TenLoaiLoaiKhoan { get; set; }
        public string STT { get; set; }

        public Guid? LoaiKhoanChaID { get; set; }

        public List<LoaiKhoanDto> Khoans { get; set; }

        #endregion Base properties
    }
}