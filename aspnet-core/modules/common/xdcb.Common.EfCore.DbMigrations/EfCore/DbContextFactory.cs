using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace xdcb.Common.EfCore.DbMigrations
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */

    public class DbContextFactory : IDesignTimeDbContextFactory<CommonMigrationDbContext>
    {
        public CommonMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CommonMigrationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new CommonMigrationDbContext(builder.Options);
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