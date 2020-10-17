using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.NghiQuyetDtos
{
    public class NghiQuyetDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string SoVanBan { get; set; }

        public DateTime? NgayBanHanh { get; set; }
        public string TrichYeu { get; set; }

        public bool IsTheoDoi { get; set; }

        #endregion Base properties

        #region Extra Property
        public List<NghiQuyetCongTrinhDto> NghiQuyetCongTrinhs { get; set; }

        public int STT { get; set; }
        
        #endregion
    }
}