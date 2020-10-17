using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos
{
    public class ChuongTrinhMucTieuQuocGiaDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaChuongTrinhMucTieuQuocGia { get; set; }

        public string TenChuongTrinhMucTieuQuocGia { get; set; }
        public Guid? ParentId { get; set; }
        public List<ChuongTrinhMucTieuQuocGiaDto> ChildChuongTrinhMucTieuQuocGias { get; set; }

        public string Select { get; set; }

        public string STT { get; set; }

        #endregion Base properties
    }
}