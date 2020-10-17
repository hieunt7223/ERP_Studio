using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;

namespace xdcb.Common.DanhMuc.ThuVienVanBanDtos
{
    public class ThuVienVanBanDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string SoKyHieu { get; set; }
        public Guid? LinhVucVanBanId { get; set; }
        public Guid LoaiVanBanId { get; set; }
        public string TenLoaiVanBan { get; set; }
        public CapBanHanh CapBanHanh { get; set; }
        public string TrichYeu { get; set; }
        public Guid DonViBanHanhId { get; set; }
        public string DonViBanHanh { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string NgayBanHanhFormat { get; set; }

        public List<FileCuaThuVienVanBanDto> Files { get; set; }

        #endregion Base properties
    }
}