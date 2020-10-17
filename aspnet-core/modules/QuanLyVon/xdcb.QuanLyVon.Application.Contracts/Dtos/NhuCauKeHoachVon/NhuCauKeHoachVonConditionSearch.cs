using System;
using Volo.Abp.Application.Dtos;

namespace xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos
{
    public class NhuCauKeHoachVonConditionSearch
    {
        public int Nam { get; set; }
        public string Loaikehoach { get; set; }
        public string Tenkehoach { get; set; }
        public Guid ChuDauTuId { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
