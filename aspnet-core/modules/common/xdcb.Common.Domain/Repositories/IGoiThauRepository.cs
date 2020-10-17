using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public interface IGoiThauRepository : IRepository<GoiThau, Guid>
    {
        Task DeleteByParentIdAsync(Guid id);
    }
}