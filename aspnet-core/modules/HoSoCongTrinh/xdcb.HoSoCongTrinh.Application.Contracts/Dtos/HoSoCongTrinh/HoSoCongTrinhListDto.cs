using Volo.Abp.Application.Dtos;

namespace xdcb.HoSoCongTrinh.Dtos
{
    public class HoSoCongTrinhListDto<T> : PagedResultDto<T>
    {
        /// <summary>
        /// Số page trên records
        /// </summary>
        public int PageCount { get; set; }
    }
}