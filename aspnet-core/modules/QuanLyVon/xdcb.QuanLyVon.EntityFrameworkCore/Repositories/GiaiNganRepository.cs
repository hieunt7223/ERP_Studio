using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;
namespace xdcb.QuanLyVon.GiaiNgans
{
    /// <summary>
    /// Generated Repositories for Table : GiaiNgan.
    /// </summary>
    public class GiaiNganRepository : EfCoreRepository<QuanLyVonDbContext, GiaiNgan, Guid>, IGiaiNganRepository
    {
        public GiaiNganRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<string> GetNotificationIsNew(int nam, bool isKeHoachKeoDai, string tenKeHoach, int quyThang, Guid chuDauTuId)
        {
            string strNote = string.Empty;
            var query = from ct in base.DbContext.GiaiNgan
                        where ct.Nam == nam
                          && ct.TenKeHoach == tenKeHoach
                          && ct.QuyThang == quyThang
                          && ct.ChuDauTuId == chuDauTuId
                          && ct.IsDeleted == false
                        select ct.Id;
            if (query != null && query.Count() > 0)
            {
                strNote = "Thông tin này đã được tạo giải ngân, Vui lòng kiểm tra lại!";
                return strNote;
            }

            //Kiểm tra thông tin kế hoạch vốn;
            var queryNSTW = from v in base.DbContext.vKeHoachVon
                            where v.Nam == nam
                                && v.ChuDauTuId == chuDauTuId
                            select v.Id;
            if (queryNSTW == null || queryNSTW.Count() == 0)
            {
                strNote = "Năm " + nam.ToString() + " chưa tạo kế hoạch vốn, Vui lòng kiểm tra lại!";
                return strNote;
            }
            return strNote;
        }
    }
}
