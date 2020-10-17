using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.QuanLyVon.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See QuanLyVonDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */

    public class QuanLyVonMigrationsDbContext : AbpDbContext<QuanLyVonMigrationsDbContext>
    {
        public QuanLyVonMigrationsDbContext(DbContextOptions<QuanLyVonMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureQuanLyVon method */

            builder.ConfigureQuanLyVon();
        }
    }
}