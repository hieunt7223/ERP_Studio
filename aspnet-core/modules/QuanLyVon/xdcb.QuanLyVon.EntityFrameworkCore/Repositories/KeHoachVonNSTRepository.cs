using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using xdcb.QuanLyVon.EntityFrameworkCore;
using xdcb.QuanLyVon.KeHoachVonNSTs;

namespace xdcb.QuanLyVon.Repositories
{
    public class KeHoachVonNSTRepository : EfCoreRepository<QuanLyVonDbContext, KeHoachVonNST, Guid>, IKeHoachVonNSTRepository
    {
        public KeHoachVonNSTRepository(IDbContextProvider<QuanLyVonDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
