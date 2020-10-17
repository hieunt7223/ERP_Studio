using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.LinhVucVanBanDtos
{
    public class LinhVucVanBanDto : AuditedEntityDto<Guid>
    {
        #region Base properties

        public string MaLinhVuc { get; set; }
        public string TenLinhVuc { get; set; }
        public string MoTa { get; set; }

        #endregion Base properties

        //public LinhVucVanBanDto()
        //{
        //    CreationTime = DateTime.Now.ToString("dd/MM/yyyy");
        //}
    }
}
