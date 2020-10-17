using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.FormServices.ConfigColumns;

namespace xdcb.FormServices.EntityFrameworkCore
{
    public static class FormServicesDbContextModelCreatingExtensions
    {
        public static void ConfigureFormServices(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<ConfigColumn>(b =>
            {
                b.ToTable("ConfigColumns", FormServicesConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }
    }
}