using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using xdcb.FileService.DocumentStores;

namespace xdcb.FileService
{
    public static class FileServiceDbContextModelCreatingExtensions
    {
        public static void ConfigureFileService(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<DocumentStore>(b =>
            {
                b.ToTable(FileServiceDBConsts.DbTablePrefix + "DocumentStores", FileServiceDBConsts.DbSchema);
                b.Property(s => s.Url).HasColumnType("nvarchar(255)").IsRequired(true);
                b.Property(s => s.KieuFile).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.FullName).HasMaxLength(255);
                b.Property(s => s.Cached).HasMaxLength(255);
                b.ConfigureByConvention();
            });
        }
    }
}