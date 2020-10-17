using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public class NghiQuyetRepository : EfCoreRepository<CommonDbContext, NghiQuyet, Guid>, INghiQuyetRepository
    {

        public NghiQuyetRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

       

        public async Task DeleleNghiQuyetCongTrinhByNghiQuyetId(Guid NghiQuyetId)
        {
            var listDelete = base.DbContext.NghiQuyetCongTrinhs.Where(x => x.NghiQuyetId == NghiQuyetId);
            if (listDelete != null && listDelete.Count() > 0)
            {
                base.DbContext.NghiQuyetCongTrinhs.RemoveRange(listDelete);
                base.DbContext.SaveChanges();
            }
        }

        public async Task<NghiQuyet> GetAsync(Guid Id)
        {
            return await GetQueryable().Include(s => s.NghiQuyetCongTrinhs).Where(w => w.Id == Id && !w.IsDeleted).FirstOrDefaultAsync();

        }

        public async Task<NghiQuyet> SaveNghiQuyetCongTrinh(NghiQuyet nghiQuyet)
        {
            if (nghiQuyet != null && nghiQuyet.NghiQuyetCongTrinhs.Count > 0)
            {
                base.DbContext.NghiQuyetCongTrinhs.AddRange(nghiQuyet.NghiQuyetCongTrinhs);
                base.DbContext.SaveChanges();
            }
            return nghiQuyet;
        }

        public async Task<PagedResultDto<NghiQuyet>> SearchAsync(ConditionSearch condition)
        {
            PagedResultDto<NghiQuyet> list = new PagedResultDto<NghiQuyet>();
            list.TotalCount = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword) && !w.IsDeleted).Count();
            list.Items = GetQueryable().AsEnumerable().Where(w => Common.ConvertToUnSign(w.TrichYeu).Contains(condition.keyword) && !w.IsDeleted).Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return list;
        }
    }
}