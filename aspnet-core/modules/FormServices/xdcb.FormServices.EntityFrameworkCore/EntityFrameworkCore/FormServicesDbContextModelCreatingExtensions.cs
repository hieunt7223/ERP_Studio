using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.FormServices.ModuleGroups;
using xdcb.FormServices.Modules;

namespace xdcb.FormServices.EntityFrameworkCore
{
    public static class FormServicesDbContextModelCreatingExtensions
    {
        public static void ConfigureFormServices(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<ModuleGroup>(b =>
            {
                b.ToTable("ModuleGroups", FormServicesConsts.DbSchema);

                b.Property(s => s.ModuleGroupNo).HasMaxLength(50);

                b.Property(s => s.ModuleGroupName).HasMaxLength(255);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });

            builder.Entity<Module>(b =>
            {
                b.ToTable("Modules", FormServicesConsts.DbSchema);

                b.Property(s => s.ModuleNo).HasMaxLength(50);

                b.Property(s => s.ModuleName).HasMaxLength(255);

                b.Property(s => s.IsScreenSearch).HasDefaultValue(true);

                b.Property(s => s.IsScreenDetail).HasDefaultValue(true);

                b.Property(s => s.OrderIndex).UseIdentityColumn().ValueGeneratedOnAddOrUpdate();

                b.Property(s => s.IsDeleted).HasDefaultValue(false);

                b.ConfigureByConvention();
            });
        }
    }
}