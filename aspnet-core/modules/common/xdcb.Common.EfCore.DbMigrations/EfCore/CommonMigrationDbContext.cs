using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.EfCore.DbMigrations
{
    public class CommonMigrationDbContext : AbpDbContext<CommonMigrationDbContext>
    {
        public CommonMigrationDbContext(DbContextOptions<CommonMigrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureCommon();
            base.OnModelCreating(builder);
        }
    }
}