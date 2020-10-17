using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using xdcb.FileService.EntityFrameworkCore;

namespace xdcb.FileService.EfCore.DbMigrations
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */

    public class DbContextFactory : IDesignTimeDbContextFactory<FileServiceMigrationDbContext>
    {
        public FileServiceMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EntityFrameworkCore.FileServiceMigrationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new FileServiceMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}