using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace xdcb.Common.DanhMuc.DonViBanHanhDtos
{
    public class DonViBanHanhDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// Tên đơn vị ban hành
        /// </summary>
        public string Ten { get; set; }
    }

    public class DonViBanHanhReportDto
    {
        [Description(ViewTextConsts.DonViBanHanh.TenDonViBanHanh)]
        public string Ten { get; set; }
    }
}