using EnumsNET;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public class DoUuTienRepository : EfCoreRepository<CommonDbContext, DoUuTien, Guid>, IDoUuTienRepository
    {
        public DoUuTienRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<DoUuTien>> SearchAsync(ConditionSearch condition)
        {
            string checkMa = "";
            for(int i = 0; i < 4; i++)
            {
                string maDoUuTien = ((MaDoUuTien)i).AsString(EnumFormat.Description);
                if (Common.ConvertToUnSign(maDoUuTien).Contains(condition.keyword))
                {
                    checkMa += i;
                }
            }

            PagedResultDto<DoUuTien> list = new PagedResultDto<DoUuTien>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenDoUuTien).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)
            ||string.Compare(w.MaDoUuTien.ToString(), checkMa) == 0) && !w.IsDeleted).Count();

            list.Items = GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenDoUuTien).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.MoTa).Contains(condition.keyword)
            || string.Compare(w.MaDoUuTien.ToString(), checkMa) == 0) && !w.IsDeleted
            ).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}