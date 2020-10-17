using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See HoSoCongTrinhDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */

    public class HoSoCongTrinhMigrationsDbContext : AbpDbContext<HoSoCongTrinhMigrationsDbContext>
    {
        public HoSoCongTrinhMigrationsDbContext(DbContextOptions<HoSoCongTrinhMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Configure your own tables/entities inside the ConfigureHoSoCongTrinh method */

            builder.ConfigureHoSoCongTrinh();
        }
    }
}