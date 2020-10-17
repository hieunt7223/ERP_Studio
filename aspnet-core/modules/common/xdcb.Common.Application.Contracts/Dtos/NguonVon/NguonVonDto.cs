using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.NguonVonDtos
{
    public class NguonVonDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaNguonVon { get; set; }

        public string TenNguonVon { get; set; }
        public Guid? ParentId { get; set; }
        public string ThuTuHienThi { get; set; }
        public string STT { get; set; }

        public List<NguonVonDto> NguonVonChild { get; set; }

        #endregion Base properties

        #region Extra Property
        public int OrderIndex { get; set; }
        public bool Selected { get; set; }
        #endregion
    }
}